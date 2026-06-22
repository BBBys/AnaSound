using ASHilfen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace RTTY
{
  internal class RTTYDecoder
  {

    //-----------------------------------------------------------------------------------
    // Typische WEFAX-Frequenzen (anpassen, falls dein Sender andere nutzt)
    // http://www.wetterstation-hamburg.de/bandplan-wetter.html
    // --
    // 147,300 kHz DDH 47
    // Param: 50 Bd Hub +/- 42,5,Hz
    // gemessen 578, 641 Hz, ittel 609,5 -> 567, 652
    //const double FreqBlack = 364;// 1500.0;  // "schwarz"
    //const double FreqWhite = 804;// 2300.0;  // "weiß"
    //const double MARK = 567;// gemessen "schwarz"
    //const double SPACE = 652;// gemessen "weiß"
    const double MARK = 474;// gemessen "schwarz"
    const double SPACE = 553;// gemessen "weiß"
    private static readonly ulong maxToken = 99999;
    static readonly Dictionary<int, string> Letters = new Dictionary<int, string>()
    {
        {0b00000, ""}, {0b00001, "E"}, {0b00010, "\n"}, {0b00011, "A"},
        {0b00100, " "}, {0b00101, "S"}, {0b00110, "I"}, {0b00111, "U"},
        {0b01000, "\r"}, {0b01001, "D"}, {0b01010, "R"}, {0b01011, "J"},
        {0b01100, "N"}, {0b01101, "F"}, {0b01110, "C"}, {0b01111, "K"},
        {0b10000, "T"}, {0b10001, "Z"}, {0b10010, "L"}, {0b10011, "W"},
        {0b10100, "H"}, {0b10101, "Y"}, {0b10110, "P"}, {0b10111, "Q"},
        {0b11000, "O"}, {0b11001, "B"}, {0b11010, "G"}, {0b11011, "FIGS"},
        {0b11100, "M"}, {0b11101, "X"}, {0b11110, "V"}, {0b11111, "LTRS"}
    };

    static readonly Dictionary<int, string> Figures = new Dictionary<int, string>()
    {
        {0b00000, ""}, {0b00001, "3"}, {0b00010, "\n"}, {0b00011, "-"},
        {0b00100, " "}, {0b00101, "'"}, {0b00110, "8"}, {0b00111, "7"},
        {0b01000, "\r"}, {0b01001, "$"}, {0b01010, "4"}, {0b01011, "'"},
        {0b01100, ","}, {0b01101, "!"}, {0b01110, ":"}, {0b01111, "("},
        {0b10000, "5"}, {0b10001, "\""}, {0b10010, ")"}, {0b10011, "2"},
        {0b10100, "#"}, {0b10101, "6"}, {0b10110, "0"}, {0b10111, "1"},
        {0b11000, "9"}, {0b11001, "?"}, {0b11010, "&"}, {0b11011, "FIGS"},
        {0b11100, "."}, {0b11101, "/"}, {0b11110, ";"}, {0b11111, "LTRS"}
    };

    //-----------------------------------------------------------------------------------
    static void Main(string[] args)
    {
      string inputWav, outTxt;
      ulong sRate,  totalToken, totalBits;
   uint noSync, smpPerToken, smpPerBit;
      int Baud = 50;
      ASDatei Audiodatei;
      //ob Zeichen - Buchstaben
      bool figures = false;
      List<int> bits = new List<int>();
      List<string> output = new List<string>();
      var allSamples = new System.Collections.Generic.List<float>();
      bool ende;
      float[] samples;

      if (args.Length < 2)
      {
        Console.WriteLine("Verwendung: RTTY <input.wav> <output.png> /b<Baud>");
        return;
      }
      inputWav = args[0];
      if (!File.Exists(inputWav))
      {
        Console.WriteLine("Eingabedatei nicht gefunden.");
        return;
      }
      outTxt = args[1];
      for (int i = 2; i < args.Length; i++)
      {
        string arg = args[i];
        if (arg.StartsWith("/"))
        {
          string key = arg.Substring(1, 1);
          string value = arg.Substring(2);
          switch (key)
          {
            // case "w":
            //  pxPerLine = Int32.Parse(value);
            //  break;
            case "b":
              Baud = Int32.Parse(value);
              break;
            default:
              break;
          }
        }
      }

      //-------------------
      //WAV einlesen
      Audiodatei = new ASDatei(inputWav);
      do
      {
        float f;
        (f, ende) = Audiodatei.ReadNextMono();
        allSamples.Add(f);
      } while (!ende);
      samples = allSamples.ToArray();

      //-----------------
      //alle Berechnungen
      sRate = Audiodatei.SRate;
      smpPerToken = (uint)(((double)sRate / (double)Baud) + .5);
      totalToken = Math.Min(maxToken,(ulong) samples.Length / smpPerToken);
      smpPerBit = (uint)((((double)sRate / (double)Baud )/ 7.0) + .5);//5 + Start + 2 Stop
      totalBits =(ulong)Math.Floor((double) samples.Length /(double) smpPerBit);

      Console.WriteLine($"Samples: {samples.Length},\tSampleRate: {sRate}");
      Console.WriteLine($"  Token: {totalToken},\tBaudrate: {Baud}");
      Console.WriteLine($"   Bits: {totalBits}");

      if (smpPerToken < 1)
      {
        Console.WriteLine("Ungültige Tokenlänge.");
        return;
      }

      if (totalToken < 1)
      {
        Console.WriteLine("Zu wenig Daten für ein Token.");
        return;
      }

      Console.WriteLine($"Erzeuge Text mit {totalToken} Token.");

      //-----
      noSync = 0;
      for (ulong samplesFertig = 0; samplesFertig <(ulong) samples.Length - smpPerBit; samplesFertig += smpPerBit)
      {
        string symbol;
        int bit;
        double markPower, spacePower;
        var slice = samples.Skip((int)samplesFertig).Take((int)smpPerBit).ToArray();
        markPower = Goertzel.Energie(slice, 0, smpPerBit, sRate, MARK);
        spacePower = Goertzel.Energie(slice, 0, smpPerBit, sRate, SPACE);
        bit = markPower > spacePower ? 1 : 0;
        bits.Add(bit);
        if (bits.Count == 7) // Start + 5 Bits + Stop
        {
          if (bits[0] == 0) // Startbit korrekt
          {
            int value = 0;
            for (int b = 1; b <= 5; b++)
              value |= (bits[b] << (b - 1));
            symbol = figures ? Figures[value] : Letters[value];
            if (symbol == "FIGS")
              figures = true;
            else if (symbol == "LTRS")
              figures = false;
            else
              output.Add(symbol);
            noSync = 0;
          }
          else// Startbit korrekt
          { noSync++;
            samplesFertig = samplesFertig - smpPerBit + 1;
            if ((noSync + 1) % 50 == 0) Console.WriteLine($"NOSYNC {noSync}"); }
          bits.Clear();
        }
        if (output.Count % 100 == 0)
        {
          Console.WriteLine($"Zeichen {output.Count}/{totalToken}...");
          Console.WriteLine(string.Join("", output));
        }
      }
      Console.WriteLine(string.Join("", output));
    }
  }
}
using ASHilfen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace RTTY
{
  internal class FSKTrack
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
    private const double MARK = 474;// gemessen "schwarz"
    private const double SPACE = 553;// gemessen "weiß"
    private static readonly ulong maxToken = 99999;
    //-----------------------------------------------------------------------------------
    private static void Main(string[] args)
    {
      string inputWav, outTxt;
      ulong sRate, totalToken, totalBits;
      uint smpPerToken, smpPerBit;
      int Baud = 50;
      ASDatei Audiodatei;
      List<float> allSamples = new List<float>();
      bool ende;
      float[] samples;

      if (args.Length < 2)
      {
        Console.WriteLine("Verwendung: FSKTrack <input.wav> <output.csv> /b<Baud>");
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
              Baud = int.Parse(value);
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
      smpPerToken = (uint)((sRate / (double)Baud) + .5);
      totalToken = Math.Min(maxToken, (ulong)samples.Length / smpPerToken);
      smpPerBit = (uint)((sRate / (double)Baud / 7.0) + .5);//5 + Start + 2 Stop
      totalBits = (ulong)Math.Floor(samples.Length / (double)smpPerBit);

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

      Console.WriteLine($"{totalToken} Token auf {outTxt}.");

      //-----
      using (StreamWriter aus = new StreamWriter(outTxt))
      {
        aus.WriteLine($"samples; markPower; spacePower; {outTxt}");
        for (ulong samplesFertig = 0; samplesFertig < (ulong)samples.Length - smpPerBit; samplesFertig += smpPerBit)
        {
          double markPower, spacePower;
          float[] slice = samples.Skip((int)samplesFertig).Take((int)smpPerBit).ToArray();
          markPower = Goertzel.Energie(slice, 0, smpPerBit, sRate, MARK);
          spacePower = Goertzel.Energie(slice, 0, smpPerBit, sRate, SPACE);
          aus.WriteLine($"{samplesFertig};{markPower};{spacePower}");
          if (samplesFertig % 100000 == 0)
          {
            Console.WriteLine($"{samplesFertig} von {totalToken}");
          }
        }//for
      }
    }
  }
}
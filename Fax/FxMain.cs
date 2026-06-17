using ASHilfen;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace Fax
{
  internal class WeatherFaxDecoder
  {

    //-----------------------------------------------------------------------------------
    // Typische WEFAX-Frequenzen (anpassen, falls dein Sender andere nutzt)
    // http://www.wetterstation-hamburg.de/bandplan-wetter.html
    // --
    // 147,300 kHz DDH 47
    // Param: 50 Bd Hub +/- 42,5,Hz
    // gemessen 578, 641 Hz, ittel 609,5 -> 567, 652
    // --
    // 10.100,800 kHz DDK 9
    // Param: 50 Bd Hub +/- 225Hz
    // gemessen 578, 641 Hz, ittel 609,5 -> 567, 652
    // --
    //const double FreqBlack = 364;// 1500.0;  // "schwarz"
    //const double FreqWhite = 804;// 2300.0;  // "weiß"
    const double FreqBlack = 567;// gemessen "schwarz"
    const double FreqWhite = 652;// gemessen "weiß"
                                 //    const double FreqBlack =  1500.0;  // "schwarz"
                                 //  const double FreqWhite =  2300.0;  // "weiß"

    //-----------------------------------------------------------------------------------
    // Bildparameter – hier kannst du experimentieren
    // 50 Bd
    const int MaxLines = 4000;      // maximale Zeilenanzahl (wird ggf. früher beendet)
    //-----------------------------------------------------------------------------------
    static void Main(string[] args)
    {
      string inputWav, outputPng;
      int sRate, smpPerLine, totalLines, smpPerPx;
      int pxPerLine = 300;      // Pixel pro Zeile
      int Baud = 50;
      double secPerLine;
      ASDatei Audiodatei;

      if (args.Length < 2)
      {
        Console.WriteLine("Verwendung: Fax <input.wav> <output.png> /w<width> /b<Baud>");
        return;
      }
      //  Dictionary<string, string> options = new Dictionary<string, string>();
      inputWav = args[0];
      if (!File.Exists(inputWav))
      {
        Console.WriteLine("Eingabedatei nicht gefunden.");
        return;
      }
      outputPng = args[1];
      for (int i = 2; i < args.Length; i++)
      {
        string arg = args[i];
        if (arg.StartsWith("/"))
        {
          string key = arg.Substring(1, 1);
          string value = arg.Substring(2);
          switch (key)
          {
            case "w":
              pxPerLine = Int32.Parse(value);
              break;
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
      float[] samples;
      Audiodatei = new ASDatei(inputWav);
      var allSamples = new System.Collections.Generic.List<float>();
      bool ende;
      do
      {
        float f;
        (f, ende) = Audiodatei.ReadNextMono();
        allSamples.Add(f);
      } while (!ende);
      samples = allSamples.ToArray();

      //-----------------
      //alle Berechnungen
      sRate = (int)Audiodatei.SRate;
      secPerLine =(double) pxPerLine /(double) Baud;
      smpPerLine = (int)(secPerLine * sRate);
      smpPerPx = smpPerLine / pxPerLine;
      totalLines = Math.Min(MaxLines, samples.Length / smpPerLine);

      Console.WriteLine($"    Samples: {samples.Length},\tSampleRate: {sRate}");
      Console.WriteLine($"Pixel/Zeile: {pxPerLine},\tSamples/Zeile: {smpPerLine}");
      Console.WriteLine($"   Baudrate: {Baud},\tZeilendauer: {secPerLine}");

      if (smpPerLine < 1)
      {
        Console.WriteLine("Ungültige Zeilenlänge.");
        return;
      }

      if (totalLines < 1)
      {
        Console.WriteLine("Zu wenig Daten für eine Zeile.");
        return;
      }

      Console.WriteLine($"Erzeuge Bild mit {totalLines} Zeilen à {pxPerLine} Pixel.");

      using (var bmp = new Bitmap(pxPerLine, totalLines, PixelFormat.Format24bppRgb))
      {
        for (int line = 0; line < totalLines; line++)
        {
          int lineStart = line * smpPerLine;

          for (int x = 0; x < pxPerLine; x++)
          {
            int pixelStart, pixelEnd, gray, windowLength;
            double energyBlack, ratio, energyWhite;
            Color c;
            // Fenster für diesen Pixel
            pixelStart = lineStart + x * smpPerPx;
            pixelEnd = pixelStart + smpPerPx;
            if (pixelEnd > samples.Length)
              pixelEnd = samples.Length;
            if (pixelEnd <= pixelStart)
              pixelEnd = pixelStart + 1;
            windowLength = pixelEnd - pixelStart;

            energyBlack = Goertzel.Energie(samples, pixelStart, windowLength, sRate, FreqBlack);
            energyWhite = Goertzel.Energie(samples, pixelStart, windowLength, sRate, FreqWhite);

            // Helligkeit aus Verhältnis ableiten
            ratio = energyWhite / (energyBlack + energyWhite + 1e-9);
            gray = (int)(ratio * 255.0);
            if (gray < 0)
              gray = 0;
            if (gray > 255)
              gray = 255;

            c = Color.FromArgb(gray, gray, gray);
            bmp.SetPixel(x, line, c);
          }

          if (line % 10 == 0)
          {
            Console.WriteLine($"Zeile {line + 1}/{totalLines}...");
          }
        }

        bmp.Save(outputPng, ImageFormat.Png);
      }

      Console.WriteLine($"Fertig. Bild gespeichert als: {outputPng}");
    }
  }
}
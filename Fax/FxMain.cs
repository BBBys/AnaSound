
using ASHilfen;
using System;
using System.Drawing;
using System.Drawing.Imaging;
//using System.Drawing.Imaging;
//using System.Drawing.Common;
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
    const double secondsPerLine = 6; // TODO: an dein Signal anpassen
    const int ImageWidth = 300;      // Pixel pro Zeile
    const int MaxLines = 4000;      // maximale Zeilenanzahl (wird ggf. früher beendet)
    //-----------------------------------------------------------------------------------
    static void Main(string[] args)
    {
      ASDatei Audiodatei;

      if (args.Length < 2)
      {
        Console.WriteLine("Verwendung: WeatherFaxDecoder <input.wav> <output.png>");
        return;
      }

      string inputWav = args[0];
      string outputPng = args[1];

      if (!File.Exists(inputWav))
      {
        Console.WriteLine("Eingabedatei nicht gefunden.");
        return;
      }

      // WAV einlesen
      float[] samples;
      int sampleRate;
      //using (var reader = new AudioFileReader(inputWav))
      //{
      Audiodatei = new ASDatei(inputWav);
      sampleRate = (int)Audiodatei.SRate;
      var allSamples = new System.Collections.Generic.List<float>();
      // float[] buffer = new float[sampleRate * Audiodatei.Chan];
      bool ende;
      do
      {
        float f;
        (f, ende) = Audiodatei.ReadNextMono();
        allSamples.Add(f);
      } while (!ende);
      samples = allSamples.ToArray();
      //}

      Console.WriteLine($"Samples: {samples.Length}, SampleRate: {sampleRate}");

      // Dauer pro Zeile grob schätzen (z.B. 1 Minute pro Bild / Anzahl Zeilen etc.)
      // Hier: wir nehmen einfach eine fixe Zeilenzeit, z.B. 0.5 s pro Zeile (anpassen!)
      int samplesPerLine = (int)(secondsPerLine * sampleRate);

      if (samplesPerLine < 1)
      {
        Console.WriteLine("Ungültige Zeilenlänge.");
        return;
      }

      int totalLines = Math.Min(MaxLines, samples.Length / samplesPerLine);
      if (totalLines < 1)
      {
        Console.WriteLine("Zu wenig Daten für eine Zeile.");
        return;
      }

      Console.WriteLine($"Erzeuge Bild mit {totalLines} Zeilen à {ImageWidth} Pixel.");

      using (var bmp = new Bitmap(ImageWidth, totalLines, PixelFormat.Format24bppRgb))
      {
        for (int line = 0; line < totalLines; line++)
        {
          int lineStart = line * samplesPerLine;

          for (int x = 0; x < ImageWidth; x++)
          {
            int pixelStart, pixelEnd, gray, windowLength;
            double energyBlack, ratio, energyWhite;
            Color c;
            // Fenster für diesen Pixel
            pixelStart = lineStart + x * samplesPerLine / ImageWidth;
            pixelEnd = lineStart + (x + 1) * samplesPerLine / ImageWidth;
            if (pixelEnd > samples.Length)
              pixelEnd = samples.Length;
            if (pixelEnd <= pixelStart)
              pixelEnd = pixelStart + 1;
            windowLength = pixelEnd - pixelStart;

            energyBlack = GoertzelOptimized(samples, pixelStart, windowLength, sampleRate, FreqBlack);
            energyWhite = GoertzelOptimized(samples, pixelStart, windowLength, sampleRate, FreqWhite);

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

    // Goertzel-Algorithmus zur Energie-Messung einer bestimmten Frequenz
    static double GoertzelOptimized(float[] samples, int start, int length, int sampleRate, double targetFreq)
    {
      int end;
      double omega, sine, cosine, coeff, real, imag;
      double q0, q1, q2;
      omega = 2.0 * Math.PI * targetFreq / (double)sampleRate;
      sine = Math.Sin(omega);
      cosine = Math.Cos(omega);
      coeff = 2.0 * cosine;

      q0 = 0.0;
      q1 = 0.0;
      q2 = 0.0;

      end = Math.Min(start + length, samples.Length);

      for (int i = start; i < end; i++)
      {
        q0 = samples[i] + coeff * q1 - q2;
        q2 = q1;
        q1 = q0;
      }

      // Real- und Imaginärteil des DFT-Bins
      real = q1 - q2 * cosine;
      imag = q2 * sine;

      return real * real + imag * imag; // Energie
    }
    /*
     static double Goertzel(float[] samples, int start, int length, int sampleRate, double targetFreq)
     {
       double sPrev = 0.0;
       double sPrev2 = 0.0;

       double omega = 2.0 * Math.PI * targetFreq / sampleRate;
       double coeff = 2.0 * Math.Cos(omega);

       int end = Math.Min(start + length, samples.Length);

       for (int i = start; i < end; i++)
       {
         double s = samples[i] + coeff * sPrev - sPrev2;
         sPrev2 = sPrev;
         sPrev = s;
       }

       double power = sPrev2 * sPrev2 + sPrev * sPrev - coeff * sPrev * sPrev2;
       return power;
     }
     static double Goertzel2(float[] samples, int start, int length, int sampleRate, double targetFreq)
     {
       double sPrev = 0.0;
       double sPrev2 = 0.0;

       double k = 0.5 + ((double)length * targetFreq) / (double)sampleRate;
       int kInt = (int)k;
       //      double omega = (2.0 * Math.PI * kInt) / length;
       double omega = (2.0 * Math.PI * k) / (double)length;
       double coeff = 2.0 * Math.Cos(omega);

       int end = start + length;
       if (end > samples.Length)
         end = samples.Length;

       for (int i = start; i < end; i++)
       {
         double s;
         s = samples[i] + coeff * sPrev - sPrev2;
         sPrev2 = sPrev;
         sPrev = s;
       }

       double power = sPrev2 * sPrev2 + sPrev * sPrev - coeff * sPrev * sPrev2;
       return power;
     }
    */
  }
}

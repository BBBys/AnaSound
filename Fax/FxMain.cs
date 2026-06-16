
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

//using System.Drawing.Imaging;
//using System.Drawing.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fax
{
  internal class WeatherFaxDecoder
  {

    // Typische WEFAX-Frequenzen (anpassen, falls dein Sender andere nutzt)
   const double FreqBlack = 541;// 1500.0;  // "schwarz"
   const double FreqWhite = 627;// 2300.0;  // "weiß"
//    const double FreqBlack =  1500.0;  // "schwarz"
  //  const double FreqWhite =  2300.0;  // "weiß"

    // Bildparameter – hier kannst du experimentieren
    const int ImageWidth = 1024;      // Pixel pro Zeile
    const int MaxLines = 2000;      // maximale Zeilenanzahl (wird ggf. früher beendet)

    static void Main(string[] args)
    {
      if (args.Length < 2)
      {
        Console.WriteLine("Verwendung: WeatherFaxDecoder <input.wav> <output.png>");
        return ;
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
      using (var reader = new AudioFileReader(inputWav))
      {
        sampleRate = reader.WaveFormat.SampleRate;
        var allSamples = new System.Collections.Generic.List<float>();
        float[] buffer = new float[reader.WaveFormat.SampleRate * reader.WaveFormat.Channels];
        int read;
        while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
        {
          for (int i = 0; i < read; i += reader.WaveFormat.Channels)
          {
            // Mono: ersten Kanal nehmen
            allSamples.Add(buffer[i]);
          }
        }
        samples = allSamples.ToArray();
      }

      Console.WriteLine($"Samples: {samples.Length}, SampleRate: {sampleRate}");

      // Dauer pro Zeile grob schätzen (z.B. 1 Minute pro Bild / Anzahl Zeilen etc.)
      // Hier: wir nehmen einfach eine fixe Zeilenzeit, z.B. 0.5 s pro Zeile (anpassen!)
      double secondsPerLine = 0.5; // TODO: an dein Signal anpassen
      int samplesPerLine = (int)(secondsPerLine * sampleRate);

      if (samplesPerLine <= 0)
      {
        Console.WriteLine("Ungültige Zeilenlänge.");
        return;
      }

      int totalLines = Math.Min(MaxLines, samples.Length / samplesPerLine);
      if (totalLines <= 0)
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
            // Fenster für diesen Pixel
            int pixelStart = lineStart + x * samplesPerLine / ImageWidth;
            int pixelEnd = lineStart + (x + 1) * samplesPerLine / ImageWidth;
            if (pixelEnd > samples.Length)
              pixelEnd = samples.Length;
            if (pixelEnd <= pixelStart)
              pixelEnd = pixelStart + 1;
            int windowLength = pixelEnd - pixelStart;

            double energyBlack = Goertzel(samples, pixelStart, windowLength, sampleRate, FreqBlack);
            double energyWhite = Goertzel(samples, pixelStart, windowLength, sampleRate, FreqWhite);

            // Helligkeit aus Verhältnis ableiten
            double ratio = energyWhite / (energyBlack + energyWhite + 1e-9);
            int gray = (int)(ratio * 255.0);
            if (gray < 0)
              gray = 0;
            if (gray > 255)
              gray = 255;

            Color c = Color.FromArgb(gray, gray, gray);
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
    static double Goertzel(float[] samples, int start, int length, int sampleRate, double targetFreq)
    {
      double sPrev = 0.0;
      double sPrev2 = 0.0;

      double k = 0.5 + (length * targetFreq) / sampleRate;
      int kInt = (int)k;
      double omega = (2.0 * Math.PI* kInt) / length;
      double coeff = 2.0 * Math.Cos(omega);

      int end = start + length;
      if (end > samples.Length)
        end = samples.Length;

      for (int i = start; i < end; i++)
      {
        double s = samples[i] + coeff * sPrev - sPrev2;
        sPrev2 = sPrev;
        sPrev = s;
      }

      double power = sPrev2*  sPrev2 + sPrev * sPrev - coeff*  sPrev* sPrev2;
      return power;
    }
  }
}

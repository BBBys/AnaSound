using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASHilfen
{
  public class Goertzel
  {
    public Goertzel()
    {
    }
    /// <summary>
    /// Goertzel-Algorithmus zur Energie-Messung einer bestimmten Frequenz
    /// </summary>
    /// <param name="samples"></param>
    /// <param name="start"></param>
    /// <param name="length"></param>
    /// <param name="sampleRate"></param>
    /// <param name="targetFreq"></param>
    /// <returns></returns>
    public static double Energie(
      float[] samples,
      ulong start,
      ulong length,
      ulong sampleRate,
      double targetFreq)
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

  }
}

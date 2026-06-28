using System;

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
    /// <param name="samples">das gesamte Signal, von dem ein Abschnitt ausgewertet wird</param>
    /// <param name="start">Punkt im Signal, wo Abschnitt beginnt</param>
    /// <param name="length">Läne des Abschnitts</param>
    /// <param name="sampleRate"></param>
    /// <param name="testFreq">Frequenz, für die ausgewertet wird</param>
    /// <returns>Energie bei der Frequenz in diesem Abschnitt</returns>
    public static double Energie(
      float[] samples,
      ulong sampleRate,
      double testFreq)
    {
      return Energie(samples, 0, (ulong)samples.Length, sampleRate, testFreq);
    }
    public static double Energie(
      float[] samples,
      ulong start,
      ulong length,
      ulong sampleRate,
      double testFreq)
    {
      /*      Algorithmus
        q(N + 2) = q(N + 1) = 0
        Für i = N,...,1 
          q(i) = s(i) + 2 q(i + 1) cos(omega) - q(i + 2)
          also bis 1
        dann 0:
        C = s(0) + 2 q(1) cos(omega) - q(2)
        S = q1 sin(omega)
      */
      ulong end;
      double omega, sinOmega, cosOmega, cosOmega2, real, imag;
      double q0, q1, q2;
      omega = 2.0 * Math.PI * testFreq / (double)sampleRate;
      sinOmega = Math.Sin(omega);
      cosOmega = Math.Cos(omega);
      cosOmega2 = 2.0 * cosOmega;

      q0 = 0.0;
      q1 = 0.0;
      q2 = 0.0;

      //end = Math.Min(start + length, samples.Length);
      end = start + length;
      if ((int)end > samples.Length)
        end = (ulong)samples.Length;
      /*---
       * rückwärts:
       */
      for (ulong i = end - 1; i >= start + 1; i--)
      {
        q0 = samples[i] + cosOmega2 * q1 - q2;
        q2 = q1;
        q1 = q0;
      }
      // Real- und Imaginärteil des DFT-Bins
      real = samples[start] + q1 * cosOmega - q2;
      imag = q1 * sinOmega;

      return real * real + imag * imag; // Energie
      /*
      *
      for (ulong i = start; i < end; i++)
      {
        q0 = samples[i] + cosOmega2 * q1 - q2;
        q2 = q1;
        q1 = q0;
      }
      return q1 * q1 + q2 * q2 - (cosOmega2 * q1 * q2);
      */
    }

  }
}

using NAudio.Dsp;
using System;

namespace AnaSound
{
  public static class Methoden
  {
    /// <summary>
    /// Ein Spektrum berechnen
    /// </summary>
    /// <param name="signal"></param>
    /// <param name="spektrum"></param>
    /// <param name="fenster"></param>
    /// <param name="exponent"></param>
    public static void EinSpektrumBerechnen(
      double[] signal,
      Complex[] spektrum,
      double[] fenster,
      int exponent)
    {
      int länge = 1 << exponent;
      if (spektrum.Length < länge || fenster.Length < spektrum.Length)
      {
        throw new ArgumentOutOfRangeException("Feld Spektrum oder Fenster zu kurz");
      }
      //ein Spektrum berechnen
      for (int i = 0; i < länge; i++)
      {
        spektrum[i].X = (i < signal.Length) ? (float)(fenster[i] * signal[i]) : 0;
        spektrum[i].Y = 0;
      }
      FastFourierTransform.FFT(true, exponent, spektrum);
    }
  }
}

using System;
using System.Diagnostics;

namespace ASHilfen
{
  /// <summary>
  /// Quelle: 
  /// - Meyer (2014), S. 193
  /// - Fensterfunktion, Wikipedia 
  ///   https://de.wikipedia.org/w/index.php?title=Fensterfunktion&oldid=240252100
  /// </summary>
  public class FensterFktn : IDisposable
  {
    public enum FensterTyp
    {
      None, Cos2,
      /// <summary>
      /// größten Nebenkeulen maximal unterdrückt
      /// </summary>
      Hamming,
      /// <summary>
      /// stärkere Unterdrückung der Nebenkeulen, Reduktion der Frequenzauflösung
      /// </summary>
      Hanning,
      Blackman,
      /// <summary>
      /// bessere Unterdrückung der Nebenkeulen
      /// </summary>
      BlackmanHarris,
      /// <summary>
      /// besste Unterdrückung der Nebenkeulen
      /// </summary>
      BlackmanNuttall
    }
    public ulong dieLänge { get; private set; }
    public FensterTyp derTyp { get; private set; }

    private double[] dasFenster;
    /// <summary>
    /// gib das gewünschte Fenster zurück
    /// </summary>
    /// <returns>die Werte des Fensters</returns>
    public double[] Fenster()
    {
      dasFenster = new double[dieLänge];
      for (uint i = 0; i < dieLänge; i++)
      {
        dasFenster[i] = FensterWert(i);
      }
      return dasFenster;
    }
    public double[] FensterEin()
    {
      dasFenster = new double[dieLänge];
      for (uint i = 0; i < dasFenster.Length; i++)
      {
        dasFenster[i] = FensterWert(i * 0.5);
      }
      return dasFenster;
    }
    public double[] FensterAus()
    {
      dasFenster = new double[dieLänge];
      for (uint i = 0; i < dasFenster.Length; i++)
      {
        dasFenster[i] = FensterWert((dasFenster.Length - i - 1) * 0.5);
      }
      return dasFenster;
    }

    /// <summary>
    /// gibt für das voreingestellte Fenster den Wert an der Position i zurück
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public double FensterWert(double i)
    {
      double a0, a1, a2, a3, c, fw;
      double p1Dl1 = Math.PI / (dieLänge - 1);
      double p2Dl1 = p1Dl1 + p1Dl1; // 2 Pi / l-1: von 0 bis 2 pi
      double p4Dl1 = p2Dl1 + p2Dl1; // 4 Pi / l-1: von 0 bis 4 pi
      double p6Dl1 = p4Dl1 + p2Dl1; // 6 Pi / ...
      switch (derTyp)
      {
        case FensterTyp.Cos2:
          /* 
           * p1Dl1*i         von 0 über pi/2 bis pi
           * cos(p1Dl1*i)    von 1 über 0    bis -1
           * cos²(p1Dl1*i)   von 1 über 0    bis 1
           * 1-cos²(p1Dl1*i) von 0 über 1    bis 0
           */
          c = Math.Cos(p1Dl1 * i);
          fw = 1.0 - (c * c);
          break;
        case FensterTyp.Hamming:
          /* 0.54 - 0.46 * cos(n * 2pi/l-1)
           * p1Dl1*i      von 0 über pi bis 2 pi
           * cos(p1Dl1*i) von 1 über -1 bis 1
           */
          fw = 0.54 - (0.46 * Math.Cos(p2Dl1 * i));
          break;
        case FensterTyp.Hanning:
          /* oder von Hann-Fenster
           * 0.5 * [1.0 - cos(n * 2pi/l-1 )]
           * p1Dl1*i      von 0 über pi bis 2 pi
           * cos(p1Dl1*i) von 1 über -1 bis 1
           */
          fw = 0.5 * (1.0 - Math.Cos(p2Dl1 * i));
          break;
        case FensterTyp.Blackman:
          /* a0 - a1 * cos(n * 2pi/l-1) + a2 * cos(n * 4pi/l-1)
           * a0 = 0.5 * (1-alpha)
           * a1 = 0.5
           * a2 = 0.5 * alpha
           * alpha üblich = 0.16
          */
          double alpha = 0.16;
          a0 = 0.5 * (1 - alpha);
          a1 = 0.5;
          a2 = 0.5 * alpha;
          fw = a0
              - (a1 * Math.Cos(p2Dl1 * i))
              + (a2 * Math.Cos(p4Dl1 * i));
          break;
        case FensterTyp.BlackmanHarris:
          /* a0 - a1 * cos(n * 2pi/l-1) + a1 * cos(n * 4pi/l-1) - a3 * cos(n * 6pi/l-1)
          */
          a0 = 0.35875;
          a1 = 0.48829;
          a2 = 0.14128;
          a3 = 0.01168;
          fw = a0
              - (a1 * Math.Cos(p2Dl1 * i))
              + (a2 * Math.Cos(p4Dl1 * i))
              - (a3 * Math.Cos(p6Dl1 * i));
          break;
        case FensterTyp.BlackmanNuttall:
          /* a0 - a1 * cos(n * 2pi/l-1) + a2 * cos(n * 4pi/l-1) - a3 * cos(n * 6pi/l-1)
                  */
          a0 = 0.3635819;
          a1 = 0.4891775;
          a2 = 0.1365995;
          a3 = 0.0106411;
          fw = a0
              - (a1 * Math.Cos(p2Dl1 * i))
              + (a2 * Math.Cos(p4Dl1 * i))
              - (a3 * Math.Cos(p6Dl1 * i));
          break;
        case FensterTyp.None:
        default:
          fw = 1;
          break;
      }
      Debug.Assert(fw >= 0.0, $"FensterWert {i} < 0");
      return fw;
    }

    /// <summary>
    /// bereitet die Fensterfunktion der Länge n vom Typ t vor
    /// </summary>
    /// <param name="n">Länge, max 4,3 Milliarden</param>
    /// <param name="t"></param>
    public FensterFktn(ulong n, FensterTyp t)
    {
      derTyp = t;
      dieLänge = n;
    }
    public void Dispose()
    {
      dasFenster = null;
    }
  }
}

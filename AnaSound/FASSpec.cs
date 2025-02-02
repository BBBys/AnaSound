using ASHilfen;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace AnaSound
{
  public partial class FASSpec : Form
  {private bool kHz5 = false;private int nMittel = 1;
    private    int FFTExp = 9;private double ÜberlappAnteil=5.0/6.0;
    private readonly ASDatei AudioDatei = null;
    private readonly LineSeries Linie = new LineSeries();
    private readonly PlotModel myModel = null;
    private FensterFktn.FensterTyp FenTyp = FensterFktn.FensterTyp.BlackmanNuttall;
    public FASSpec()
    {
      InitializeComponent();
      myModel = new PlotModel();
    }

    public FASSpec(ASDatei audioDatei) : this()
    {
      AudioDatei = audioDatei;
    }

    private void FASSpec_Shown(object sender, EventArgs e)
    {
      Text = $"{AudioDatei.Name}, {AudioDatei.SRate / 1000} kHz ";
      ZeichneSpektrogramm();
    }

    private void ZeichneSpektrogramm()
    {
      #region Parameter
      double HzProLinie;
      int nSpectren, nach, von, lFFT, überlp;
      lFFT = 1 << FFTExp;
       //soviel bleibt beim Nachladen erhalten
     überlp =(int)Math.Round( (1.0-ÜberlappAnteil) *(double) lFFT );
      int nanzahl;
      int maxAnzahl = (int)((double)AudioDatei.NSpl / (double)(überlp) / (double)nMittel);
      bool ende;
      /// <summary> 
      /// Signalabschnitt, über den gerechnet wird.
      /// Diesmal kein Ringpuffer, sondern immer wieder nach vorne schieben
      /// </summary>  
      double[] signal = new double[lFFT];
      NAudio.Dsp.Complex[] data = new NAudio.Dsp.Complex[lFFT];
      double[] summierteSpektren = new double[lFFT / 2];
      double[,] spgram = new double[maxAnzahl, (lFFT / 2)-1];// 0 Hz weglassen
      double[] fenster;
      fenster =
         new FensterFktn((uint)lFFT, FenTyp)
         .Fenster();
      HzProLinie = (double)AudioDatei.SRate / lFFT;
      #endregion
      #region Berechnung
      // erstes Einlesen der Daten
      AudioDatei.Reset();
      ende = AudioDatei.AbschnittLesen(signal, signal.Length);
      nanzahl = 0;
      do
      {
        Debug.Assert(!ende, "do-while noch kein Ende der Datei");
        for (int ib = 0; ib < summierteSpektren.Length; ib++)
          summierteSpektren[ib] = 0;
        nSpectren = 0;
        //Mittel über nMittel Spectrum
        for (int j = 0; j < nMittel; j++)
        {
          Methoden.EinSpektrumBerechnen(signal, data, fenster, FFTExp);
          for (int ib = 0; ib < summierteSpektren.Length; ib++)
            summierteSpektren[ib] +=
              Math.Sqrt((data[ib].X * data[ib].X) + (data[ib].Y * data[ib].Y));
          nSpectren++;
          if (ende)
            break;
          Debug.Assert(!ende, "for noch kein Ende der Datei");
          //Überlappung
          nach = 0;
          von = überlp;
          while (von < signal.Length)
          {
            signal[nach] = signal[von];
            nach++;
            von++;
          }
          //neue Daten einlesen
          ende = AudioDatei.AbschnittLesen(signal, signal.Length, nach);
        }
        for (int ib = 1; ib < summierteSpektren.Length; ib++)//0 Hz weglassen
          spgram[nanzahl, ib-1] = summierteSpektren[ib] / nSpectren;
        nanzahl++;
      } while (!ende && nanzahl < maxAnzahl);
      Text = $"{AudioDatei.Name}, {AudioDatei.SRate / 1000} kHz mit {lFFT / 2}x{nanzahl} Linien";
      Debug.WriteLine($"{AudioDatei.NSpl} Samples");
      Debug.WriteLine($"FFT-Block {lFFT} Samples, Überlappung {überlp}");
      Debug.WriteLine($"je Transformation {überlp} neue Samples");
      Debug.WriteLine($"ergibt {(double)AudioDatei.NSpl / (double)(überlp)} einzelne Spektren");
      Debug.WriteLine($"Mittelung über {nMittel} Spektren");
      Debug.WriteLine($"ergibt {(double)AudioDatei.NSpl / (double)(überlp) / (double)nMittel} dargestellte Spektren");
tslFFT.Text =$"FFT 2^{FFTExp}={lFFT}";
      tslLap.Text = 
        $"Überlappung {(double)(lFFT-überlp)/(double)lFFT:P1} ergibt Auflösung {1000*(double)überlp/(double)AudioDatei.SRate:f1} ms ({(double)AudioDatei.SRate/ (double)überlp:f1} Hz)";
      tslGemittelt.Text = $"gemittelt über {nMittel}";
      tslFq.Text = 
        $"Darstellung {HzProLinie:f1} Hz ... {(AudioDatei.SRate / 2000):f1} kHz";
      tslWin.Text = FenTyp.ToString();
      #endregion
      #region Plot
      Width = 1000;
      Height = 500;
      myModel.Axes.Clear();
      myModel.Series.Clear();
      HeatMapSeries hms = new HeatMapSeries
      {
        X0 = 0,
        X1 = AudioDatei.Dauer,
        Y0 = HzProLinie/1000,
        Y1 = AudioDatei.SRate/2000,
        //Interpolate = true,
        RenderMethod = HeatMapRenderMethod.Bitmap,
        Data = spgram
      };
      myModel.Series.Clear();
      myModel.Series.Add(hms);
      myModel.Axes.Add(new LinearColorAxis
      {
        Position = AxisPosition.Right,
        Palette = OxyPalettes.Rainbow(300)
      });
      myModel.Axes.Add(new LinearAxis
      {
    AbsoluteMaximum = AudioDatei.Dauer,
            AbsoluteMinimum = 0,
      Position = AxisPosition.Bottom,
      Unit = "s",
      Title = "Zeit"
      });
      if (kHz5)
        myModel.Axes.Add(new LogarithmicAxis
        {
          AbsoluteMinimum = HzProLinie/1000,
          AbsoluteMaximum = 5,
          Position = AxisPosition.Left,
          Unit = "kHz",
          Title = "Frequenz"
        });else
      myModel.Axes.Add(new LogarithmicAxis
      {
           AbsoluteMaximum = AudioDatei.SRate / 2000,
        AbsoluteMinimum = HzProLinie / 1000,
        Position = AxisPosition.Left,
        Unit = "kHz",
        Title = "Frequenz"
      });


      plotView1.Model = myModel;
      plotView1.Model.InvalidatePlot(true);
      #endregion
    }

    private void tsb10_Click(object sender, EventArgs e)
    {
      ToolStripButton tsb = (ToolStripButton)sender;
      switch (tsb.Text)
      {
        case "Hamming":
          FenTyp = FensterFktn.FensterTyp.Hamming;
          break;
        case "Blackman-Nuttall":
          FenTyp = FensterFktn.FensterTyp.BlackmanNuttall;
          break;
        case "cos²":
          FenTyp = FensterFktn.FensterTyp.Cos2;
          break;
        case "256":
          FFTExp = 8;
          break;
        case "1024":
          FFTExp = 10;
          break;
        case "4096":
          FFTExp = 12;
          break;
        case "5 kHz":
          kHz5=true;
          break;
        case "1/6":
          ÜberlappAnteil = 1.0 / 6.0;
          break;
        case "1/3":
          ÜberlappAnteil = 1.0 / 3.0;
          break;
        case "-":
          ÜberlappAnteil = 0;
          break;
        case "1x":
          nMittel = 1;
          break;
        case "3x":
          nMittel = 9;
          break;
        case "9x":
          nMittel=9;
          break;
        case "Max.":
          kHz5 = false;
          break;
        case "zeichne":
          myModel.Axes.Clear();
          myModel.Series.Clear();
          ZeichneSpektrogramm();
          break;
        default:
          throw new ArgumentOutOfRangeException(tsb.Text);
      }
    }
  }
}

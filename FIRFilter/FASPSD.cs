using ASHilfen;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Windows.Forms;

namespace AnaSound
{
  public partial class FASPSD : Form
  {
    private readonly ASDatei AudioDatei = null;
    private readonly LineSeries Linie = new LineSeries();
    private readonly PlotModel myModel = null;
    private int FFTExp = 10;
    private FensterFktn.FensterTyp FenTyp = FensterFktn.FensterTyp.BlackmanNuttall;
    public FASPSD()
    {
      InitializeComponent();
      myModel = new PlotModel();
    }

    public FASPSD(ASDatei audioDatei) : this()
    {
      AudioDatei = audioDatei;


    }
    private void ZeichnePSD()
    {
      double f;
      double HzProLinie;
      int nSpectren, nach, von, lFFT, überlp;
      lFFT = 1 << FFTExp;
      überlp = 2 * lFFT / 3;
      /// <summary> 
      /// Signalabschnitt, über den gerechnet wird.
      /// Diesmal kein Ringpuffer, sondern immer wieder nach vorne schieben
      /// </summary>  
      double[] signal = new double[lFFT];
      NAudio.Dsp.Complex[] data = new NAudio.Dsp.Complex[lFFT];
      double[] betragspektrum = new double[lFFT];
      double[] fenster;
      fenster =
         new FensterFktn((uint)lFFT, FenTyp)
         .Fenster();
      Text = $"{AudioDatei.Name}, {AudioDatei.SRate / 1000} kHz PSD mit {lFFT} Linien";
      for (int i = 0; i < lFFT; i++)
        betragspektrum[i] = 0;
      // erstes Einlesen der Daten
      AudioDatei.Reset();
      _ = AudioDatei.AbschnittLesen(signal, lFFT);
      nSpectren = 0;
      do
      {
        Methoden.EinSpektrumBerechnen(signal, data, fenster, FFTExp);
        for (int i = 0; i < lFFT; i++)
        {
          betragspektrum[i] += Math.Sqrt((data[i].X * data[i].X) + (data[i].Y * data[i].Y));
        }
        nSpectren++;
        //Überlappung
        nach = 0;
        von = überlp;
        do
        {
          signal[nach] = signal[von];
          nach++;
          von++;
        }
        while (von < lFFT);
        //neue Daten einlesen
        _ = AudioDatei.AbschnittLesen(signal, lFFT, nach);
      } while (!AudioDatei.Ende());
      HzProLinie = (double)AudioDatei.SRate / lFFT;
      Linie.Points.Clear();
      for (int i = 1; i < lFFT / 2; i++)//Gleichanteil (nach=0, 0 Hz) fehlt bei log-Darstellung
      {
        f = 10 * Math.Log10(betragspektrum[i] / nSpectren);
        Linie.Points.Add(new DataPoint(0.001 * i * HzProLinie, f));
      }
      myModel.Axes.Clear();
      myModel.Axes.Add(new LogarithmicAxis
      {
        Unit = "kHz",
        Position = AxisPosition.Bottom,
        Title = "Frequenz",
        MajorGridlineStyle = LineStyle.Solid,
        // Minimum = HzProLinie,
      });
      myModel.Axes.Add(
        new LinearAxis
        {
          Unit = "dB",
          //    // Minimum = -85,
          //    // Maximum = 0,
          MajorGridlineStyle = LineStyle.Solid,
          MinorGridlineStyle = LineStyle.Dot,
          MajorStep = 20,
          MinorStep = 5,
          Position = AxisPosition.Left,
          Title = "Spektrum"
        });

      myModel.Series.Clear();
      myModel.Series.Add(Linie);
      plotView1.Model = myModel;
      plotView1.Model.InvalidatePlot(true);
      plotView1.Invalidate();
    }

    private void FASPSD_Shown(object sender, EventArgs e)
    {
      Text = $"{AudioDatei.Name}, {AudioDatei.SRate / 1000} kHz ";
      ZeichnePSD();
    }

    private void plotView1_Click(object sender, EventArgs e)
    {
    }

    private void tsb10_Click(object sender, EventArgs e)
    {
      FFTExp = 8;
      ZeichnePSD();
    }

    private void tsb1_Click(object sender, EventArgs e)
    {
      FFTExp = 10;
      ZeichnePSD();
    }

    private void tsb01_Click(object sender, EventArgs e)
    {
      FFTExp = 12;
      ZeichnePSD();
    }

    private void tsb001_Click(object sender, EventArgs e)
    {
      FenTyp = FensterFktn.FensterTyp.Hamming;
      ZeichnePSD();
    }

    private void tsb0001_Click(object sender, EventArgs e)
    {
      FenTyp = FensterFktn.FensterTyp.BlackmanNuttall;
      ZeichnePSD();
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      FenTyp = FensterFktn.FensterTyp.Cos2;
      ZeichnePSD();
    }
  }
}

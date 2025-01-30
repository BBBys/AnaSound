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
    private FensterFktn.FensterTyp FenTyp = FensterFktn.FensterTyp.ftBlackmanNuttall;
    public FASPSD()
    {
      InitializeComponent();
    }

    public FASPSD(ASDatei audioDatei) : this()
    {
      AudioDatei = audioDatei;
      myModel = new PlotModel();

    }
    private void ZeichnePSD()
    {
      double f;
      double HzProLinie;
      int nSpectren, nach, von, lFFT, überlp;
      lFFT = 1 << FFTExp;
      überlp = 2 * lFFT / 3;
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
      AbschnittLesen(AudioDatei, signal, lFFT);
      nSpectren = 0;
      do
      {
        //ein Spektrum berechnen
        for (int i = 0; i < lFFT; i++)
        {
          data[i].X = (float)(fenster[i] * signal[i]);
          data[i].Y = 0;
        }
        NAudio.Dsp.FastFourierTransform.FFT(true, FFTExp, data);
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
        AbschnittLesen(AudioDatei, signal, lFFT, nach);
      } while (!AudioDatei.Ende);
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

    private void AbschnittLesen(ASDatei datei, double[] signal, int lFFT, int start = 0)
    {
      double f;
      float[] fc;
      for (int i = start; i < lFFT; i++)
      {
        if (datei.Ende)
          f = 0;
        else
        {
          fc = datei.ReadNext();
          f = datei.Mono ? fc[0] : ((fc[0] + fc[1]) * 0.5);
        }
        signal[i] = f;
      }
      return;
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
      FenTyp = FensterFktn.FensterTyp.ftHamming;
      ZeichnePSD();
    }

    private void tsb0001_Click(object sender, EventArgs e)
    {
      FenTyp = FensterFktn.FensterTyp.ftBlackmanNuttall;
      ZeichnePSD();
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      FenTyp = FensterFktn.FensterTyp.ftCos2;
      ZeichnePSD();
    }
  }
}

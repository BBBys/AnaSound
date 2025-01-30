using ASHilfen;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Diagnostics;
using System.Windows.Forms;
namespace AnaSound
{
  public partial class FASFFT : Form
  {
    private readonly ASDatei AudioDatei = null;
    private readonly LineSeries Linie = new LineSeries { };
    private readonly PlotModel myModel = null;

    public FASFFT()
    {
      InitializeComponent();
    }

    public FASFFT(ASDatei audioDatei)
    {

      AudioDatei = audioDatei;
      myModel = new PlotModel();

    }
    private void ZeichneFFT()
    {
      double f;
      double HzProLinie;
      int exp = 12;
      int lFFT = 1 << exp;
      NAudio.Dsp.Complex[] data = new NAudio.Dsp.Complex[lFFT];
      double[] fenster =
         new FensterFktn((uint)lFFT, FensterFktn.FensterTyp.ftBlackmanNuttall).Fenster();
      //  double[] fenster = new FensterFktn((uint)lFFT, FensterFktn.FensterTyp.ftBlackman).Fenster();
      AudioDatei.Reset();
      Linie.Points.Clear();
      for (int i = 0; i < lFFT; i++)
      {
        float[] fc;
        if (AudioDatei.Ende)
          f = 0;
        else
        {
          fc = AudioDatei.ReadNext();
          f = AudioDatei.Mono ? fc[0] : ((fc[0] + fc[1]) * 0.5);
        }
        data[i].X = (float)(fenster[i] * f);
        data[i].Y = 0;
      }
      NAudio.Dsp.FastFourierTransform.FFT(true, exp, data);
      HzProLinie = (double)AudioDatei.SRate / lFFT;
      for (int i = 1; i < lFFT / 2; i++)//Gleichanteil (0 Hz) fehlt bei log-Darstellung
      {
        f = 10 * Math.Log10(Math.Sqrt((data[i].X * data[i].X) + (data[i].Y * data[i].Y)));//log von Wurzel = 1/2
        Debug.WriteLine($"{0.001 * i * HzProLinie} kHz,{f} dB");
        Linie.Points.Add(new DataPoint(0.001 * i * HzProLinie, f));
      }
      myModel.Axes.Add(new LogarithmicAxis
      {
        Position = AxisPosition.Bottom,
        Title = "Frequenz [kHz]",
        MajorGridlineStyle = LineStyle.Solid,
        // Minimum = HzProLinie,
      });
      myModel.Axes.Add(
        new LinearAxis
        {
          //    // Minimum = -85,
          //    // Maximum = 0,
          MajorGridlineStyle = LineStyle.Solid,
          //    MinorGridlineStyle = OxyPlot.LineStyle.Dot,
          MajorStep = 20,
          MinorStep = 5,
          Position = AxisPosition.Left,
          Title = "Spektrum [dB]"
        });

      myModel.Series.Clear();
      myModel.Series.Add(Linie);
      Text = $"{AudioDatei.Name}, {AudioDatei.SRate / 1000} kHz FFT mit {lFFT} Linien";
      plotView1.Model = myModel;
      plotView1.Invalidate();
    }

    private void FASFFT_Shown(object sender, EventArgs e)
    {
      ZeichneFFT();
    }
  }
}

using ASHilfen;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Diagnostics;
using System.Windows.Forms;
namespace AnaSound
{
  public partial class FASZeit : Form
  {
    //    private readonly LineSeries linieOben = new LineSeries { }, linieUnten = new LineSeries { };
    private readonly AreaSeries Area = new AreaSeries();
    private readonly PlotModel myModel = null;
    private int Dbcnt = 0;
    //private float[,] Amplitude;
    private readonly ASDatei AudioDatei;
    public FASZeit(ASDatei datei)
    {
      InitializeComponent();
      AudioDatei = datei;
      Text = "Signal";
      //Size = new Size(800, 200);
      myModel = new PlotModel();
    }
    private void Berechne()
    {
      Debug.WriteLine($"Berechne{Dbcnt++}");
      float splmax, splmin;
      uint nPunkte, splx;
      if (AudioDatei == null)
        return;
      //Zeichenpunkte auf Linie
      nPunkte = (uint)(Width * 0.9);
      Debug.Assert(AudioDatei.NSpl > 0);
      Debug.Assert(nPunkte > 0);
      //Samples pro Zeichenpunkt
      splx = (uint)Math.Round(AudioDatei.NSpl / (double)nPunkte);
      AudioDatei.Reset();
      double intervall = splx / (double)AudioDatei.SRate;
      int i = 0;
      ;
      while (!AudioDatei.Ende())//für jedes Sample
      {
        float f;
        float[] fc;// = new float[2];
        splmax = splmin = 0;
        for (int j = 0; j < splx; j++)//so viel Samples
          if (!AudioDatei.Ende())
          {
            fc = AudioDatei.AudioReader.ReadNextSampleFrame();
            f = AudioDatei.Mono ? fc[0] : (fc[0] + fc[1]) * (float)0.5;
            splmax = Math.Max(splmax, f);
            splmin = Math.Min(splmin, f);
          }
        Area.Points.Add(new DataPoint(i * intervall, splmax));
        Area.Points2.Add(new DataPoint(i * intervall, splmin));
        i++;
      }
      myModel.Axes.Add(new LinearAxis
      {
        Unit = "s",
        MajorGridlineStyle = LineStyle.Solid,
        Position = AxisPosition.Bottom,
        Title = "t",
        Minimum = 0
      });
      myModel.Axes.Add(new LinearAxis
      {
        Minimum = -1,
        Maximum = 1,
        MajorGridlineStyle = LineStyle.Solid,
        MinorGridlineStyle = LineStyle.Dot,
        MajorStep = .5,
        MinorStep = .25,
        Position = AxisPosition.Left,
        Title = "Signal"
      });
      Width = 1000;
      Height = 300;
      myModel.Series.Clear();
      myModel.Series.Add(Area);
      //myModel.Series.Add(linieUnten);
      plotView1.Model = myModel;
      plotView1.Invalidate();
    }
    private void FASZeit_Paint(object sender, PaintEventArgs e)
    {

    }
    private void FASZeit_ResizeEnd(object sender, EventArgs e)
    {
      Debug.WriteLine($"RezEnd{Dbcnt++}");
      Berechne();
      Invalidate();
    }
    private void FASZeit_Shown(object sender, EventArgs e)
    {
      Debug.WriteLine($"Shown{Dbcnt++}");
      Berechne();
      Invalidate();
    }
  }
}
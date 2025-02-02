using ASHilfen;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Diagnostics;
using System.Windows.Forms;
namespace AnaSound
{
  public partial class FASPower : Form
  {
    private readonly LineSeries Linie = new LineSeries();
    private readonly PlotModel myModel = null;
    private int Dbcnt = 0;
    private readonly ASDatei AudioDatei = null;
    /// <summary>
    /// Anzahl Power-Punkte im gewünschten Abstand
    /// </summary>
    private ulong nIntervalle;
    /// <summary>
    /// Dauer des Intervalls, über das gemittelt wird
    /// </summary>
    private double DauerIntervall = 0;
    public FASPower()
    {
      InitializeComponent();
    }
    public FASPower(ASDatei paudio) : this()
    {
      AudioDatei = paudio;
      myModel = new PlotModel();
      myModel.Axes.Add(new LinearAxis
      {
        MajorGridlineStyle = LineStyle.Solid,
        Unit = "s",
        Position = AxisPosition.Bottom,
        Title = "t",
        Minimum = 0
      });
      myModel.Axes.Add(
        new LinearAxis
        {
          Unit = "dB",
          Minimum = -85,
          Maximum = 0,
          MinorGridlineStyle = LineStyle.Dot,
          MajorStep = 20,
          MinorStep = 5,
          Position = AxisPosition.Left,
          Title = "Signalleistung"
        });
    }
    //private void Zeichne(PaintEventArgs pea)
    //{
    //}
    private void Berechne()
    {
      Berechne(DauerIntervall);
    }

    /// <summary>
    /// Abschnittsweise Berechnung der Leistung
    /// </summary>
    /// <param name="pintv">Intervalldauer, über die gemittelt werden soll in s</param>
    private void Berechne(double pintv)
    {
      int NrSampleAusDatei;
      if (pintv < .0001)
        return;
      if (AudioDatei == null)
        return;
      /// <summary>
      /// soviel Zeichen-Punkte stehen geschätzt zur Verfügung
      /// </summary>
      /// <summary>
      /// Samples im Berechnungsintervall
      /// </summary>
      uint nSplIntervall;
      Debug.WriteLine($"Berechne{Dbcnt++}");
      /// <summary>
      /// Dauer, über die AKF berechnet wird, in s
      /// </summary>
      DauerIntervall = pintv;
      Debug.WriteLine($"Berechnung in Intervallen von {DauerIntervall} s");
      int NrAbschnitt = 0;
      nIntervalle = (ulong)Math.Ceiling(AudioDatei.Dauer / DauerIntervall);
      nSplIntervall = (uint)Math.Round(AudioDatei.SRate * DauerIntervall);
      Debug.WriteLine($"Anzahl Berechnungsintervalle={nIntervalle}\nLänge je {nSplIntervall} Samples");
      AudioDatei.Reset();
      Linie.Points.Clear();
      double p = 0;
      NrSampleAusDatei = 0;
      while (!AudioDatei.Ende())//für ganze Datei
      {
        float f;
        float[] fc;// = new float[2];
        /// ein Intervall
        for (int NrSampleImIntervall = 0; NrSampleImIntervall < nSplIntervall; NrSampleImIntervall++)//so viel Samples zusammenfassen im Intervall
        {
          if (!AudioDatei.Ende())
          {
            fc = AudioDatei.AudioReader.ReadNextSampleFrame();
            f = AudioDatei.Mono ? fc[0] : (float)((fc[0] + fc[1]) * 0.5);
            p += f * f;
            NrSampleAusDatei++;
          }
        }
        p /= nSplIntervall;
        f = (p > 0) ? (float)(10.0 * Math.Log10(p)) : (float)-60.0;
        Linie.Points.Add(new DataPoint(NrAbschnitt * DauerIntervall, f));

        Debug.WriteLine($"Abschnitt {NrAbschnitt} Sample {NrSampleAusDatei} Zeit {NrAbschnitt * DauerIntervall}");
        NrAbschnitt++;
      }
      Width = 1000;
      Height = 300;
      myModel.Series.Clear();
      myModel.Series.Add(Linie);
      Zeichnung.Model = myModel;
      Zeichnung.Invalidate();
    }

    private void FASPower_Paint(object sender, PaintEventArgs e)
    {

    }

    private void FASPower_Resize(object sender, EventArgs e)
    {
      Berechne();
      //Zeichne();
    }

    //private void RechnePowerData(ASDatei audio)
    //{
    //  Berechne(DauerIntervall);
    //}

    private void tsb10_Click(object sender, EventArgs e)
    {
      Berechne(10);
      Invalidate();
    }

    private void tsb1_Click(object sender, EventArgs e)
    {
      Berechne(1);
      Invalidate();
    }

    private void tsb01_Click(object sender, EventArgs e)
    {
      Berechne(0.1);
      Invalidate();
    }

    private void tsb001_Click(object sender, EventArgs e)
    {
      Berechne(0.01);
      Invalidate();
    }

    private void tsb0001_Click(object sender, EventArgs e)
    {
      Berechne(0.001);
      Invalidate();
    }

    private void button1_Click(object sender, EventArgs e)
    {


    }

    private void FASPower_ResizeEnd(object sender, EventArgs e)
    {
      Berechne();
      Invalidate();
    }
  }
}
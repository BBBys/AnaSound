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
  public partial class FASAKF : Form
  {
    private enum AKFTyp { amKein, amZeit, amWeg, amFrequenz };
    private AKFTyp akfTyp = AKFTyp.amKein;
    private readonly LineSeries Linie = new LineSeries { };
    private readonly PlotModel myModel = null;
    private readonly ASDatei AudioDatei = null;
    /// <summary>
    /// Anzahl AKF-Werte für die gewünschte Dauer zu berechnen/zeichnen
    /// </summary>
    private ulong nLagsAkf;

    /// <summary>
    /// Signalabschnitt, doppelte Länge, mit 0 aufgefüllt
    /// </summary>
    private float[] ringPuffer = null;
    private float[] AKFData = null;
    private float[] AKFTeil = null;
    // private float[] AKFZeit = null;
    private float akfWert;
    /// <summary>
    /// Dauer der AKF-Funktion
    /// </summary>
    private double DauerIntervall = 0;
    public FASAKF()
    {
      InitializeComponent();
      myModel = new PlotModel();
    }
    public FASAKF(ASDatei paudio) : this()
    {
      AudioDatei = paudio;
    }
    //private void Berechne()
    //{
    //  Berechne(DauerIntervall);
    //}

    /// <summary>
    /// Abschnittsweise Berechnung der AKF
    /// </summary>
    /// <param name="pDauer">Intervalldauer in s</param>
    /// 
    private void Berechne(double pDauer)
    {
      if (pDauer < .0001)
        return;
      if (AudioDatei == null)
        return;
      ulong nRingPuffer, PufferZeiger;
      float nAKFsBerechnet;
      DauerIntervall = pDauer;
      nLagsAkf = (uint)Math.Ceiling(AudioDatei.SRate * DauerIntervall);
      nRingPuffer = 2 * nLagsAkf;
      ringPuffer = new float[nRingPuffer];
      AKFData = new float[nLagsAkf];
      AKFTeil = new float[nLagsAkf];
      AudioDatei.Reset();
      nAKFsBerechnet = 0;
      ///Puffer vorbelegen
      for (ulong i = 0; i < nRingPuffer; i++)//Signal einlesen
        ringPuffer[i] = AudioDatei.ReadNextMono();
      Debug.WriteLine(ringPuffer.Sum() / nRingPuffer);
      //for Ringpuffer vorbelegen
      //Puffer ist voll
      //Signal beginnt bei 0
      PufferZeiger = 0;
      //AKF Berechnen, jedes Lag ein Punkt
      do
      {
        ///für jedes Lag
        for (ulong lag = 0; lag < nLagsAkf; lag++)
        {
          akfWert = 0;
          for (ulong SignalPunkt = 0; SignalPunkt < nLagsAkf; SignalPunkt++)
          {
            /*
             * für lag=0, SignalPunkt=0...Lags-1:
             * 0*0 + 1*1 + 2*2 + 3*3 + 4*4 + 5*5 + 6*6 + 7*7 + 8*8 + 9*9 ...
             * und unter 0 speichern
             * für lag = 1, SignalPunkt=0...Lags - 1:
             * 0 * 1 + 1 * 2 + 2 * 3 + 3 * 4 + ...
             * und unter 1 speichern
             * für lag = 2, SignalPunkt=0...Lags - 1:
             * 0 * 2 + 1 * 3 + 2 * 4 + 3 * 5 + ...
             * und unter 2 speichern
             * aber alles noch mal verschoben zum Pufferzeiger
             * und bei Überlauf modulo nRingPuffer
             */
            akfWert +=
              ringPuffer[(SignalPunkt + PufferZeiger) % nRingPuffer] *
              ringPuffer[(lag + SignalPunkt + PufferZeiger) % nRingPuffer];
          }
          AKFTeil[lag] = akfWert;
        }//for über lag alle AKF-Punkte berechnen
        ///berechnete AKF speichern
        //for (ulong lag = 0; lag < nLagsAkf; lag++)
        //  AKFData[lag] += AKFTeil[lag];
        AKFData = AKFData.Zip(AKFTeil, (a, b) => a + b).ToArray();
        nAKFsBerechnet++;
        for (ulong nWeiter = 0; nWeiter < nLagsAkf; nWeiter++)
        {
          //und jeweils einen Signalwert weiter, dazu:
          //den Wert vorne überschreiben
          ringPuffer[PufferZeiger] = AudioDatei.ReadNextMono();
          //dann den Anfangspunkt eins weiter und
          //der neue Wert wird der Letzte in der Kette
          PufferZeiger = (PufferZeiger + 1) % nRingPuffer;
        }
      } while (!AudioDatei.Ende());
      Width = 1000;
      Height = 300;
      Text = $"AKF über {DauerIntervall} s ({nLagsAkf} Samples), Mittel aus {nAKFsBerechnet} Berechnungen";
      //for (ulong lag = 0; lag < nLagsAkf; lag++)
      //  AKFData[lag] /= nAKFsBerechnet;
      AKFData = AKFData.Select(x => x / nAKFsBerechnet).ToArray();
      Zeichne(AKFData, akfTyp);
    }
    private void Zeichne(float[] daten, AKFTyp at)
    {
      Linie.Points.Clear();
      double faktor;
      switch (at)
      {
        case AKFTyp.amFrequenz:
          faktor = AudioDatei.SRate;
          break;
        case AKFTyp.amWeg:
          faktor = AudioDatei.Schallgewindigkeit / AudioDatei.SRate;
          break;
        case AKFTyp.amZeit:
          faktor = 1.0 / AudioDatei.SRate;
          break;
        case AKFTyp.amKein:
          faktor = 1;
          break;
        default:
          throw new ArgumentOutOfRangeException("AKF-Typ", at.ToString());
      }
      for (int lag = 0; lag < daten.Length; lag++)
        if (at == AKFTyp.amFrequenz)
        { if (lag > 0) Linie.Points.Add(new DataPoint(faktor / lag, daten[lag])); }
        else
        { Linie.Points.Add(new DataPoint(faktor * lag, daten[lag])); }
      myModel.Series.Clear();
      myModel.Series.Add(Linie);
      setAxes(at);
      plotView1.Model = myModel;
      plotView1.Model.InvalidatePlot(true);
      //  plotView1.Invalidate();
    }
    private void setAxes(AKFTyp amt = AKFTyp.amKein)
    {
      myModel.Axes.Clear();
      switch (amt)
      {
        case AKFTyp.amWeg:
          myModel.Axes.Add(new LinearAxis
          {
            MajorGridlineStyle = LineStyle.Solid,
            Unit = "m",
            Position = AxisPosition.Bottom,
            Title = "Laufzeit",
          });
          break;
        case AKFTyp.amZeit:
          myModel.Axes.Add(new LinearAxis
          {
            MajorGridlineStyle = LineStyle.Solid,
            Unit = "s",
            Position = AxisPosition.Bottom,
            Title = "Lagzeit",
          });
          break;
        case AKFTyp.amKein:
          myModel.Axes.Add(new LinearAxis
          {
            MajorGridlineStyle = LineStyle.Solid,
            Position = AxisPosition.Bottom,
            Title = "Lag Nr.",
          });
          break;
        default:
          break;
      }
      myModel.Axes.Add(
  new LinearAxis
  {
    MajorGridlineStyle = LineStyle.Solid,
    MinorGridlineStyle = LineStyle.Dot,
    Position = AxisPosition.Left,
    Title = "AKF"
  });
      //  myModel.ResetAllAxes();
    }

    //private void FASAKF_Paint(object sender, PaintEventArgs e)
    //{
    //}
    private void tsb10_Click(object sender, EventArgs e)
    {
      Berechne(10);
    }

    private void tsb1_Click(object sender, EventArgs e)
    {
      Berechne(1);
    }

    private void tsb01_Click(object sender, EventArgs e)
    {
      Berechne(0.1);
    }

    private void tsb001_Click(object sender, EventArgs e)
    {
      Berechne(0.01);
    }

    private void tsb0001_Click(object sender, EventArgs e)
    {
      Berechne(0.001);
    }

    //private void FASPower_ResizeEnd(object sender, EventArgs e)
    //{
    //}

    private void FASAKF_Shown(object sender, EventArgs e)
    { }

    private void tsbWeg_Click(object sender, EventArgs e)
    {
    }

    private void tsbZeit_Click(object sender, EventArgs e)
    {
    }

    private void tsbFq_Click(object sender, EventArgs e)
    {
      ToolStripButton tsb = (ToolStripButton)sender;
      switch (tsb.Tag)
      {
        case "z":
          akfTyp = AKFTyp.amZeit;
          break;
        case "fq":
          akfTyp = AKFTyp.amFrequenz;
          break;
        case "w":
          akfTyp = AKFTyp.amWeg;
          break;
        default:
          akfTyp = AKFTyp.amKein;
          break;
      }
      Zeichne(AKFData, akfTyp);
    }
  }
}
using ASHilfen;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace AnaSound
{
  public partial class FASKKF : Form
  {
    private enum KKFTyp { amKein, amZeit, amWeg, amFrequenz };
    private KKFTyp kkfTyp = KKFTyp.amKein;
    private readonly LineSeries Linie = new LineSeries { };
    private readonly PlotModel myModel = null;
    private readonly ASDatei AudioDatei = null;
    /// <summary>
    /// Anzahl KKF-Werte für die gewünschte Dauer zu berechnen/zeichnen
    /// </summary>
    private ulong nLagsKkf;

    /// <summary>
    /// Signalabschnitt, doppelte Länge, mit 0 aufgefüllt
    /// 2 Puffer für 2 Kanäle
    /// </summary>
    private float[] ringPuffer1 = null, ringPuffer2 = null;
    private float[] KKFData = null;
    private float[] KKFTeil = null;
    // private float[] KKFZeit = null;
    private float kkfWert;
    /// <summary>
    /// Dauer der KKF-Funktion
    /// </summary>
    private double DauerIntervall = 0;

    public FASKKF()
    {
      InitializeComponent();
      myModel = new PlotModel();
    }
    public FASKKF(ASDatei paudio) : this()
    {
      AudioDatei = paudio;
    }
    /// <summary>
    /// Abschnittsweise Berechnung der KKF
    /// komplett neue Berechnung, danach wird Zeichne(...) aufgerufen
    /// </summary>
    /// <param name="pDauer">Intervalldauer in s</param>
    /// 
    private void Berechne(double pDauer)
    {
      tslOK.Visible = false;
      if (pDauer < .0001)
        return;
      if (AudioDatei == null)
        return;
      ulong nRingPuffer, PufferZeiger;
      float nKKFsBerechnet;
      tslWarten.Visible = true;
      statusStrip1.Refresh();

      DauerIntervall = pDauer;
      nLagsKkf = (uint)Math.Ceiling(AudioDatei.SRate * DauerIntervall);
      nRingPuffer = 2 * nLagsKkf;
      ringPuffer1 = new float[nRingPuffer];
      ringPuffer2 = new float[nRingPuffer];
      KKFData = new float[nLagsKkf];
      KKFTeil = new float[nLagsKkf];
      AudioDatei.Reset();
      nKKFsBerechnet = 0;
      ///Puffer vorbelegen
      for (ulong i = 0; i < nRingPuffer; i++)//Signal einlesen
        (ringPuffer1[i], ringPuffer2[i]) = AudioDatei.ReadNextStereo();
      Debug.WriteLine(ringPuffer1.Sum() / nRingPuffer);
      Debug.WriteLine(ringPuffer2.Sum() / nRingPuffer);
      //for Ringpuffer vorbelegen
      //Puffer ist voll
      //Signal beginnt bei 0
      PufferZeiger = 0;
      //KKF Berechnen, jedes Lag ein Punkt
      do
      {
        ///für jedes Lag
        for (ulong lag = 0; lag < nLagsKkf; lag++)
        {
          kkfWert = 0;
          for (ulong SignalPunkt = 0; SignalPunkt < nLagsKkf; SignalPunkt++)
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
            //todo prüfen, ob modulo richtig ist oder besser nullsetzen und dadurch ausgleiten
            kkfWert +=
              ringPuffer1[(SignalPunkt + PufferZeiger) % nRingPuffer] *
              ringPuffer2[(lag + SignalPunkt + PufferZeiger) % nRingPuffer];
          }
          KKFTeil[lag] = kkfWert;
        }//for über lag alle KKF-Punkte berechnen
        ///berechnete KKF speichern
        //for (ulong lag = 0; lag < nLagsKkf; lag++)
        //  KKFData[lag] += KKFTeil[lag];
        KKFData = KKFData.Zip(KKFTeil, (a, b) => a + b).ToArray();
        nKKFsBerechnet++;
        for (ulong nWeiter = 0; nWeiter < nLagsKkf; nWeiter++)
        {
          //und jeweils einen Signalwert weiter, dazu:
          //den Wert vorne überschreiben
          (ringPuffer1[PufferZeiger], ringPuffer2[PufferZeiger]) = AudioDatei.ReadNextStereo();
          //dann den Anfangspunkt eins weiter und
          //der neue Wert wird der Letzte in der Kette
          PufferZeiger = (PufferZeiger + 1) % nRingPuffer;
        }
      } while (!AudioDatei.Ende());
      Width = 1000;
      Height = 300;
      Text = $"KKF über {DauerIntervall} s ({nLagsKkf} Samples), Mittel aus {nKKFsBerechnet} Berechnungen";
      //for (ulong lag = 0; lag < nLagsKkf; lag++)
      //  KKFData[lag] /= nKKFsBerechnet;
      KKFData = KKFData.Select(x => x / nKKFsBerechnet).ToArray();
      tslWarten.Visible = false;
      Zeichne(KKFData, kkfTyp);
      tslOK.Visible = true;
    }
    private void Zeichne(float[] daten, KKFTyp at)
    {
      Linie.Points.Clear();
      if (daten == null)
        return;
      double faktor;
      switch (at)
      {
        case KKFTyp.amFrequenz:
          faktor = AudioDatei.SRate;
          break;
        case KKFTyp.amWeg:
          faktor = AudioDatei.Schallgewindigkeit / AudioDatei.SRate;
          break;
        case KKFTyp.amZeit:
          faktor = 1.0 / AudioDatei.SRate;
          break;
        case KKFTyp.amKein:
          faktor = 1;
          break;
        default:
          throw new ArgumentOutOfRangeException("KKF-Typ", at.ToString());
      }
      for (int lag = 0; lag < daten.Length; lag++)
        if (at == KKFTyp.amFrequenz)
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
    private void setAxes(KKFTyp amt = KKFTyp.amKein)
    {
      myModel.Axes.Clear();
      switch (amt)
      {
        case KKFTyp.amWeg:
          myModel.Axes.Add(new LinearAxis
          {
            MajorGridlineStyle = LineStyle.Solid,
            Unit = "m",
            Position = AxisPosition.Bottom,
            Title = "Laufzeit",
          });
          break;
        case KKFTyp.amZeit:
          myModel.Axes.Add(new LinearAxis
          {
            MajorGridlineStyle = LineStyle.Solid,
            Unit = "s",
            Position = AxisPosition.Bottom,
            Title = "Lagzeit",
          });
          break;
        case KKFTyp.amKein:
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
    Title = "KKF"
  });
      //  myModel.ResetAllAxes();
    }
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
    private void tsbFq_Click(object sender, EventArgs e)
    {
      ToolStripButton tsb = (ToolStripButton)sender;
      switch (tsb.Tag)
      {
        case "z":
          kkfTyp = KKFTyp.amZeit;
          break;
        case "fq":
          kkfTyp = KKFTyp.amFrequenz;
          break;
        case "w":
          kkfTyp = KKFTyp.amWeg;
          break;
        default:
          kkfTyp = KKFTyp.amKein;
          break;
      }
      Zeichne(KKFData, kkfTyp);
    }

    private void tsb001_Click(object sender, EventArgs e)
    {
      Berechne(0.01);
    }

    private void tsb0001_Click(object sender, EventArgs e)
    {
      Berechne(0.001);
    }

  }
}

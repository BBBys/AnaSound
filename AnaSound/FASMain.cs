using ASHilfen;
using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
namespace AnaSound
{
  public partial class FASMain : Form
  {
    private FInfo Info = null;
    private readonly string DDatei;
    private readonly string DPfad;
    private string WavDateiGewählt;
    private readonly Properties.Settings Props;
    private ASDatei AudioDatei = null;
    private FASPower FPower = null;
    private FASAKF FAKF = null;
    private FASFFT FFFT = null;
    private FASPSD FPSD = null;
    private FASSpec FSpec = null;
    private WaveOutEvent AudioAusgabe = null;
    public FASMain()
    {
      InitializeComponent();
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      string productName = fvi.ProductName;//Assemblyinfo -> Produkt
      string programmName = fvi.FileDescription; //Assemblyinfo -> Titel
      string productVersion = fvi.ProductVersion; //Version  1.2.3.4 
      // nach InitializeComponent:
      Text = programmName + " V" + productVersion + ". ";

#if DEBUG
      Text += "DEBUGVERSION";
#else
      Text += Application.CompanyName + ": " + productName;
#endif

      // Lesen der Einstellungen
      Props = Properties.Settings.Default;
      DDatei = Props.DatenDatei;
      DPfad = Props.DatenPfad;
      /* Schreiben neuer Einstellungen
      Props.DatenDatei = neueDatei;
      Props.DatenPfad = neuerPfad;
      Props.Save();*/
    }

    private void zeichneToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FASZeit fenster = new FASZeit(AudioDatei);
      fenster.Show();
    }


    private void testToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Info?.Dispose();
      Info = new FInfo(AudioDatei);
      Info.Show();
    }

    private void endeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ofdEingabe.FileName = Path.Combine(DPfad, DDatei);
      if (ofdEingabe.ShowDialog() == DialogResult.OK)
      {
        AudioDatei?.Dispose();
        WavDateiGewählt = ofdEingabe.FileName;
        tslDatei.Text = ofdEingabe.SafeFileName;
        Props.DatenDatei = Path.GetFileName(WavDateiGewählt);
        Props.DatenPfad = Path.GetFullPath(WavDateiGewählt);
        Props.Save();
        AudioDatei = new ASDatei(WavDateiGewählt);
        tslFehler.Text = AudioDatei.HatFehler ? AudioDatei.FehlerText : "";
        tslWarnung.Text = AudioDatei.HatWarnung ? AudioDatei.WarnungText : "";
        tslChan.Text = $"{AudioDatei.Chan} Ch";
        tslSr.Text = $"{AudioDatei.SRate / 1000} KHz";
        tslDauer.Text = $"{AudioDatei.DauerGanzeMin}m {AudioDatei.DauerRestSek:f2}s";
        tslBit.Text = $"{AudioDatei.BitProSample} Bit";
        tslEncoding.Text = AudioDatei.Encoding;
        wv1.WaveStream = AudioDatei.AudioReader;
        wv1.PerformAutoScale();
        wv1.Update();
      }
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      About f = new About();
      _ = f.ShowDialog();
      f.Dispose();
    }

    private void zeichneLeistungToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FPower?.Dispose();
      FPower = new FASPower(AudioDatei);
      FPower.Show();
    }

    private void spieleAbToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // using (MemoryStream ms = new MemoryStream(AudioDatei.))
      {
        // WAV-Datei aus dem Stream abspielen
        //using (WaveFileReader reader =AudioDatei.reader)
        AudioAusgabe?.Dispose();
        AudioAusgabe = new WaveOutEvent();
        {
          AudioDatei.Reset();
          AudioAusgabe.Init(AudioDatei.AudioReader);
          AudioAusgabe.Volume = 1;
          AudioAusgabe.Play();
        }
      }
    }

    private void stopToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AudioAusgabe.Stop();
    }

    private void schreibeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      WaveFormat wfmt = new WaveFormat((int)AudioDatei.SRate, 1);

      WaveFileWriter wfw = new WaveFileWriter(Path.Combine(AudioDatei.Pfad, "aus.wav"), wfmt);
      AudioDatei.Reset();
      double apl = 1;
      while (!AudioDatei.Ende())
      {
        float[] fc;
        double f;
        fc = AudioDatei.AudioReader.ReadNextSampleFrame();
        f = AudioDatei.Mono ? fc[0] : fc[0] + fc[1];
        f *= apl;
        apl = (Math.Abs(f) < .75) ? apl * 1.1 : apl * 0.9;
        wfw.WriteSample((float)f);
      }
      wfw.Flush();
      wfw.Dispose();
    }

    private static void Ton()
    {
      WaveFileWriter wfw;
      WaveFormat wfmt;
      ulong rate;
      rate = 11025;
      double spl, fq1, fq2, pirate;
      fq1 = 440;
      fq2 = 3 * fq1 / 2;
      pirate = Math.PI / rate;
      wfmt = new WaveFormat((int)rate, 1);
      wfw = new WaveFileWriter("aus.wav", wfmt);
      for (ulong i = 0; i < 2 * rate; i++)
      {
        double mult = i * pirate;
        spl = .2 * (Math.Cos(fq1 * mult) + Math.Cos(fq2 * mult));
        wfw.WriteSample((float)spl);
      }

    }

    private void apapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //zur Ausgabe
      string ausdat;
      const uint NTAB = 10;
      uint buflen;
      double[] buf;
      double[] a = {0.010051   ,0.024971   ,0.066952   ,0.124887   ,0.175415
          ,0.195448   ,0.175415 ,0.124887   ,0.066952   ,0.024971   ,0.010051};
      double[] f = new double[NTAB];
      uint[] tap = new uint[NTAB];
      int p0;
      double f0, f1;

      double anpassung0 = 0.9;
      _ = 1.0 - anpassung0;
      ulong SR = AudioDatei.SRate; //Samples in 1 sec

      //Puffer
      buflen = (uint)(SR / 10);  // Pufferlänge 100 ms
      buf = new double[buflen];
      for (uint i = 0; i < NTAB; i++)
      {
        a[i] = 1.0 / NTAB;
        tap[i] = i * buflen / NTAB;//Anzapfpunkte, der 1. bei 0
        Debug.WriteLine($"Tap {i} bei {tap[i]}");
      }

      WaveFormat wfmt = new WaveFormat((int)SR, 1);
      ausdat = Path.Combine(AudioDatei.Pfad, "ADAP.wav");
      WaveFileWriter wfw = new WaveFileWriter(ausdat, wfmt);
      AudioDatei.Reset();

      for (int i = 0; i < buflen; i++)
      {
        //Puffer vorbelegen
        //und diese werte unverändert ausgeben
        buf[i] = f0 = get1sample();
        wfw.WriteSample((float)f0);
      }
      p0 = 0;
      while (!AudioDatei.Ende())
      {
        //die werte im Puffer wurden schon ausgegeben
        //anfangen mit dem nächsten
        //Puffernullpunkt ist p0
        f0 = get1sample();
        buf[p0 % buflen] = f0;
        //alter Nullpunkt wird Endpunkt,
        //Puffernullpunkt ist neuer p0
        p0++;
        f1 = 0;
        for (uint i = 0; i < NTAB; i++)
        {
          //Puffer anzapfen, Gewichtung mit Filter
          f[i] = buf[(p0 + tap[i]) % buflen];
          f1 += f[i] * a[i];
          //a[i] = anpassung0 * a[i] + anpassung1 * f1;
          //akfWert[i] = f1;
        }
        wfw.WriteSample((float)f1);
      }

      wfw.Flush();
      wfw.Dispose();
    }

    private double get1sample()
    {
      float[] fc;
      double f;
      fc = AudioDatei.AudioReader.ReadNextSampleFrame();
      f = AudioDatei.Mono ? fc[0] : (fc[0] + fc[1]) * 0.5;
      return f;
    }

    private void schließeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AudioDatei?.Dispose();
      AudioDatei = null;
    }

    private void zeichneAKFToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FAKF?.Dispose();
      FAKF = new FASAKF(AudioDatei);
      FAKF.Show();
    }

    private void tsmFFT_Click(object sender, EventArgs e)
    {
      FFFT?.Dispose();
      FFFT = new FASFFT(AudioDatei);
      FFFT.Show();

    }

    private void tsmPSD_Click(object sender, EventArgs e)
    {
      FPSD?.Dispose();
      FPSD = new FASPSD(AudioDatei);
      FPSD.Show();
    }

    private void testToolStripMenuItem_Click_1(object sender, EventArgs e)
    { }

    private void specgramToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FSpec?.Dispose();
      FSpec = new FASSpec(AudioDatei);
      FSpec.Show();
    }
    /// <summary>
    /// Ein Spektrum berechnen
    /// </summary>
    /// <param name="signal"></param>
    /// <param name="spektrum"></param>
    /// <param name="fenster"></param>
    /// <param name="exponent"></param>
    public void EinSpektrumBerechnen(
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
      NAudio.Dsp.FastFourierTransform.FFT(true, exponent, spektrum);
    }
  }
}
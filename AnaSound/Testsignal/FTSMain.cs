using ASHilfen;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Testsignal.Properties;
namespace Testsignal
{
  public partial class FTSMain : Form
  {
    private ulong SampleRate;
    private uint Kanäle;
    // private readonly WaveFormat wfmt;
    //   private readonly WaveFileWriter wfw;
    private readonly string Signalparameter;
    //private readonly string Dateiname;
    private readonly Settings Props;
    private string DDatei, DPfad;
    private ASDatei AudioDatei;
    private string WavDateiGewählt;
    private float Dauer;
    /// <summary>
    /// Parameter aus Textbox
    /// </summary>
    private double Param1, Param2, Param3, Param4;
    private string Param5;
    private enum signalTyp
    {
      stNull, stSin, stSchweb, stRausch, stKonstant, stKnall, stWobbel,
      st5Ton
    }
    private signalTyp derTyp = signalTyp.stNull;
    public FTSMain()
    {
      /// <summary>
      /// Auswahl Samplerate
      /// </summary>
      RadioButton[] rbsSR = { rb11, rb22, rb44, rb48, rb8 };
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
      Props = Settings.Default;
      DDatei = Props.DatenDatei;
      DPfad = Props.DatenPfad;
      SampleRate = Props.SampleRate;
      Kanäle = Props.Kanäle;
      Dauer = Props.Dauer;
      Signalparameter = Props.Parameter;
      WavDateiGewählt = Path.Combine(DPfad, DDatei);
      //setzen HMI
      SetHMI();
    }

    private void SetHMI()
    {
      tbDatei.Text = WavDateiGewählt;
      tbSR.Text = $"{SampleRate} Hz";
      tbChan.Text = $"{Kanäle} Kanäle";
      tbDauer.Text = $"{Dauer} s";
      switch (derTyp)
      {
        case signalTyp.stNull:
          break;
        case signalTyp.stWobbel:
          tbTyp.Text = "Wobbel";
          tbParam.Text = $"von {Param1} Hz";
          tbParam2.Text = $"bis {Param2} Hz";
          tbParam3.Text = $"{Param3} Durchläufe";
          tbParam4.Text = $"Amplitude {Param4} %";
          break;
        case signalTyp.st5Ton:
          tbTyp.Text = "5-Ton-Ruf";
          tbParam.Text = Param5;
          tbParam2.Text = $" ";
          tbParam3.Text = $" ";
          tbParam4.Text = $"Amplitude {Param4} %";
          break;
        case signalTyp.stSin:
          tbTyp.Text = "Sinus";
          tbParam.Text = $"    Sinus {Param1} Hz";
          tbParam2.Text = $" 2. Sinus {Param2} Hz";
          tbParam3.Text = $" 3. Sinus {Param3} Hz";
          tbParam4.Text = $"Amplitude {Param4} %";
          break;
        case signalTyp.stSchweb:
          tbTyp.Text = "Schwebung";
          tbParam.Text = $"Mod Hz";
          tbParam2.Text = $"Mod Hz";
          tbParam3.Text = $"Ampl ";
          break;
        case signalTyp.stKonstant:
          tbTyp.Text = "konstant";
          tbParam.Text = $"";
          tbParam2.Text = $"";
          tbParam3.Text = $"Wert ";
          break;
        case signalTyp.stRausch:
          tbTyp.Text = "Rauschen";
          tbParam.Text = "";
          tbParam2.Text = "";
          tbParam3.Text = "";
          tbParam4.Text = $"Amplitude {Param4} %";
          break;
        case signalTyp.stKnall:
          tbTyp.Text = "Knall";
          tbParam.Text = "";
          tbParam2.Text = "";
          tbParam3.Text = "";
          tbParam4.Text = "";
          break;
        default:
          throw new ArgumentOutOfRangeException("SetHMI, Case {derTyp} fehlt");
      }
    }
    private void bErzeuge_Click(object sender, EventArgs e)
    {
      ulong nSignal, nEin, nAus;
      double[] fEin, fAus;
      AudioDatei?.Dispose();
      AudioDatei = new ASDatei(WavDateiGewählt, SampleRate, Kanäle);
      double sample, fq1, fq2, pirate, einausDauer;
      pirate = 2.0 * Math.PI / SampleRate;
      einausDauer = (derTyp == signalTyp.stRausch) ? 0.3 : 0.01;
      nSignal = (uint)Math.Ceiling(Dauer * SampleRate);
      nEin = nAus = (uint)Math.Floor(einausDauer * SampleRate);
      fEin = new FensterFktn(nEin, FensterFktn.FensterTyp.Cos2).FensterEin();
      fAus = new FensterFktn(nAus, FensterFktn.FensterTyp.Cos2).FensterAus();
      switch (derTyp)
      {
        case signalTyp.stNull:
          return;
        case signalTyp.stWobbel:
          ErzeugeWobbel(Param1, Param2, Dauer, Param4, (int)Math.Round(Param3), AudioDatei);
          break;
        case signalTyp.stSin:
          ErzeugeSin(nSignal, pirate, fEin, fAus, Param4, AudioDatei);
          break;
        case signalTyp.st5Ton:
          Erzeuge5Ton(SampleRate, Param5, Param4, AudioDatei);
          break;
        case signalTyp.stRausch:
          ErzeugeRausch(nSignal, Param4, fEin, fAus, AudioDatei);
          break;
        case signalTyp.stKonstant:
          for (ulong i = 0; i < nSignal; i++)
          {
            AudioDatei.WriteSample((float)Param4);
          }
          break;
        case signalTyp.stKnall:
          for (ulong i = 0; i < 10 * nEin; i++)
            AudioDatei.WriteSample(0);
          AudioDatei.WriteSample(1);
          AudioDatei.WriteSample(1);
          AudioDatei.WriteSample(1);
          AudioDatei.WriteSample(1);
          AudioDatei.WriteSample(1);
          AudioDatei.WriteSample(1);
          AudioDatei.WriteSample(1);
          AudioDatei.WriteSample(1);
          AudioDatei.WriteSample(1);
          AudioDatei.WriteSample(1);
          AudioDatei.WriteSample(1);
          AudioDatei.WriteSample(1);
          AudioDatei.WriteSample(-1);
          AudioDatei.WriteSample(-1);
          AudioDatei.WriteSample(-1);
          AudioDatei.WriteSample(-1);
          AudioDatei.WriteSample(-1);
          AudioDatei.WriteSample(-1);
          AudioDatei.WriteSample(-1);
          AudioDatei.WriteSample(-1);
          AudioDatei.WriteSample(-1);
          AudioDatei.WriteSample(-1);
          AudioDatei.WriteSample(-1);
          AudioDatei.WriteSample(-1);
          for (ulong i = 0; i < nSignal; i++)
            AudioDatei.WriteSample(0);
          break;
        case signalTyp.stSchweb:
          fq1 = Param1;
          fq2 = Param2;
          for (ulong i = 0; i < nSignal; i++)
          {
            double mult = i * pirate;
            sample = .6 * Math.Cos((fq1 * mult) + (Param4 * Math.Cos(fq2 * mult)));
            AudioDatei.WriteSample((float)sample);
          }
          break;
        default:
          throw new ArgumentOutOfRangeException("bErzeuge_Click, Case {derTyp} fehlt");
      }
      AudioDatei.Flush();
      AudioDatei.Dispose();
      AudioDatei = null;
    }

    private void ErzeugeSin(ulong nSaples,
       double pirate,
      double[] fEin,
      double[] fAus,
      double amplitude,
       ASDatei asd)
    {
      double sample;
      ulong iSignal;
      int nSin = 0;
      if (Param1 > 0)
        nSin++;
      if (Param2 > 0)
        nSin++;
      if (Param3 > 0)
        nSin++;
      amplitude = 0.01 * amplitude / nSin;
      iSignal = 0;

      for (ulong i = 0; i < (ulong)fEin.Length; i++)
      {
        double mult = iSignal++ * pirate;
        sample = fEin[i] * amplitude *
          (Math.Cos(Param1 * mult) +
          Math.Sin(Param2 * mult) +
          Math.Sin(Param3 * mult));
        asd.WriteSample((float)sample);
      }
      for (ulong i = 0; i < nSaples; i++)
      {
        double mult = iSignal++ * pirate;
        sample = amplitude *
          (Math.Cos(Param1 * mult) +
          Math.Sin(Param2 * mult) +
          Math.Sin(Param3 * mult));
        asd.WriteSample((float)sample);
      }
      for (ulong i = 0; i < (ulong)fAus.Length; i++)
      {
        double mult = iSignal++ * pirate;
        sample = fAus[i] * amplitude *
          (Math.Cos(Param1 * mult) +
          Math.Sin(Param2 * mult) +
          Math.Sin(Param3 * mult));
        asd.WriteSample((float)sample);
      }
      return;
    }

    private void Erzeuge5Ton(ulong srate,
                             string tonfolge,
                             double amplitude,
                             ASDatei asd)
    {

      double sample, pirate;
      ulong pause600, dauer70;

      _ = 0.01 * amplitude;
      pirate = 2.0 * Math.PI / srate;
      pause600 = 6 * srate / 10;  //600 ms
      dauer70 = 7 * srate / 100;  //70 ms
      char[] code = tonfolge.ToCharArray();
      for (int i = 1; i < code.Length; i++)
      {
        if (code[i] == code[i - 1])
          code[i] = 'R';
      }
      for (int j = 0; j < 2; j++)
      {
        for (ulong i = 0; i < pause600; i++)
          asd.WriteSample(0);
        foreach (char c in code)
        {
          double fq = Technisches.Fq5Ton[c];
          for (ulong i = 0; i < dauer70; i++)
          {
            double mult = i * pirate;
            sample = Math.Cos(fq * mult);
            asd.WriteSample((float)sample);
          }
        }
      }
      for (ulong i = 0; i < pause600; i++)
        asd.WriteSample(0);
      return;
    }
    private void ErzeugeRausch(
      ulong nSamples,
      double amplitude,
      double[] fEin,
      double[] fAus, ASDatei asd)
    {
      double sample;
      Random r = new Random();
      amplitude *= 0.4 * 0.01;
      for (ulong i = 0; i < (ulong)fEin.Length; i++)
      {
        sample = amplitude *
          (r.NextDouble() +
          r.NextDouble() +
          r.NextDouble() +
          r.NextDouble() +
          r.NextDouble());
        asd.WriteSample((float)(fEin[i] * (sample - 1.0)));
      }
      for (ulong i = 0; i < nSamples; i++)
      {
        sample = amplitude *
          (r.NextDouble() +
          r.NextDouble() +
          r.NextDouble() +
          r.NextDouble() +
          r.NextDouble());
        asd.WriteSample((float)(sample - 1.0));
      }
      for (ulong i = 0; i < (ulong)fAus.Length; i++)
      {
        sample = amplitude *
          (r.NextDouble() +
          r.NextDouble() +
          r.NextDouble() +
          r.NextDouble() +
          r.NextDouble());
        asd.WriteSample((float)(fAus[i] * (sample - 1.0)));
      }

      return;
    }

    private void ErzeugeWobbel(
      double fAb,
      double fBis,
      double dauerGesamt,
      double amplitude,
      int mal, ASDatei asd)
    {
      double sample, phi;
      phi = 0;
      //soviel Werte für 1x hoch oder runter
      ulong nSignal = (ulong)Math.Round(0.5 * dauerGesamt * SampleRate / mal);
      //soviel dreht sich der Zeiger pro Wert bei f = fAb und bei f = fBis
      double dPhiAb = 2.0 * Math.PI * fAb / SampleRate;
      double dPhiBis = 2.0 * Math.PI * fBis / SampleRate;
      //soviel muss die Drehung zunehmen
      double dPhiHub = dPhiBis - dPhiAb;
      //soviel nimmt die Drehung pro Wert zu
      double dPhiInc = dPhiHub / nSignal;
      double dPhi = dPhiAb;
      amplitude *= 0.01;
      for (int i = 0; i < mal; i++)
      {
        for (ulong j = 0; j < nSignal; j++)
        {
          sample = amplitude * Math.Sin(phi);
          asd.WriteSample((float)sample);
          phi += dPhi;
          dPhi += dPhiInc;
        }
        for (ulong j = 0; j < nSignal; j++)
        {
          sample = amplitude * Math.Sin(phi);
          asd.WriteSample((float)sample);
          phi += dPhi;
          dPhi -= dPhiInc;
        }
      }
      return;
    }
    private void textBox1_Click(object sender, EventArgs e)
    {
      TextBox tb = (TextBox)sender;
      sfd1.FileName = Path.Combine(DPfad, DDatei);
      if (sfd1.ShowDialog() == DialogResult.OK)
      {
        AudioDatei?.Dispose();
        WavDateiGewählt = sfd1.FileName;
        tb.Text = sfd1.FileName;
        DDatei = Path.GetFileName(WavDateiGewählt);
        DPfad = Path.GetDirectoryName(WavDateiGewählt);
      }
      SetHMI();
    }
    private void tbDauer_Leave(object sender, EventArgs e)
    {
      string[] s;
      TextBox tb = (TextBox)sender;
      if (tb.Text.Length < 1)
        return;
      s = tb.Text.Split(' ');
      Dauer = s.Length > 0 ? (float)Convert.ToDouble(s[0]) : 1;
      SetHMI();
    }
    private void rbSin_Click(object sender, EventArgs e)
    {
      RadioButton rb = (RadioButton)sender;
      string typ = rb.Text;
      switch (typ)
      {
        case "Sinus":
          derTyp = signalTyp.stSin;
          break;
        case "Schwebung":
          derTyp = signalTyp.stSchweb;
          break;
        case "Rauschen":
          derTyp = signalTyp.stRausch;
          break;
        case "konstant":
          derTyp = signalTyp.stKonstant;
          break;
        case "Wobbel":
          derTyp = signalTyp.stWobbel;
          break;
        case "Knall":
          derTyp = signalTyp.stKnall;
          break;
        case "5-Ton-Ruf":
          derTyp = signalTyp.st5Ton;
          break;
        default:
          throw new ArgumentOutOfRangeException("rbSin_Click, Case {typ} fehlt");
      }
      SetHMI();
    }

    private void rbMono_CheckedChanged(object sender, EventArgs e)
    {
      RadioButton rb = (RadioButton)sender;
      Kanäle = rb.Text.StartsWith("M") ? 1 : (uint)2;
      SetHMI();

    }

    private void tbParam_Enter(object sender, EventArgs e)
    {
      TextBox tb = (TextBox)sender;
      tb.Text = "";
    }

    private void rbT5_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void textBoxLeave(object sender, EventArgs e)
    {
      string[] s;
      TextBox tb = (TextBox)sender;
      if (tb.Text.Length < 1)
        return;
      s = tb.Text.Split(' ');
      switch (tb.Name)
      {
        case "tbParam":
          if (derTyp == signalTyp.st5Ton)
            Param5 = s[0];
          else
            Param1 = s[0].Length > 0 ? Convert.ToDouble(s[0]) : 0;
          break;
        case "tbParam2":
          Param2 = s[0].Length > 0 ? Convert.ToDouble(s[0]) : 0;
          break;
        case "tbParam3":
          Param3 = s[0].Length > 0 ? Convert.ToDouble(s[0]) : 0;
          break;
        case "tbParam4":
          Param4 = s[0].Length > 0 ? Convert.ToDouble(s[0]) : 0;
          break;
        case "tbDauer":
          Dauer = s.Length > 0 ? (float)Convert.ToDouble(s[0]) : 1;
          break;
        default:
          throw new ArgumentOutOfRangeException(
            "textBoxLeave, Case {tb.Name} fehlt");
      }
      SetHMI();
    }
    private void button1_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void FTSMain_FormClosed(object sender, FormClosedEventArgs e)
    {
      Props.DatenDatei = DDatei;
      Props.DatenPfad = DPfad;
      Props.SampleRate = SampleRate;
      Props.Kanäle = Kanäle;
      Props.Dauer = Dauer;
      Props.Parameter = Signalparameter;
      Props.Save();
      AudioDatei?.Dispose();
    }

    private void rb8_Click(object sender, EventArgs e)
    {
      string[] s;
      RadioButton rb = (RadioButton)sender;
      SampleRate = 0;
      s = rb.Text.Split('.');
      switch (s[0])
      {
        case "8":
          SampleRate = 8000;
          break;
        case "11":
          SampleRate = 11025;
          break;
        case "22":
          SampleRate = 22050;
          break;
        case "44":
          SampleRate = 44100;
          break;
        case "48":
          SampleRate = 48000;
          break;
        default:
          break;
      }
      SetHMI();
      Debug.Assert(SampleRate > 0);
    }
  }
}

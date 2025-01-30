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
    private double SinFq, ModA, ModFq;
    private enum signalTyp
    {
      stNull,
      stSin, stSchweb,
      stRausch,
      stKonstant
    }
    private signalTyp derTyp = signalTyp.stNull;
    public FTSMain()
    {
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
        case signalTyp.stSin:
          tbTyp.Text = "Sinus";
          tbParam.Text = $"Sinus {SinFq} Hz";
          break;
        case signalTyp.stSchweb:
          tbTyp.Text = "Schwebung";
          tbParam.Text = $"Basis {SinFq} Hz";
          tbParam2.Text = $"Mod {ModFq} Hz";
          tbParam3.Text = $"Ampl {ModA}";
          break;
        case signalTyp.stKonstant:
          tbTyp.Text = "konstant";
          tbParam.Text = $"";
          tbParam2.Text = $"";
          tbParam3.Text = $"Wert {ModA}";
          break;
        case signalTyp.stRausch:
          tbTyp.Text = "Rauschen";
          tbParam.Text = "";
          tbParam2.Text = "";
          tbParam3.Text = "";
          break;
        default:
          break;
      }
    }
    private void bErzeuge_Click(object sender, EventArgs e)
    {
      AudioDatei?.Dispose();
      AudioDatei = new ASDatei(WavDateiGewählt, SampleRate, Kanäle);
      double spl, fq1, fq2, pirate;
      pirate = Math.PI / SampleRate;
      uint anzahl = (uint)Math.Floor(Dauer * SampleRate);
      switch (derTyp)
      {
        case signalTyp.stNull:
          return;
        case signalTyp.stSin:
          fq1 = SinFq;
          fq2 = 3 * fq1 / 2;
          for (ulong i = 0; i < anzahl; i++)
          {
            double mult = i * pirate;
            spl = .2 * (Math.Cos(fq1 * mult) + Math.Cos(fq2 * mult));
            AudioDatei.WriteSample((float)spl);
          }
          break;
        case signalTyp.stRausch:
          Random r = new Random();
          for (ulong i = 0; i < anzahl; i++)
          {
            spl =
              r.NextDouble() + r.NextDouble()
              + r.NextDouble() + r.NextDouble() + r.NextDouble();
            AudioDatei.WriteSample((float)((spl * 0.4) - 1.0));
          }
          break;
        case signalTyp.stKonstant:
          for (ulong i = 0; i < anzahl; i++)
          {
            AudioDatei.WriteSample((float)ModA);
          }
          break;
        case signalTyp.stSchweb:
          fq1 = SinFq;
          fq2 = ModFq;
          for (ulong i = 0; i < anzahl; i++)
          {
            double mult = i * pirate;
            spl = .6 * Math.Cos((fq1 * mult) + (ModA * Math.Cos(fq2 * mult)));
            AudioDatei.WriteSample((float)spl);
          }
          break;
        default:
          return;
      }
      AudioDatei.Flush();
      AudioDatei.Dispose();
      AudioDatei = null;
    }

    private void textBox1_Leave(object sender, EventArgs e)
    {

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

    private void rbMono_Click(object sender, EventArgs e)
    {
    }

    private void tbDauer_Leave(object sender, EventArgs e)
    {
      string[] s;
      TextBox tb = (TextBox)sender;
      if (tb.Text.Length < 1)
      {
        return;
      }

      s = tb.Text.Split(' ');
      Dauer = s.Length > 0 ? (float)Convert.ToDouble(s[0]) : 1;
      SetHMI();
    }
    private void rbSchweb_Click(object sender, EventArgs e)
    {

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
        default:
          derTyp = signalTyp.stNull;
          break;
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

    private void tbParam_Leave(object sender, EventArgs e)
    {
      string[] s;
      TextBox tb = (TextBox)sender;
      if (tb.Text.Length < 1)
      {
        return;
      }

      s = tb.Text.Split(' ');
      SinFq = s.Length > 0 ? (float)Convert.ToDouble(s[0]) : 440;
      SetHMI();
    }

    private void textBox1_Leave_1(object sender, EventArgs e)
    {
      string[] s;
      TextBox tb = (TextBox)sender;
      if (tb.Text.Length < 1)
      {
        return;
      }

      s = tb.Text.Split(' ');
      ModA = s.Length > 0 ? (float)Convert.ToDouble(s[0]) : 20;
      SetHMI();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void tbParam2_Leave(object sender, EventArgs e)
    {
      string[] s;
      TextBox tb = (TextBox)sender;
      if (tb.Text.Length < 1)
      {
        return;
      }

      s = tb.Text.Split(' ');
      ModFq = s.Length > 0 ? (float)Convert.ToDouble(s[0]) : 20;
      SetHMI();
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

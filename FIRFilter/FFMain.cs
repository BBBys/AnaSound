using ASHilfen;
using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
namespace FIRFilter
{

  public partial class FFMain : Form
  {
    private readonly string SDatei;
    private readonly string SPfad;
    private readonly string FDatei;
    private readonly string FPfad;
    private ASDatei AudioDatei = null, FilterDatei = null;
    private readonly Properties.Settings Props;
    private string WavDateiGewählt, FltDateiGewählt;

    public FFMain()
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
      SDatei = Props.SoundDatei;
      SPfad = Props.SoundPfad;
      FDatei = Props.FilterDatei;
      FPfad = Props.FilterPfad;
      /* Schreiben neuer Einstellungen
      Props.DatenDatei = neueDatei;
      Props.DatenPfad = neuerPfad;
      Props.Save();*/
    }

    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void öffneSigalToolStripMenuItem_Click(object sender, EventArgs e)
    {

      ofdEingabe.FileName = Path.Combine(SPfad, SDatei);
      if (ofdEingabe.ShowDialog() == DialogResult.OK)
      {
        AudioDatei?.Dispose();
        WavDateiGewählt = ofdEingabe.FileName;
        tslDatei.Text = ofdEingabe.SafeFileName;
        Props.SoundDatei = Path.GetFileName(WavDateiGewählt);
        Props.SoundPfad = Path.GetFullPath(WavDateiGewählt);
        Props.Save();
        AudioDatei = new ASDatei(WavDateiGewählt);
        tslFehler.Text = AudioDatei.HatFehler ? AudioDatei.FehlerText : "";
        tslWarnung.Text = AudioDatei.HatWarnung ? AudioDatei.WarnungText : "";
        tslChan.Text = $"{AudioDatei.Chan} Ch";
        tslSr.Text = $"{AudioDatei.SRate / 1000} KHz";
        tslDauer.Text = $"{AudioDatei.DauerGanzeMin}m {AudioDatei.DauerRestSek:f2}s";
        tslBit.Text = $"{AudioDatei.BitProSample} Bit";
        tslEncoding.Text =         AudioDatei.Encoding;
        /*wv1.WaveStream = AudioDatei.AudioReader;
        wv1.PerformAutoScale();
        wv1.Update();*/
      }

    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutBox1 f = new AboutBox1();
      _ = f.ShowDialog();
      f.Dispose();

    }

    private void schließeSignalToolStripMenuItem_Click(object sender, EventArgs e)
    {

      AudioDatei?.Dispose();
      AudioDatei = null;

    }

    private void öffneFilterToolStripMenuItem_Click(object sender, EventArgs e)
    {Debug.WriteLine(statusStrip1.Width);
      ofdEingabe.FileName = Path.Combine(FPfad, FDatei);
      if (ofdEingabe.ShowDialog() == DialogResult.OK)
      {
        FilterDatei?.Dispose();
        FltDateiGewählt = ofdEingabe.FileName;
        tslFDatei.Text = ofdEingabe.SafeFileName;
        Props.FilterDatei = Path.GetFileName(WavDateiGewählt);
        Props.FilterPfad = Path.GetFullPath(WavDateiGewählt);
        Props.Save();
        FilterDatei = new ASDatei(FltDateiGewählt);
        tslFFehler.Text = FilterDatei.HatFehler ? AudioDatei.FehlerText : "";
        tslFWarnung.Text = FilterDatei.HatWarnung ? AudioDatei.WarnungText : "";
        tslFChan.Text = $"{FilterDatei.Chan} Ch";
        tslFSr.Text = $"{FilterDatei.SRate / 1000} KHz";
        tslFDauer.Text = $"{FilterDatei.DauerGanzeMin}m {AudioDatei.DauerRestSek:f2}s";
        tslFBit.Text = $"{FilterDatei.BitProSample} Bit";
        //tslFEncoding.Text = FilterDatei.Encoding;

      }
      Debug.WriteLine(statusStrip1.Width);
    }
  }
}

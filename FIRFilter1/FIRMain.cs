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
using ASHilfen;
using NAudio.Dsp;
using NAudio.Wave;

namespace FIRFilter
{
  public partial class FIRMain : Form
  {
    private readonly string SDatei;
    private readonly string SPfad;
    private readonly string FDatei;
    private readonly string FPfad; private ASDatei AudioDatei = null;

    private readonly Properties.Settings Props;

    public FIRMain()
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

    private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void leseAudioToolStripMenuItem_Click(object sender, EventArgs e)
    {

      ofdEingabe.FileName = Path.Combine(SPfad, SDatei);
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
  }
}

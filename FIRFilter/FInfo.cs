using ASHilfen;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace AnaSound
{
  public partial class FInfo : Form
  {
    private readonly ASDatei datei;
    public FInfo(ASDatei pdatei)
    {
      InitializeComponent();
      datei = pdatei;
      Text = datei.Name;
    }

    private void bClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void FInfo_Shown(object sender, EventArgs e)
    {
      float dB;
      ulong len;
      len = datei.Len;
      dB = (float)(20.0 * Math.Log10(Math.Max(datei.SigMax, -datei.SigMin)));
      lLen.Text = (len < 2000) ? $"{len} Byte"
           : ((len < 200000L) ? $"{len / 1000} KByte"
           : $"{len / 1000000L} MByte");
      lName.Text = $"Name: {datei.Name}";
      lPfad.Text = $"auf {datei.Pfad}";
      lTyp.Text = $"Dateityp {datei.Typ}";
      lDauer.Text = $"Dauer {datei.DauerGanzeMin} Min {datei.DauerRestSek:f3} Sek ({datei.Dauer:F3} Sek)";
      lGesamt.Text = $"{datei.NSpl} Samples";
      lAufl.Text = $"{datei.Chan} Kanäle mit {datei.BitProSample} Bit/Sample bei {datei.SRate} Sample/Sek";
      lMax.Text = $"Max           {datei.SigMax:f3} ( {datei.SigMaxL:f3} |  {datei.SigMaxR:f3}), {dB:f0} dB";
      lMin.Text = $"Min          {datei.SigMin:f3} ({datei.SigMinL:f3} | {datei.SigMinR:f3})";
      lGleich.Text = $"Gleichanteil  {datei.Mittel:f3} ( {datei.MittelL:f3} |  {datei.MittelR:f3})";
      tslAus.BackColor =
        (datei.SigMax > 0.8 && datei.SigMin < -0.8) ? Color.Lime : Color.Red;
      tslGleich.BackColor =
        (Math.Abs(datei.Mittel) < 0.001) ? Color.Lime : Color.Red;

    }
  }
}

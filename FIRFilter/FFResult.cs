using ASHilfen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASHilfen;
namespace FIRFilter
{
  public partial class FFResult : Form
  {
    private ASDatei audioDatei;
    private ASDatei filterDatei;
    cFIRFilter filter;
    public FFResult()
    {
      InitializeComponent();
    }

    public FFResult(ASDatei audioDatei, ASDatei filterDatei): this()
    {
      this.audioDatei = audioDatei;
      this.filterDatei = filterDatei;
tslNamen.Text =     audioDatei.Name+" x "+filterDatei.Name;
      filter = new cFIRFilter(filterDatei);
    }

    private void FFResult_Shown(object sender, EventArgs e)
    {

    }
  }
}

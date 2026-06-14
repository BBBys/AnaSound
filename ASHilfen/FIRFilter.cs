using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASHilfen
{
  public class cFIRFilter
  {
    private ASDatei filterDatei;
    private readonly double[] _coeffs;   // Filterkoeffizienten (b0..bM)
    private readonly double[] _delay;    // Verzögerungsspeicher
    private readonly ulong länge;
    private int _index;

    public cFIRFilter(ASDatei filterDatei)
    {
      this.filterDatei = filterDatei;
      länge = filterDatei.NSpl;
      _coeffs = new double[länge];
      _delay = new double[länge];
      _index = 0;
      filterDatei.Reset();
      filterDatei.AbschnittLesen(_coeffs,(int)länge);
    }
  }
}

using System.Collections.Generic;

namespace ASHilfen
{
  public static class Technisches
  {/// <summary>
   /// Frequenzen für die DTMF-Töne
   /// Copilot-Vorschlag, nicht geprüft (2. Ton fehlt)
   /// </summary>
    private static readonly Dictionary<char, double> TonFrequenz = new Dictionary<char, double>
      {
        {'1', 697.0},
        {'2', 770.0},
        {'3', 852.0},
        {'4', 941.0},
        {'5', 1209.0},
        {'6', 1336.0},
        {'7', 1477.0},
        {'8', 1633.0},
        {'9', 697.0},
        {'0', 941.0},
        {'*', 1209.0},
        {'#', 1477.0}
      };
    /// <summary>
    /// Frequenzen für die 5-Ton-Signalisierung
    /// </summary>
    public static Dictionary<char, double> Fq5Ton = new Dictionary<char, double>
      {
        {'1', 1060.0},
        {'2', 1160.0},
        {'3', 1270.0},
        {'4', 1400.0},
        {'5', 1530.0},
        {'6', 1670.0},
        {'7', 1830.0},
        {'8', 2000.0},
        {'9', 2200.0},
        {'0', 2400.0},
        {'R', 2600.0},
             };
  }
}

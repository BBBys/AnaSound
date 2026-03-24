public class FirFilter
{
  private readonly double[] _coeffs;   // Filterkoeffizienten (b0..bM)
  private readonly double[] _delay;    // Verzögerungsspeicher
  private int _index;

  public FirFilter(double[] coeffs)
  {
    _coeffs = coeffs;
    _delay = new double[coeffs.Length];
    _index = 0;
  }

  // Einzelnes Sample verarbeiten
  public double ProcessSample(double x)
  {
    _delay[_index] = x;

    double y = 0.0;
    int j = _index;

    // Faltung: y[n] = Sum_k b[k] * x[n-k]
    for (int k = 0; k < _coeffs.Length; k++)
    {
      y += _coeffs[k] * _delay[j];
      j--;
      if (j < 0)
        j = _coeffs.Length - 1;
    }

    _index++;
    if (_index >= _coeffs.Length)
      _index = 0;

    return y;
  }

  // Ganzes Array verarbeiten
  public double[] ProcessBuffer(double[] input)
  {
    var output = new double[input.Length];
    for (int n = 0; n < input.Length; n++)
    {
      output[n] = ProcessSample(input[n]);
    }
    return output;
  }
}
// Beispiel: einfache Lowpass-Koeffizienten (nur Demo!)
// In der Praxis: mit MATLAB, Octave, Python, Online-Tool o.Ä. berechnen.
double[] firCoeffs = new double[]
{
    -0.0021, -0.0043, 0.0, 0.0201, 0.0550, 0.0900, 0.1100, 0.0900, 0.0550, 0.0201, 0.0, -0.0043, -0.0021
};

// Audiodaten (z.B. aus WAV gelesen)
float[] audioIn = LoadAudioSamplesSomehow(); // Platzhalter

// In double konvertieren
double[] audioInD = new double[audioIn.Length];
for (int i = 0; i < audioIn.Length; i++)
  audioInD[i] = audioIn[i];

var fir = new FirFilter(firCoeffs);

// Filtern
double[] audioOutD = fir.ProcessBuffer(audioInD);

// Zurück in float (falls nötig)
float[] audioOut = new float[audioOutD.Length];
for (int i = 0; i < audioOutD.Length; i++)
  audioOut[i] = (float)audioOutD[i];

// audioOut kannst du jetzt wieder als WAV speichern oder abspielen
SaveAudioSamplesSomehow(audioOut); // Platzhalter

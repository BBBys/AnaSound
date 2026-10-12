using ASHilfen;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
namespace FIRFilter
{

  public partial class FFMain : Form
  {
    private readonly string SDatei;
    private readonly string SPfad;
    private readonly string FDatei;
    private readonly string FPfad;
    private ASDatei AudioDatei = null, FilterDatei = null, AusgabeDatei = null;
    private readonly Properties.Settings Props;
    private string WavDateiGewählt, AusDateiGewählt, FltDateiGewählt;

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
        tslEncoding.Text = AudioDatei.Encoding;
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

    private void tsmiWendeFilterAn_Click(object sender, EventArgs e)
    {
      ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
      if (menuItem != null)
        menuItem.Checked = !menuItem.Checked;

      System.Diagnostics.Debug.WriteLine($"Wende FIR-Filter an: {FilterDatei}, MenüStatus: {(menuItem?.Checked.ToString() ?? "null")}");

      WendeFirFilterAn(AudioDatei, FilterDatei, AusgabeDatei);
    }

    private void schließeSignalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AudioDatei?.Dispose();
      AudioDatei = null;

    }

    private void öffneFilterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Debug.WriteLine(statusStrip1.Width);
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

    private void schließeAusgabedateiToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AusgabeDatei?.Dispose();
      AusgabeDatei = null;

    }

    private void schließeFilterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FilterDatei?.Dispose();
      FilterDatei = null;

    }

    private void FFMain_Load(object sender, EventArgs e)
    {
      //????
    }

    private void tsiÖffneAusgabedatei_Click(object sender, EventArgs e)
    {

      ofdAusgabe.FileName = Path.Combine(SPfad, SDatei);
      if (ofdAusgabe.ShowDialog() == DialogResult.OK)
      {
        AusgabeDatei?.Dispose();
        AusDateiGewählt = ofdAusgabe.FileName;
        //tslDatei.Text = ofdAusgabe.SafeFileName;
        Props.AusDatei = Path.GetFileName(AusDateiGewählt);
        Props.AusPfad = Path.GetFullPath(AusDateiGewählt);
        Props.Save();
        AusgabeDatei = new ASDatei(AusDateiGewählt, AudioDatei.SRate, AudioDatei.Chan);
        //        tslFehler.Text = AusgabeDatei.HatFehler ? AusgabeDatei.FehlerText : "";
        //      tslWarnung.Text = AusgabeDatei.HatWarnung ? AusgabeDatei.WarnungText : "";
        //    tslChan.Text = $"{AusgabeDatei.Chan} Ch";
        //  tslSr.Text = $"{AusgabeDatei.SRate / 1000} KHz";
        //tslDauer.Text = $"{AusgabeDatei.DauerGanzeMin}m {AusgabeDatei.DauerRestSek:f2}s";
        //tslBit.Text = $"{AusgabeDatei.BitProSample} Bit";
        //tslEncoding.Text = AusgabeDatei.Encoding;
        /*wv1.WaveStream = AusgabeDatei.AudioReader;
        wv1.PerformAutoScale();
        wv1.Update();*/
      }

    }

    /// <summary>
    /// Wendet einen FIR-Filter (bereitgestellt als WAV-Impulsantwort) auf eine Eingabe-WAV-Datei an.
    /// Grundidee: Vorschlag von Gemini
    /// </summary>
    /// <param name="asdEIN">Pfad zur Eingabe-WAV-Datei</param>
    /// <param name="FILTER">Pfad zur Filter-WAV-Datei (Impulsantwort)</param>
    /// <param name="AUS">Pfad zur Ausgabe-WAV-Datei</param>
    public static void WendeFirFilterAn(ASDatei asdEIN, ASDatei asdFILTER, ASDatei asdAUS)
    {
      // 1. WAV-Dateien einlesen
      //war:      ReadWavFile(EIN, out int sampleRate, out short bitsPerSample, out short channels);      ulong sampleRate = EIN.SRate;
      ulong sampleRate = asdEIN.SRate;
      uint bitsPerSample = asdEIN.BitProSample;
      uint channels = asdEIN.Chan;
      double[] inputData = new double[asdEIN.Len];
      asdEIN.AbschnittLesen(inputData, (int)asdEIN.Len);

      //war:    var filterData = ReadWavFile(FILTER, out _, out _, out _);
      double[] filterData = new double[asdFILTER.Len];
      asdFILTER.AbschnittLesen(filterData, (int)asdFILTER.Len);
      int inputLength = inputData.Length;
      int filterLength = filterData.Length;

      // 2. Ausgabelänge berechnen: EIN + Filter-Länge (Volle lineare Faltung)
      int outputLength = inputLength + filterLength - 1;
      float[] outputData = new float[outputLength];

      // 3. FIR-Filter anwenden (Lineare Faltung / Convolution)
      for (int n = 0; n < outputLength; n++)
      {
#if NDEBUG
#else
        if (n % 1000 == 0) // Nur alle 1000 Schritte debuggen
        {
          System.Diagnostics.Debug.WriteLine($"{n} von {outputLength}");
        }
#endif
        double sum = 0f;
        for (int k = 0; k < filterLength; k++)
        {
          int inputIndex = n - k;
          if (inputIndex >= 0 && inputIndex < inputLength)
          {
            sum += inputData[inputIndex] * filterData[k];
          }
        }
        outputData[n] = (float)sum;
      }

      // 4. Normalisierung (optional, um Clipping zu verhindern) und Konvertierung zurück zu 16-Bit PCM
      float maxVal = 0f;
      foreach (var val in outputData)
      {
        if (Math.Abs(val) > maxVal)
          maxVal = Math.Abs(val);
      }
      //reicht short aus?
      ulong[] pcmOutput = new ulong[outputLength];
      float scale =
        (maxVal > 32767f) ?
        (32767f / maxVal) :
        (1.0f);

      for (int i = 0; i < outputLength; i++)
      {
        float scaled = outputData[i] * scale;
        //ohne clamp pcmOutput[i] = (short)Math.Clamp(scaled, -32768, 32767);
        pcmOutput[i] = (ulong)scaled;
        //ACHTUNG funktioniert nicht für Stereo,
        //da WriteSample(float spl1, [float spl2 = 0]) erwartet wird.
        asdAUS.WriteSample(scaled);
      }

      // 5. Auf AUS-Datei schreiben
      //  WriteWavFile(AUS, pcmOutput, asdEIN.SRate, bitsPerSample, channels);
      asdAUS.Flush();
      asdAUS.Dispose();
    }

    private static float[] ReadWavFile(string filePath, out int sampleRate, out short bitsPerSample, out short channels)
    {
      using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
      using (var reader = new BinaryReader(fs))
      {
        // RIFF Header überspringen
        reader.ReadBytes(22); // ChunkID, ChunkSize, WmtID, SubChunk1ID, SubChunk1Size
        channels = reader.ReadInt16();
        sampleRate = reader.ReadInt32();
        reader.ReadBytes(6); // ByteRate, BlockAlign
        bitsPerSample = reader.ReadInt16();

        // Suche nach dem "data"-Chunk
        string dataHeader = "";
        while (fs.Position < fs.Length)
        {
          dataHeader = new string(reader.ReadChars(4));
          int dataSize = reader.ReadInt32();
          if (dataHeader == "data")
          {
            int sampleCount = dataSize / (bitsPerSample / 8);
            float[] samples = new float[sampleCount];
            for (int i = 0; i < sampleCount; i++)
            {
              if (bitsPerSample == 16)
              {
                samples[i] = reader.ReadInt16();
              }
              else if (bitsPerSample == 8)
              {
                samples[i] = (reader.ReadByte() - 128) * 256;
              }
              // Für einfache Zwecke unterstützen wir hier primär 16-Bit PCM
            }
            return samples;
          }
          else
          {
            reader.ReadBytes(dataSize);
          }
        }
        throw new Exception("Kein gültiger 'data'-Chunk in der WAV-Datei gefunden.");
      }
    }

    private static void WriteWavFile(string filePath, ulong[] data, ulong sampleRate, uint bitsPerSample, uint channels)
    {
      using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
      using (var writer = new BinaryWriter(fs))
      {
        ulong byteRate = sampleRate * channels * (bitsPerSample / 8);
        short blockAlign = (short)(channels * (bitsPerSample / 8));
        long dataSubChunkSize = data.Length * (bitsPerSample / 8);
        long riffChunkSize = 36 + dataSubChunkSize;

        // RIFF Header
        writer.Write("RIFF".ToCharArray());
        writer.Write(riffChunkSize);
        writer.Write("WAVE".ToCharArray());

        // fmt Subchunk
        writer.Write("fmt ".ToCharArray());
        writer.Write(16); // SubChunk1Size für PCM
        writer.Write((short)1); // AudioFormat (1 = PCM)
        writer.Write(channels);
        writer.Write(sampleRate);
        writer.Write(byteRate);
        writer.Write(blockAlign);
        writer.Write(bitsPerSample);

        // data Subchunk
        writer.Write("data".ToCharArray());
        writer.Write(dataSubChunkSize);

        foreach (var sample in data)
        {
          writer.Write(sample);
        }
      }
    }

  }
}

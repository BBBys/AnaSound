using NAudio.Wave;
using System;
using System.IO;

namespace AnaSound
{
  public class ASDatei
  {
    internal object Pfad;
    internal object Typ;
    public string DateimitPfad { get; private set; }
    public WaveFileReader reader { get; private set; }
    public uint DauerGanzeMin { get; internal set; }
    public float DauerRestSek { get; internal set; }
    /// <summary>
    /// Sample Rate
    /// </summary>
    public int SR { get; private set; }
    public int Bit { get; private set; }
    public uint Chan { get; private set; }
    public ulong NSpl { get; private set; }
    public string Name { get; internal set; }
    /// <summary>
    ///  Dauer in s
    /// </summary>
    public float Dauer { get; private set; }
    public ulong Len { get; private set; }
    public bool Mono { get { return Chan == 1; } }

    public float SigMin { get; private set; }
    public double Mittel { get; private set; }
    public float SigMax { get; private set; }
    public float SigMinL { get; private set; }
    public float SigMaxL { get; private set; }
    public float SigMinR { get; private set; }
    public float SigMaxR { get; private set; }
    public double MittelL { get; private set; }
    public double MittelR { get; private set; }
    public bool Ende { get { return reader.Position >= reader.Length; } }
    public WaveFormat WFmt { get => reader.WaveFormat; }

    public ASDatei(string pDatei)
    {
      DateimitPfad = pDatei;
      Name = Path.GetFileName(pDatei);
      Pfad = Path.GetDirectoryName(pDatei);
      Typ = Path.GetExtension(pDatei);
      WavInfo();
      Analyse();
    }

    private void Analyse()
    {
      float[] fc;
      reader.Position = 0;
      SigMin = SigMax = SigMinL = SigMaxL = SigMinR = SigMaxR = 0;
      Mittel = MittelL = MittelR = 0;
      for (ulong j = 0; j < NSpl; j++)//so viel PwrData
      {
        fc = reader.ReadNextSampleFrame();
        if (Mono)
        {
          SigMax = Math.Max(SigMax, fc[0]);
          SigMin = Math.Min(SigMin, fc[0]);
          Mittel += fc[0];
        }
        else
        {
          SigMaxL = Math.Max(SigMaxL, fc[0]);
          SigMinL = Math.Min(SigMinL, fc[0]);
          SigMaxR = Math.Max(SigMaxR, fc[1]);
          SigMinR = Math.Min(SigMinR, fc[1]);
          MittelL += fc[0];
          MittelR += fc[1];
        }
      }
      if (Mono)
      {
        SigMaxL = SigMaxR = SigMax;
        SigMinL = SigMinR = SigMin;
        Mittel /= (double)NSpl;
        MittelL = MittelR = Mittel;
      }
      else
      {
        SigMax = Math.Max(SigMaxR, SigMaxL);
        SigMin = Math.Min(SigMinR, SigMinL);
        MittelL /= (double)NSpl;
        MittelR /= (double)NSpl;
        Mittel = (MittelR + MittelL) / 2.0;
      }
    }

    private void WavInfo()
    {
      reader = new WaveFileReader(DateimitPfad);
      int dByte;
      NSpl = (ulong)reader.SampleCount;
      Len = (ulong)reader.Length;
      SR = reader.WaveFormat.SampleRate;
      Bit = reader.WaveFormat.BitsPerSample;
      dByte = Bit / 8;//Byte pro Sample
      Chan = (uint)reader.WaveFormat.Channels;
      Dauer = Len / (float)SR / Chan / dByte; //Sekunden
      DauerGanzeMin = (uint)Dauer / 60;
      DauerRestSek = Dauer - (60 * DauerGanzeMin);
    }
    internal void Dispose()
    {
      reader?.Dispose();
    }

    internal void Reset()
    {
      reader.Position = 0;
    }

    internal string NeueDatei()
    {
      string name;
      name = Path.GetRandomFileName();
      return name;
    }
  }
}

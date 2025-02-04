using NAudio.Wave;
using System;
using System.IO;
namespace ASHilfen
{
  public class ASDatei
  {
    private enum asdRichtung { asdUnbekannt, asdSchreiben, asdLesen };
    private readonly asdRichtung Richtung = asdRichtung.asdUnbekannt;
    private readonly WaveFormat WFmtObj;
    /// <summary>
    /// 343,2 m/s (1236 km/h) in trockener Luft von 20 °C [Wikipedia]
    /// </summary>
    public readonly double Schallgewindigkeit = 343.2;

    public WaveFileWriter AudioWriter { get; private set; }
    public WaveFileReader AudioReader { get; private set; }
    public string DateimitPfad { get; private set; }
    public uint DauerGanzeMin { get; internal set; }
    public float DauerRestSek { get; internal set; }
    /// <summary>
    /// Sample Rate, Samples oder Paare / s
    /// </summary>
    public ulong SRate { get; private set; }
    /// <summary>
    /// Bits pro Sample
    /// </summary>
    public uint BitProSample { get; private set; }
    public uint Chan { get; private set; }
    /// <summary>
    /// Anzahl Samples in Datei (1 Sample = 2 Werte bei Stereo)
    /// </summary>
    public ulong NSpl { get; private set; }
    private uint ByteProSpl;
    public ulong Pos => (ulong)AudioReader.Position / ByteProSpl;
    /// <summary>
    /// Dateiname ohne Pfad
    /// </summary>
    public string Name { get; internal set; }
    /// <summary>
    ///  Dauer in s
    /// </summary>
    public float Dauer { get; private set; }
    /// <summary>
    /// Dateilänge in Bytes
    /// </summary>
    public ulong Len { get; private set; }
    public bool Mono => Chan == 1;
    public float SigMin { get; private set; }
    public double Mittel { get; private set; }
    public float SigMax { get; private set; }
    public float SigMinL { get; private set; }
    public float SigMaxL { get; private set; }
    public float SigMinR { get; private set; }
    public float SigMaxR { get; private set; }
    public double MittelL { get; private set; }
    public double MittelR { get; private set; }
    public WaveFormat WFmt => Richtung == asdRichtung.asdLesen
          ? AudioReader.WaveFormat
          : Richtung == asdRichtung.asdSchreiben ? AudioWriter.WaveFormat : null;

    public string Pfad { get; private set; }
    public string Typ { get; private set; }
    public string Encoding { get; private set; } = "?";
    public string FehlerText { get; private set; } = "";
    public bool HatFehler { get; private set; } = false;
    public string WarnungText { get; private set; } = "";
    public bool HatWarnung { get; private set; } = false;

    public ASDatei(string pDatei)
    {

      Richtung = asdRichtung.asdLesen;
      DateimitPfad = pDatei;
      Name = Path.GetFileName(pDatei);
      Pfad = Path.GetDirectoryName(pDatei);
      Typ = Path.GetExtension(pDatei);
      WavInfo();
      Analyse();
    }
    /// <summary>
    /// WAV-Datei zu Beschreiben erzeugen
    /// </summary>
    /// <param name="pDatei">Dateiname, vollständig</param>
    /// <param name="prate">Rate, Samples/s (8.000, 11.025 ... 48.000)</param>
    /// <param name="pchan">1 oder 2 Kanäle</param>
    public ASDatei(string pDatei, ulong prate, uint pchan)
    {
      AudioWriter?.Dispose();
      Richtung = asdRichtung.asdSchreiben;
      DateimitPfad = pDatei;
      Name = Path.GetFileName(pDatei);
      Pfad = Path.GetDirectoryName(pDatei);
      Typ = ".wav";
      SRate = prate;
      Chan = pchan;
      Dauer = 0;//TODO
      WFmtObj = new WaveFormat((int)SRate, (int)Chan);
      AudioWriter = new WaveFileWriter(DateimitPfad, WFmtObj);
    }
    public bool Ende() { return AudioReader.Position >= AudioReader.Length; }

    private void Analyse()
    {
      float[] fc;
      HatFehler = false;
      AudioReader.Position = 0;
      SigMin = SigMax = SigMinL = SigMaxL = SigMinR = SigMaxR = 0;
      Mittel = MittelL = MittelR = 0;
      if (BitProSample < 9)
      {
        HatFehler = true;
        FehlerText = $"{BitProSample}-Bit-Datei!";
        return;
      }
      for (ulong j = 0; j < NSpl; j++)//so viel PwrData
      {
        fc = AudioReader.ReadNextSampleFrame();
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
        Mittel /= NSpl;
        MittelL = MittelR = Mittel;
      }
      else
      {
        SigMax = Math.Max(SigMaxR, SigMaxL);
        SigMin = Math.Min(SigMinR, SigMinL);
        MittelL /= NSpl;
        MittelR /= NSpl;
        Mittel = (MittelR + MittelL) / 2.0;
      }
    }

    private void WavInfo()
    {
      bool encoding = false;
      AudioReader = new WaveFileReader(DateimitPfad);
      Encoding = "nicht ermittelt";
      switch (AudioReader.WaveFormat.Encoding)
      {
        case WaveFormatEncoding.Unknown:
          break;
        case WaveFormatEncoding.Pcm:
          Encoding = "PCM";
          encoding = true;
          break;
        case WaveFormatEncoding.Adpcm:
          Encoding = "ADPCM";
          HatWarnung = true;
          WarnungText = "Encoding nicht behandelt";
          break;
        case WaveFormatEncoding.IeeeFloat:
          break;
        case WaveFormatEncoding.Vselp:
          break;
        case WaveFormatEncoding.IbmCvsd:
          break;
        case WaveFormatEncoding.ALaw:
          break;
        case WaveFormatEncoding.MuLaw:
          break;
        case WaveFormatEncoding.Dts:
          break;
        case WaveFormatEncoding.Drm:
          break;
        case WaveFormatEncoding.WmaVoice9:
          break;
        case WaveFormatEncoding.OkiAdpcm:
          break;
        case WaveFormatEncoding.DviAdpcm:
          //   break;
          //  case WaveFormatEncoding.ImaAdpcm:
          break;
        case WaveFormatEncoding.MediaspaceAdpcm:
          break;
        case WaveFormatEncoding.SierraAdpcm:
          break;
        case WaveFormatEncoding.G723Adpcm:
          break;
        case WaveFormatEncoding.DigiStd:
          break;
        case WaveFormatEncoding.DigiFix:
          break;
        case WaveFormatEncoding.DialogicOkiAdpcm:
          break;
        case WaveFormatEncoding.MediaVisionAdpcm:
          break;
        case WaveFormatEncoding.CUCodec:
          break;
        case WaveFormatEncoding.YamahaAdpcm:
          break;
        case WaveFormatEncoding.SonarC:
          break;
        case WaveFormatEncoding.DspGroupTrueSpeech:
          break;
        case WaveFormatEncoding.EchoSpeechCorporation1:
          break;
        case WaveFormatEncoding.AudioFileAf36:
          break;
        case WaveFormatEncoding.Aptx:
          break;
        case WaveFormatEncoding.AudioFileAf10:
          break;
        case WaveFormatEncoding.Prosody1612:
          break;
        case WaveFormatEncoding.Lrc:
          break;
        case WaveFormatEncoding.DolbyAc2:
          break;
        case WaveFormatEncoding.Gsm610:
          break;
        case WaveFormatEncoding.MsnAudio:
          break;
        case WaveFormatEncoding.AntexAdpcme:
          break;
        case WaveFormatEncoding.ControlResVqlpc:
          break;
        case WaveFormatEncoding.DigiReal:
          break;
        case WaveFormatEncoding.DigiAdpcm:
          break;
        case WaveFormatEncoding.ControlResCr10:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_NMS_VBXADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_CS_IMAADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_ECHOSC3:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_ROCKWELL_ADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_ROCKWELL_DIGITALK:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_XEBEC:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_G721_ADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_G728_CELP:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_MSG723:
          break;
        case WaveFormatEncoding.Mpeg:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_RT24:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_PAC:
          break;
        case WaveFormatEncoding.MpegLayer3:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_LUCENT_G723:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_CIRRUS:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_ESPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VOXWARE:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_CANOPUS_ATRAC:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_G726_ADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_G722_ADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_DSAT_DISPLAY:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VOXWARE_BYTE_ALIGNED:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VOXWARE_AC8:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VOXWARE_AC10:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VOXWARE_AC16:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VOXWARE_AC20:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VOXWARE_RT24:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VOXWARE_RT29:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VOXWARE_RT29HW:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VOXWARE_VR12:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VOXWARE_VR18:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VOXWARE_TQ40:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_SOFTSOUND:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VOXWARE_TQ60:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_MSRT24:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_G729A:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_MVI_MVI2:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_DF_G726:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_DF_GSM610:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_ISIAUDIO:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_ONLIVE:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_SBC24:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_DOLBY_AC3_SPDIF:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_MEDIASONIC_G723:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_PROSODY_8KBPS:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_ZYXEL_ADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_PHILIPS_LPCBB:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_PACKED:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_MALDEN_PHONYTALK:
          break;
        case WaveFormatEncoding.Gsm:
          break;
        case WaveFormatEncoding.G729:
          break;
        case WaveFormatEncoding.G723:
          break;
        case WaveFormatEncoding.Acelp:
          break;
        case WaveFormatEncoding.RawAac:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_RHETOREX_ADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_IRAT:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VIVO_G723:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VIVO_SIREN:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_DIGITAL_G723:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_SANYO_LD_ADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_SIPROLAB_ACEPLNET:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_SIPROLAB_ACELP4800:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_SIPROLAB_ACELP8V3:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_SIPROLAB_G729:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_SIPROLAB_G729A:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_SIPROLAB_KELVIN:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_G726ADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_QUALCOMM_PUREVOICE:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_QUALCOMM_HALFRATE:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_TUBGSM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_MSAUDIO1:
          break;
        case WaveFormatEncoding.WindowsMediaAudio:
          break;
        case WaveFormatEncoding.WindowsMediaAudioProfessional:
          break;
        case WaveFormatEncoding.WindowsMediaAudioLosseless:
          break;
        case WaveFormatEncoding.WindowsMediaAudioSpdif:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_UNISYS_NAP_ADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_UNISYS_NAP_ULAW:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_UNISYS_NAP_ALAW:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_UNISYS_NAP_16K:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_CREATIVE_ADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_CREATIVE_FASTSPEECH8:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_CREATIVE_FASTSPEECH10:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_UHER_ADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_QUARTERDECK:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_ILINK_VC:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_RAW_SPORT:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_ESST_AC3:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_IPI_HSX:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_IPI_RPELP:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_CS2:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_SONY_SCX:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_FM_TOWNS_SND:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_BTV_DIGITAL:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_QDESIGN_MUSIC:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_VME_VMPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_TPC:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_OLIGSM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_OLIADPCM:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_OLICELP:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_OLISBC:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_OLIOPR:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_LH_CODEC:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_NORRIS:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_SOUNDSPACE_MUSICOMPRESS:
          break;
        case WaveFormatEncoding.MPEG_ADTS_AAC:
          break;
        case WaveFormatEncoding.MPEG_RAW_AAC:
          break;
        case WaveFormatEncoding.MPEG_LOAS:
          break;
        case WaveFormatEncoding.NOKIA_MPEG_ADTS_AAC:
          break;
        case WaveFormatEncoding.NOKIA_MPEG_RAW_AAC:
          break;
        case WaveFormatEncoding.VODAFONE_MPEG_ADTS_AAC:
          break;
        case WaveFormatEncoding.VODAFONE_MPEG_RAW_AAC:
          break;
        case WaveFormatEncoding.MPEG_HEAAC:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_DVM:
          break;
        case WaveFormatEncoding.Vorbis1:
          break;
        case WaveFormatEncoding.Vorbis2:
          break;
        case WaveFormatEncoding.Vorbis3:
          break;
        case WaveFormatEncoding.Vorbis1P:
          break;
        case WaveFormatEncoding.Vorbis2P:
          break;
        case WaveFormatEncoding.Vorbis3P:
          break;
        case WaveFormatEncoding.Extensible:
          break;
        case WaveFormatEncoding.WAVE_FORMAT_DEVELOPMENT:
          break;
        default:
          Encoding = "anderes";
          break;
      }
      NSpl = encoding ? (ulong)AudioReader.SampleCount : 0;
      Len = (ulong)AudioReader.Length;
      SRate = (ulong)AudioReader.WaveFormat.SampleRate;
      BitProSample = (uint)AudioReader.WaveFormat.BitsPerSample;
      ByteProSpl = BitProSample / 8;//Byte pro Sample
      Chan = (uint)AudioReader.WaveFormat.Channels;
      Dauer = Len / (float)SRate / Chan / ByteProSpl; //Sekunden
      DauerGanzeMin = (uint)Dauer / 60;
      DauerRestSek = Dauer - (60 * DauerGanzeMin);
    }
    public void Dispose()
    {
      AudioWriter?.Dispose();
      AudioWriter = null;
      AudioReader?.Dispose();
      AudioReader = null;
    }

    public void Reset()
    {
      if (Richtung == asdRichtung.asdLesen)
      {
        AudioReader.Position = 0;
      }

      if (Richtung == asdRichtung.asdSchreiben)
      {
        AudioWriter.Position = 0;
      }
    }

    public void WriteSample(float spl1, float spl2 = 0)
    {
      AudioWriter.WriteSample(spl1);
      if (!Mono)
      {
        AudioWriter.WriteSample(spl2);
      }
    }

    public void Flush()
    {
      AudioReader?.Flush();
      AudioWriter?.Flush();
    }

    public float[] ReadNext()
    {
      return AudioReader.ReadNextSampleFrame();
    }

    /// <summary>
    /// Ein Sample lesen, 0 wenn zuende, Stereo in Mono wandeln
    /// </summary>
    /// <returns>Sample oder 0</returns>
    public float ReadNextMono()
    {
      if (Ende())
        return 0;
      float[] fc = ReadNext();
      return Mono ? fc[0] : (float)((fc[0] + fc[1]) * 0.5);
    }

    /// <summary>
    /// Ein Abschnitt der Audiodatei einlesen
    /// in signal ab start bis ende-1 speicher
    /// </summary>
    /// <param name="signal">Ziel, das beschrieben wird</param>
    /// <param name="ende">bis wohin geschrieben wird</param>
    /// <param name="start">ab wo (default:Anfang) geschrieben wird</param>
    /// <returns>true, wenn Ende erreicht</returns>
    public bool AbschnittLesen(double[] signal, int ende, int start = 0)
    {
      double f;
      float[] fc;
      if (signal.Length < ende)
      {
        throw new ArgumentOutOfRangeException("signal", $"AbschnittLesen von {DateimitPfad}:\nZielfeld zu kurz");
      }
      for (int i = start; i < ende; i++)
      {
        if (Ende())
          f = 0;
        else
        {
          fc = ReadNext();
          f = Mono ? fc[0] : ((fc[0] + fc[1]) * 0.5);
        }
        signal[i] = f;
      }
      return Ende();
    }

  }
}

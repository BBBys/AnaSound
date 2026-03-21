** Audio-Bearbeitung und -Analyse **
# AnaSound
Analyseprogramm: Informationen über Wave-Dateien
Zeitbereich: Signal, Leistung, AKF.
Frequenzbereich: FFT, Leistungsdichtespektrum, Spektrogramm. 
## Tastaturcodes
was|Parameter|Code
---|---|---
zeichne Signal| |Strg-
|-verlauf|S
|-leistung|L
|-AKF|A
|-KKF|K
# Testsignal
Erzeugt unterschiedliche Signale
# Hilfsprogramme
**namespace ASHilfen**
## ASDatei
### ReadNext(), ReadNextMono(), ReadNextStereo()
Liest das nächste Sample aus der Wave-Datei ein.
Ziel|Quelle|wie?
---|---|---
Mono|Mono|direkt
Mono|Stereo|Kanäle mitteln
Stereo|Mono|Mono-Signal verdoppeln
Stereo|Stereo|direkt
# Weiteres
## verwendet
* NAudio
* OxyPlot
## noch zu implementieren
* KKF rechts - links
* adaptives FIR-Filter 
* Audio Streamkopplung
# Quellen
* Meyer (2014): Signalverarbeitung : Analoge und digitale Signale, Systeme und Filter
* Fensterfunktion, Wikipedia https://de.wikipedia.org/w/index.php?title=Fensterfunktion&oldid=240252100
* Schallgeschwindigkeit, Wikipedia, https://de.wikipedia.org/w/index.php?title=Schallgeschwindigkeit&oldid=250821980

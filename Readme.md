# Audio-Bearbeitung und -Analyse
## AnaSound
Analyseprogramm: Informationen über Wave-Dateien
Zeitbereich: Signal, Leistung, AKF.
Frequenzbereich: FFT, Leistungsdichtespektrum, Spektrogramm. 
### Fehler
Frequenzachse im Spektrogramm falsch!
## FIR-Filter
Audiosignal mit FIR-Filter bearbeiten.
## Testsignal
Erzeugt unterschiedliche Signale
## RTTY
Dekodiert Fernschreiber-Signale.
## ASHilfen
Unterstützung.
### class Goertzel
### class ASDatei
- ASDatei(Dateiname): öffnen. Legt keinen Buffer an, deshalb ist Dispose() nicht notwendig.
- (uLong) sRate: Sample Rate, Samples oder Paare / s
- (float, bool) ReadNextMono()
# Weiteres
## verwendet
* NAudio
* OxyPlot
## noch zu implementieren
* KKF rechts - links
* adaptives FIR-Filter 
* Audio Streamkopplung
* AnaSound: 
	* Umgang mit Dateien, bei denen der letzte Block unvollständig ist.
Diese geben beim Einlesen null-Bytes zurück. Nicht an alle Stellen im Programm ist das 
ordentlich berücksichtigt.
	* Umgang mit großen Dateien / langen Audioaufnahmmen. Da dauern manche Operationen
zu lange und sollten entweder warnen oder die Berechnungen verkürzen.

# Quellen
* Meyer (2014): Signalverarbeitung : Analoge und digitale Signale, Systeme und Filter
* Microsoft Copilot: Vorschläge für die Implementierung von Funktionen
* [FIR-Filter von Wdwd - Eigenes Werk, CC BY-SA 3.0](https://commons.wikimedia.org/w/index.php?curid=3870817)
* [Fensterfunktion.       In: Wikipedia – Die freie Enzyklopädie. Bearbeitungsstand: 16. Dezember 2023, 22:56 UTC.](https://de.wikipedia.org/w/index.php?title=Fensterfunktion&oldid=240252100) (Abgerufen: 23. Juni 2026, 09:06 UTC)
* [Goertzel-Algorithmus.  In: Wikipedia – Die freie Enzyklopädie. Bearbeitungsstand: 16. Mai 2026, 11:14 UTC.](https://de.wikipedia.org/w/index.php?title=Goertzel-Algorithmus&oldid=267115219) (Abgerufen: 23. Juni 2026, 09:03 UTC) 
* [Schallgeschwindigkeit. In: Wikipedia – Die freie Enzyklopädie. Bearbeitungsstand: 30. November 2024, 10:34 UTC.](https://de.wikipedia.org/w/index.php?title=Schallgeschwindigkeit&oldid=250821980) (Abgerufen: 23. Juni 2026, 09:08 UTC) 

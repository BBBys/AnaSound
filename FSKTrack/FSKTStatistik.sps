GET DATA
  /TYPE=TXT
  /FILE="D:\Projekte\Audio\AnaSound\FSKTrack\Text.txt"
  /ARRANGEMENT=DELIMITED
  /DELCASE=LINE
  /FIRSTCASE=2
  /DELIMITERS=";"
  /QUALIFIER='"'
  /VARIABLES=
    samples F7.0
    markPower F16.13
    spacePower F16.13
    Text.txt A8.
VARIABLE ALIGNMENT Text.txt (RIGHT).
NUMERIC Bitgültig.
VARIABLE LABEL Bitgültig 'Bit-Wert Mark/Space eindeutig'.

RECODE  markPower 	(LOWEST THRU 8 = 0) (ELSE = 1)  	INTO istMark  .
RECODE  spacePower  	(LOWEST THRU 11.85 = 0) (ELSE = 1)  	INTO istSpace  .

COMPUTE Bitgültig = istMark<>istSpace.
FREQUENCIES 	/VARIABLES= Bitgültig 	/FORMAT=AVALUE TABLE 	/STATISTICS=NONE.

EXECUTE.

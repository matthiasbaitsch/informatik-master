# Erzeugt die PDFs für die mündliche Prüfung
#
# Gedacht zum Kopieren in den Ordner zur mündlichen Prüfung eines Jahrgangs,
# z.B. studienarbeit/2026/03-muendliche-pruefung. Die Protokolle lesen
# studierende-uebersicht.xlsx aus dem Ordner des Jahrgangs.

SRC = ../../../unterlagen/studienarbeit/muendliche-pruefung
FRAGEN = $(SRC)/fragen
BUILD = .protokolle

PDFS = programmieraufgaben.pdf uebersicht.pdf protokolle.pdf

all: $(PDFS)

programmieraufgaben.pdf uebersicht.pdf: %.pdf: $(FRAGEN)/%.typ $(FRAGEN)/aufgaben.typ
	typst compile $< $@

protokolle.pdf: $(SRC)/protokolle/protokolle.qmd ../studierende-uebersicht.xlsx
	mkdir -p $(BUILD)
	cp $< $(BUILD)/protokolle.qmd
	cd $(BUILD) && quarto render protokolle.qmd
	cp $(BUILD)/protokolle.pdf $@

clean:
	rm -rf $(PDFS) $(BUILD)

.PHONY: all clean

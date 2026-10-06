# TODO: Gemeinsame Quarto-Extension für alle Vorlesungen

Ziel: Aussehen und Technik (Themes, Titelseite, Format-Optionen, Filter), die in mehreren Vorlesungen gleich sind,
in eine eigene Quarto-Extension auslagern. Inhalte bleiben in den Bausteinen, Vorlesungsspezifisches im jeweiligen
Repo.

Beteiligte Projekte:

- Mathematik B: `~/sciebo/mathematik-fbb/mathematik-b_2.0/unterlagen`
- Informatik Master: `~/sciebo/lehrveranstaltungen/informatik-master_2.0/unterlagen`

## 1. Bestandsaufnahme

- [X]  Stildateien sammeln und vergleichen
  - Mathematik B: `folien/style.scss`, `folien-r/bcd-style-slides.scss`, `folien-r/quarto-template.yml`
  - Informatik: `style-slides.scss`, `style-titlepage.scss`, `style-assignments.scss`
- [X]  Format-Optionen aus allen `_quarto.yml` vergleichen (revealjs, html, pdf): `lang`, `crossref`,
  `slide-number`, `transition`, MathJax-URL, `toc-depth`, `number-sections` …
- [X]  Bereits genutzte Extensions/Filter erfassen (z.B. `skript/_extensions/quarto-ext/latex-environment`)
- [X]  PDF/LaTeX-Einstellungen im Skript prüfen (Templates, Preamble) – gemeinsam oder spezifisch?
- [X]  Ergebnis: Liste „gemeinsam“ / „nur Mathe“ / „nur Informatik“ (siehe unten)

### Ergebnis der Bestandsaufnahme (Oktober 2026)

#### Folien-Stile: ein Stammbaum, vier Varianten

Alle Folien-Stile stammen von `quarto-revealjs-clean` (Grant McDermott) ab und haben dieselben Grundwerte
(`$jet`, `$accent: #107895`, `$accent2: #9a2515`, Roboto, Titelfolie linksbündig, `.alert/.fg/.bg`, `upN/downN`).


| Datei                                             | Stand                                                                                                                                                                                                                             |
| --------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Informatik`style-slides.scss`                     | am weitesten entwickelt: aufgeräumt,`@each` für `upN/downN`, Abstandsregeln über `margin-top`, Code-Extras (Dateiname, `pseudocode`, `output`, `tall-code`/`half-code`), `dl`, `.neuerbegriff`, `.objective`, Tabellen, Bilder |
| Mathe`folien/style.scss`                          | ältere Fassung: 32px statt 30px,`p` mit `margin-top: 1.25em`, Code kleiner (`pre` 0.65em), `upN/downN` einzeln ausgeschrieben, `summary`-Regel                                                                                   |
| Mathe`folien-r/bcd-style-slides.scss`             | fast identisch mit`folien/style.scss` (nur `section img` statt `summary`, kleine Gewichtsunterschiede)                                                                                                                            |
| `bausteine/bcd-bausteine-r/bcd-style-slides.scss` | eigene Variante im BCD-Repo (engere Listen, Spalten-Regeln, Menü-Button unten links,`h3` 1.2em)                                                                                                                                  |

Folgerung: Informatik-Stil als Basis der Extension nehmen. Mathe-Folien sehen danach etwas anders aus
(Schrift 30 statt 32px, andere Abstände) – das ist die eigentliche Vereinheitlichung und beim Pilot zu prüfen.

#### Titelseite

`style-titlepage.scss` (Informatik) und `bcd-style-titlepage.scss` (BCD-Bausteine R) sind identisch bis auf
die Logo-URL (HS Bochum vs. BCD-Logo). Das Logo muss also eine Option sein, z.B. SCSS-Variable
`$title-logo-url: … !default`, die ein Projekt per kleiner eigener SCSS-Datei überschreibt (Reihenfolge der
`scss:defaults` beim Pilot testen). Nebenbei: die Regeln stehen dort unter `scss:mixins` statt `scss:rules`.

#### Format-Optionen


| Option                                                     | Informatik | Mathe`folien` | Mathe`folien-r` | BCD`bausteine-r` |
| ------------------------------------------------------------ | ------------ | --------------- | ----------------- | ------------------ |
| `lang: de`                                                 | ✓         | ✓            | ✓              | ✓               |
| `overview: true`                                           | ✓         | ✓            | ✓              | ✓               |
| `slide-number: c/t`                                        | ✓         | ✓            | ✓              | ✓               |
| `code-line-numbers: false`                                 | ✓         | ✓            | ✓              | ✓               |
| `transition: fade`, `transition-speed: slow`               | ✓         | –            | –              | –               |
| MathJax 4 per URL                                          | ✓         | –            | –              | –               |
| `toc-depth: 1`, `number-depth: 1`, `number-sections: true` | ✓         | –            | –              | ✓               |
| `format-links: false`                                      | ✓         | –            | –              | ✓               |
| `crossref` mit `exr-title/-prefix: Aufgabe`                | ✓         | –            | –              | –               |
| `execute: echo: true`                                      | –         | –            | ✓              | ✓               |
| `footer`, `_brand`                                         | –         | –            | –              | ✓               |

Klare Kandidaten für `bcd-revealjs`: die ersten vier Zeilen. `transition` und MathJax-URL würde ich mit
aufnehmen (in Mathe vermutlich auch gewünscht). `toc-depth`/`number-*`/`crossref` sind projektweite
Einstellungen und bleiben lokal.

#### HTML

- Informatik: `style-assignments.scss` (nur `h3` und `pre`), Buch `folien-alle` mit `theme: cosmo` (im Julia-Skript erzeugt).
- Mathe: `bcd-style-notes.css` aus dem BCD-Statistik-Repo (`.neuerbegriff`, `.beispiel`, `.definition`, `dl`).
- Gemeinsam ist hier wenig. `.neuerbegriff` gibt es in beiden Projekten, aber verschieden (Informatik: Folien,
  `$accent2`, 400; Mathe: Skript, `rgb(177,52,52)`, fett). Kandidat für eine einheitliche Definition.

#### PDF / Typst

- PDF über LaTeX nur in Mathe (`skript`, `aufgaben`, `folien-r-alle`); Preamble `_bcd-setup.tex` und
  `latex-environment`-Filter kommen aus dem BCD-Statistik-Repo bzw. sind dort kopiert.
- Typst nur in Informatik (`aufgaben` mit `mainfont: Liberation Sans`, `studienarbeit`).
- Folgerung: `bcd-pdf` vorerst weglassen, nichts davon ist gemeinsam.

#### Extensions

- `quarto-ext/latex-environment` in Mathe `skript/_extensions` (eingecheckt) und im BCD-Statistik-Repo.
- Informatik nutzt keine Extensions.
- Keine `.gitignore` schließt `_extensions/` aus.

#### Liste

- Gemeinsam: Folien-Stil (Basis Informatik), Titelseite mit Logo als Option, revealjs-Grundoptionen
  (`lang`, `overview`, `slide-number`, `code-line-numbers`, ggf. `transition`, MathJax), ggf. `.neuerbegriff`.
- Nur Mathe: LaTeX-Preamble, `latex-environment`, `bcd-style-notes.css`, `execute: echo`, Book-Optionen.
- Nur Informatik: `style-assignments.scss`, Typst-Optionen, `crossref` für Aufgaben, Nummerierung.

#### Offene Punkte vor dem Extension-Repo (2.3)

- Name: `bcd` steht in Mathe schon für „Bausteine Computergestützter Datenanalyse“ (Gemeinschaftsprojekt mit
  anderen Autorinnen und Autoren, eigene Repos und eigenes Branding). Für die persönliche Extension einen
  anderen Namen wählen, sonst Verwechslungsgefahr.
- BCD-Submodule (`bcd-bausteine-r`, `bcd-bausteine-statistik`) gehören nicht dir allein. Ihre Stile bleiben
  dort; die Extension betrifft nur die eigenen Projektordner (`folien`, `folien-r` usw.).
- `folien-r`: `collect-content.R` kopiert `bcd-style-slides.scss` und `quarto-template.yml` in jeden
  Teilordner und packt sie in die Zips für Studierende (eigenständig renderbar). Mit Extension müsste
  `_extensions/` mit in die Zips, oder `folien-r` behält den lokalen Stil.
- Informatik-Makefile: `render` rendert weder `studienarbeit` noch `weitere-unterlagen`, die CI schon.
  Bei der CI in 2.5 berücksichtigen.

## 2. Informatik umstellen

### 2.1 Folien als PDF

Zweck: Vergleichsstand vor der Umstellung, außerdem Wunsch der Studierenden.

- [X]  Make-Target `pdf-slides`: Folien-HTML in `__output/lernpfad/folien/c/` mit `decktape reveal` nach PDF,
  parallel (`xargs -P 4`), `-p 200` statt Standardpause
- [X]  Fragments: nur Endzustand jeder Folie (Decktape-Standard)
- [X]  Vergleichsstand erzeugen und außerhalb der Ausgabeordner ablegen (die werden beim Rendern geleert)
- [X]  CI: Node, `decktape` und Chrome bereitstellen (oder Docker-Image `astefanutti/decktape`),
  PDF-Schritt nach dem Rendern
- [X]  PDF-Link auf der Titelfolie jeder Foliendatei (`make_slides` in `skripte/lernpfad-zusammenstellen.jl`),
  Moodle bleibt unverändert
- [X]  PDFs mit veröffentlichen (CI-Schritt oben, sonst läuft der Link ins Leere)

- Bekannte, harmlose Meldungen beim Export: MathJax-`Config`-Fehler (siehe 2.3) und
  `Skipping font compression: Read ttf table data error`

### 2.2 Stylesheet aufräumen

Vor dem Umzug in die Extension, damit dort nur ein gutes Stylesheet landet.

- [X]  Vertikale Abstände umgebaut (Standard groß, Ausnahmen eng); restliche Folien siehe `todo.md`
- [X]  `style-slides.scss` verschachteln: ein `.reveal { … }`-Block pro Abschnitt (Typografie,
  Listen, Tabellen, Bilder, Code), höchstens eine weitere Ebene. Hilfsklassen ohne `.reveal` (`tall-code`,
  `half-code`, `full-width-img`, `etable`, `drop-shadow`, `button`, `neuerbegriff`, `alert`, `fg`, `bg`,
  `upN`/`downN`) außerhalb lassen, sonst ändert sich ihre Spezifität. Danach PDF-Vergleich.

### 2.3 Extension-Repo anlegen

- [ ]  Namen festlegen (nicht `bcd`, siehe offene Punkte oben)
  - Entschieden: Repo `quarto-hsbo-maba`, Extension `hsbo-maba`, Formate `hsbo-maba-revealjs`,
    `hsbo-maba-html` (später ggf. `hsbo-maba-pdf`, `hsbo-maba-typst`).
    Einbinden mit `quarto add matthiasbaitsch/quarto-hsbo-maba`
- [ ]  Struktur anlegen:
  ```
  _extensions/<name>/
    _extension.yml
    slides.scss
    titlepage.scss
    html.scss
    (Logo, Lua-Filter, Partials …)
  ```
- [ ]  Custom Formats in `_extension.yml` definieren: `<name>-revealjs`, `<name>-html`
- [ ]  Gemeinsame Optionen aus Schritt 1 dort eintragen
  - MathJax 4 per URL beibehalten (bewusst umgestellt). Bekannte, harmlose Konsolenmeldung
    `Cannot read properties of undefined (reading 'Config')`: Das Reveal-Mathe-Plugin ruft nach dem Laden
    `MathJax.Hub.Config` (MathJax-2-API) auf, das es in MathJax 4 nicht gibt. Formeln setzt MathJax 4 trotzdem.
    Erscheint auch beim PDF-Export mit Decktape.
- [ ]  Logo der Titelseite als Option (HS Bochum für Informatik, später ggf. anderes für Mathe)
- [ ]  Beispiel-Dokument im Repo-Root (`template.qmd`) zum Testen aller Formate
- [ ]  Optional: Versions-Tags verwenden (`quarto add …@v1.0`), damit Updates bewusst erfolgen

### 2.4 Informatik auf die Extension umstellen

- [ ]  Einbinden: `quarto add <user>/<repo>`
- [ ]  `format: revealjs` → `format: <name>-revealjs` usw., gemeinsame Optionen aus `_quarto.yml` entfernen
- [ ]  Lokale Abweichungen in `_quarto.yml` belassen (überschreiben die Extension)
- [ ]  Vom Julia-Skript erzeugte Konfigurationen prüfen (`folien-alle` mit `theme: cosmo`, `_metadata.yml`)
- [ ]  Alte Stildateien entfernen (`style-slides.scss`, `style-titlepage.scss`, ggf. `style-assignments.scss`)
- [ ]  PDFs vorher/nachher vergleichen
- [ ]  `_extensions/` einchecken (Quarto erwartet das so)

### 2.5 CI

- [ ]  Sicherstellen, dass `_extensions/` im Checkout vorhanden ist (eingecheckt, kein Download in CI nötig)
- [ ]  Makefile und Workflow abgleichen (`render` im Makefile ohne `studienarbeit` und `weitere-unterlagen`)

### 2.6 Dokumentation

- [ ]  README im Extension-Repo: Formate, Optionen, Update-Ablauf (`quarto update <user>/<repo>`),
  bekannte MathJax-Meldung (siehe 2.3)
- [ ]  CLAUDE.md Informatik um Hinweis auf die Extension ergänzen (z.B. Abstandsregel für `style-slides.scss`
  verweist dann auf die Extension)

## 3. Mathematik B umstellen

### 3.1 Folien als PDF

- [ ]  Make-Target `pdf-slides` analog Informatik: `_output/folien/woche-*.html`, ggf. `_output/folien-r/c/*/*.html`
- [ ]  Vergleichsstand erzeugen
- [ ]  Ggf. veröffentlichen und in der CI erzeugen

### 3.2 Mathe B auf die Extension umstellen

- [ ]  Ordner: `folien`, `folien-r`, `folien-r-alle`, `skript`, `aufgaben`, `weitere-unterlagen`
- [ ]  BCD-Submodule nicht anfassen, ihre Stile bleiben dort
- [ ]  `folien-r`: `collect-content.R` kopiert `bcd-style-slides.scss` und `quarto-template.yml` in jeden
  Teilordner und in die Zips. Entscheiden: `_extensions/` mitkopieren oder lokalen Stil behalten
- [ ]  Logo der Titelseite festlegen
- [ ]  PDFs vorher/nachher vergleichen

### 3.3 CI

- [ ]  Workflow prüfen (`make render`, Checkout mit Submodulen), `_extensions/` im Checkout vorhanden

### 3.4 Dokumentation

- [ ]  CLAUDE.md Mathe B um Hinweis auf die Extension ergänzen
- [ ]  README der Extension um Mathe-Besonderheiten ergänzen

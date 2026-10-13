// Programmieraufgaben für die mündliche Prüfung zur Studienarbeit
// Gemeinsame Datenbasis für programmieraufgaben.typ (Karten) und uebersicht.typ (Tabelle)
//
// Felder je Aufgabe:
//   topic      Thema (Karte und Übersicht)
//   title      Titel (Karte und Übersicht)
//   summary    Kurzbeschreibung (nur Übersicht)
//   results    Ergebnisse zu den Testwerten (nur Übersicht, optional)
//   body       Aufgabentext (nur Karte)
//   extension  Erweiterung (nur Karte, optional)
//
// Die Nummerierung ergibt sich aus der Reihenfolge.

#let tasks = (

  // --- Abstrakte Klassen und Polymorphismus --------------------------------

  (
    topic: "Abstrakte Klassen",
    title: "Querschnittswerte",
    summary: [`CrossSection` mit `Area()` und `SecondMoment()`, Unterklassen `Rectangle` und `Circle`],
    body: [
      Querschnitte sollen einheitlich behandelt werden können.

      + Abstrakte Klasse `CrossSection` mit abstrakten Methoden `Area()` und `SecondMoment()` (Flächenträgheitsmoment $I_y$).
      + Unterklassen `Rectangle` (Breite $b$, Höhe $h$) und `Circle` (Durchmesser $d$).

        $ A = b h, quad I_y = (b h^3) / 12 quad "bzw." quad A = (pi d^2) / 4, quad I_y = (pi d^4) / 64 $
      + Testen Sie beide Klassen in einem kurzen Programm.
    ],
    extension: [Speichern Sie mehrere Querschnitte in einer `List<CrossSection>` und geben Sie den Querschnitt mit dem größten $I_y$ aus.],
  ),

  (
    topic: "Abstrakte Klassen",
    title: "Lasten auf einem Träger",
    summary: [Einzel-, Gleichstrecken- und Dreieckslast mit `Resultant()`, Summe über Liste],
    body: [
      Auf einem Träger wirken verschiedene Lastarten. Gesucht ist jeweils die Resultierende.

      + Abstrakte Klasse `Load` mit abstrakter Methode `Resultant()`.
      + Unterklassen:
        - `PointLoad` mit Kraft $F$ → $R = F$
        - `UniformLoad` mit $q$ und Länge $l$ → $R = q l$
        - `TriangularLoad` mit $q_"max"$ und $l$ → $R = q_"max" l \/ 2$
      + Speichern Sie einige Lasten in einer Liste und berechnen Sie die Summe aller Resultierenden.
    ],
    extension: [Ergänzen Sie in jeder Unterklasse `ToString()`, sodass die Last mit Typ und Werten ausgegeben wird.],
  ),

  (
    topic: "Abstrakte Klassen",
    title: "Eigengewicht von Bauteilen",
    summary: [Konkrete Methode `Weight()` ruft abstrakte Methode `Volume()` auf],
    results: [Stütze 30 × 30 cm, 3.0 m: $G = 6.75$ kN],
    body: [
      Das Eigengewicht eines Bauteils ist $G = gamma dot V$ mit der Wichte $gamma$ in kN/m³.

      + Abstrakte Klasse `Member` mit Attribut `UnitWeight` ($gamma$), abstrakter Methode `Volume()` und *nicht* abstrakter Methode `Weight()`.
      + Unterklassen `RectangularColumn` (Breite, Tiefe, Höhe) und `CircularColumn` (Durchmesser, Höhe).
      + Berechnen Sie das Gewicht einer Stahlbetonstütze 30 × 30 cm, Höhe 3.0 m ($gamma = 25$ kN/m³).
    ],
    extension: [Warum muss `Weight()` nur einmal programmiert werden? Erklären Sie, welche `Volume()`-Methode jeweils aufgerufen wird.],
  ),

  (
    topic: "Abstrakte Klassen",
    title: "Wand mit Öffnungen",
    summary: [Öffnungen `Window` und `RoundWindow`, Nettofläche einer Wand mit Liste],
    body: [
      Für eine Wand soll die Nettofläche (ohne Öffnungen) berechnet werden.

      + Abstrakte Klasse `Opening` mit abstrakter Methode `Area()`.
      + Unterklassen `Window` (Breite, Höhe) und `RoundWindow` (Durchmesser).
      + Klasse `Wall` mit Länge, Höhe und einer `List<Opening>`, Methoden `AddOpening(Opening o)` und `NetArea()`.
      + Testen Sie mit einer Wand 6.0 × 2.75 m mit zwei Fenstern und einem runden Fenster.
    ],
    extension: [Ergänzen Sie eine Unterklasse `Door`. Welche Stellen im Programm müssen Sie dafür ändern?],
  ),

  (
    topic: "Abstrakte Klassen",
    title: "Statische Bestimmtheit",
    summary: [Lagertypen mit `Reactions()`, Grad $n = sum r - 3$ und Einordnung],
    body: [
      Ein Einfeldträger ist statisch bestimmt, wenn die Lager zusammen genau drei Auflagerreaktionen haben.

      + Abstrakte Klasse `Support` mit abstrakter Methode `Reactions()`.
      + Unterklassen `FixedSupport` (3), `PinnedSupport` (2) und `RollerSupport` (1).
      + Klasse `Beam` mit einer Liste von Lagern und Methode `Degree()`, die $n = sum r - 3$ zurückgibt.
      + Methode `Classify()` gibt „kinematisch“ ($n < 0$), „statisch bestimmt“ ($n = 0$) oder „$n$-fach statisch unbestimmt“ zurück.
    ],
  ),

  (
    topic: "Abstrakte Klassen",
    title: "Leistungsverzeichnis",
    summary: [Positionen nach Menge oder pauschal, Angebotssumme, `ToString()`],
    body: [
      Ein Angebot besteht aus Positionen, deren Preis unterschiedlich ermittelt wird.

      + Abstrakte Klasse `Item` mit Attribut `Description` und abstrakter Methode `Price()`.
      + Unterklassen:
        - `QuantityItem`: Menge × Einheitspreis (z.B. 120 m² Mauerwerk à 85 €)
        - `LumpSumItem`: Pauschalpreis (z.B. Baustelleneinrichtung 4500 €)
      + Klasse `Offer` mit Liste von Positionen und Methode `Total()`.
    ],
    extension: [Überschreiben Sie `ToString()` in den Unterklassen und geben Sie das Angebot zeilenweise mit Gesamtsumme aus.],
  ),

  (
    topic: "Abstrakte Klassen",
    title: "Brücke mit Lastbegrenzung",
    summary: [Fahrzeuge mit `Weight()`, Auffahren nur bei zulässiger Gesamtlast],
    body: [
      Eine Brücke darf nur befahren werden, solange die zulässige Gesamtlast nicht überschritten wird.

      + Abstrakte Klasse `Vehicle` mit abstrakter Methode `Weight()` (in t).
      + Unterklassen `Car` (immer 1.5 t) und `Truck` (Anzahl Achsen × Achslast).
      + Klasse `Bridge` mit `MaxLoad` und einer Liste der Fahrzeuge auf der Brücke.
      + Methode `TryEnter(Vehicle v)`: Fahrzeug nur hinzufügen, wenn die Last danach zulässig ist; Rückgabewert `true` oder `false`.
    ],
    extension: [Methode `Leave(Vehicle v)` und Ausgabe der aktuellen Auslastung in Prozent.],
  ),

  // --- Klassen ------------------------------------------------------------------

  (
    topic: "Klassen",
    title: "Vektoren in der Ebene",
    summary: [`Vector2D` mit Betrag, Summe, Skalierung, Skalarprodukt, `ToString()`],
    body: [
      Erstellen Sie eine Klasse `Vector2D` mit den Attributen `X` und `Y` und den Methoden

      - `Length()` – Betrag des Vektors
      - `Add(Vector2D v)` – Summe als neuer Vektor
      - `Scale(double s)` – mit $s$ multiplizierter Vektor
      - `Dot(Vector2D v)` – Skalarprodukt $x_1 x_2 + y_1 y_2$

      Überschreiben Sie `ToString()` und testen Sie die Klasse, z.B. mit der Resultierenden zweier Kräfte.
    ],
    extension: [Methode `AngleTo(Vector2D v)`, die den Winkel zwischen zwei Vektoren in Grad liefert: $cos phi = (a dot b) \/ (|a| |b|)$.],
  ),

  (
    topic: "Klassen",
    title: "Intervalle",
    summary: [`Interval` mit `Contains()` und `Overlaps()`, Schnittmenge oder `null`],
    body: [
      Ein Intervall $[a, b]$ beschreibt z.B. einen zulässigen Wertebereich.

      + Klasse `Interval` mit Attributen `Min` und `Max`.
      + Methoden `Length()` und `Contains(double x)`.
      + Methode `Overlaps(Interval other)`, die prüft, ob sich zwei Intervalle überschneiden.
      + Testen Sie mit mehreren Fällen: überlappend, getrennt, eines im anderen enthalten.
    ],
    extension: [Methode `Intersection(Interval other)`, die die Schnittmenge als neues Intervall zurückgibt – oder `null`, falls es keine gibt.],
  ),

  (
    topic: "Klassen und Verzweigungen",
    title: "Regenrückhaltebecken",
    summary: [Füllen mit Überlauf, Entleeren nicht unter 0, Simulation mit Array],
    body: [
      Ein Becken hat ein Fassungsvermögen (m³) und einen aktuellen Füllstand (m³).

      + Klasse `Basin` mit Attributen `Capacity` und `Volume` (anfangs leer).
      + Methode `Fill(double v)`: füllt das Becken, gibt die Menge zurück, die überläuft.
      + Methode `Drain(double v)`: entleert das Becken, aber nicht unter 0; gibt die tatsächlich abgelassene Menge zurück.
    ],
    extension: [Simulieren Sie mit einem Array von stündlichen Zuflüssen und konstantem Abfluss den Verlauf. Wie viel läuft insgesamt über?],
  ),

  // --- Listen ---------------------------------------------------------------------

  (
    topic: "Listen",
    title: "Polygone",
    summary: [`Polygon` aus `Point`-Liste, Umfang (geschlossen), Fläche mit Trapezformel],
    body: [
      + Klasse `Point` mit Attributen `X` und `Y`.
      + Klasse `Polygon` mit einer `List<Point>` und Methode `Add(Point p)`.
      + Methode `Perimeter()`, die den Umfang berechnet. Achtung: Das Polygon ist geschlossen.
      + Testen Sie mit einem Rechteck und einem Dreieck.
    ],
    extension: [Methode `Area()` mit der Gaußschen Trapezformel (Index $n$ entspricht wieder $0$): $ A = 1 / 2 lr(|sum_(i=0)^(n-1) (x_i y_(i+1) - x_(i+1) y_i)|) $],
  ),

  (
    topic: "Listen",
    title: "Messreihe",
    summary: [Mittelwert, Maximum, Anzahl Überschreitungen, Standardabweichung],
    body: [
      An einem Bauwerk werden Verformungen gemessen.

      + Klasse `MeasurementSeries` mit einer `List<double>` der Messwerte.
      + Methoden `Add(double value)`, `Mean()` und `Max()`.
      + Methode `CountAbove(double limit)`, die zählt, wie viele Werte einen Grenzwert überschreiten.

      Programmieren Sie `Mean()` und `CountAbove()` mit einer Schleife.
    ],
    extension: [Methode `StandardDeviation()`: $ s = sqrt(1 / (n-1) sum_(i=1)^n (x_i - overline(x))^2) $],
  ),

  (
    topic: "Listen",
    title: "Profilauswahl",
    summary: [Erstes IPE-Profil mit ausreichendem $W_y$ suchen, sonst `null`],
    body: [
      Gesucht ist das leichteste IPE-Profil mit ausreichendem Widerstandsmoment.

      + Klasse `SteelProfile` mit `Name` und `Wy` (in cm³).
      + Klasse `ProfileCatalog` mit einer Liste von Profilen, aufsteigend nach Größe.
      + Methode `FindSuitable(double requiredWy)` gibt das erste passende Profil zurück, sonst `null`.

      #text(size: 8.5pt)[IPE 100: 34.2 · IPE 120: 53.0 · IPE 140: 77.3 · IPE 160: 109 · IPE 180: 146 · IPE 200: 194]
    ],
    extension: [Erforderliches $W_y$ aus dem Moment berechnen: $W_"y,erf" = M_"Ed" \/ f_"yd"$ mit $f_"yd" = 23.5$ kN/cm².],
  ),

  (
    topic: "Listen",
    title: "Wärmedurchgangskoeffizient",
    summary: [Wandschichten mit $R = d \/ lambda$, U-Wert; Dämmdicke mit Schleife erhöhen],
    results: [$U = 0.265$ W/(m² K); $U <= 0.20$ ab 17 cm],
    body: [
      Eine Wand besteht aus Schichten mit Dicke $d$ (m) und Wärmeleitfähigkeit $lambda$ (W/(m K)).

      + Klasse `Layer` mit Name, `Thickness`, `Lambda` und Methode `Resistance()`: $R = d \/ lambda$.
      + Klasse `Wall` mit `List<Layer>` und Methode `UValue()`:

        $ U = 1 / (R_"si" + sum R_i + R_"se") quad "mit" R_"si" = 0.13, R_"se" = 0.04 $
      + Beispiel: 17.5 cm Kalksandstein ($lambda = 0.99$), 12 cm Dämmung ($lambda = 0.035$).
    ],
    extension: [Erhöhen Sie die Dämmdicke in 1-cm-Schritten, bis $U <= 0.20$ ist.],
  ),

  (
    topic: "Listen",
    title: "Betondruckfestigkeit",
    summary: [Festigkeit aus Bruchlast, Mittel- und Minimalwert, Prüfkriterium],
    results: [36.2, 34.5, 32.5 N/mm², Mittel 34.4 → erfüllt],
    body: [
      Bei Zylinderproben ($d = 150$ mm) wird die Bruchlast $F$ in kN gemessen.

      + Klasse `Specimen` mit Bruchlast und Methode `Strength()` in N/mm².
      + Klasse `TestSeries` mit Liste von Proben, Methoden `MeanStrength()` und `MinStrength()`.
      + Methode `Satisfies(double fck)`: erfüllt, wenn Mittelwert $>= f_"ck" + 4$ und jeder Einzelwert $>= f_"ck" - 4$.
      + Testen Sie mit drei Proben: 640 kN, 610 kN, 575 kN gegen C30/37.
    ],
  ),

  (
    topic: "Listen",
    title: "Bauzeitenplan",
    summary: [Vorgänge mit Start und Dauer, Gesamtdauer, laufende Vorgänge an einem Tag],
    body: [
      + Klasse `Activity` mit `Name`, `Start` und `Duration` (in Arbeitstagen) und Methode `End()`.
      + Klasse `Schedule` mit einer Liste von Vorgängen und Methode `Add(Activity a)`.
      + Methode `TotalDuration()`: Ende des Vorgangs, der zuletzt fertig wird.
      + Testen Sie z.B. mit Erdarbeiten, Fundamente, Rohbau, Dach.
    ],
    extension: [Methode `ActiveOn(int day)`, die eine Liste aller Vorgänge zurückgibt, die an diesem Tag laufen.],
  ),

  // --- Dictionary und HashSet ------------------------------------------------

  (
    topic: "Dictionary",
    title: "Eigengewicht nach Material",
    summary: [Wichten im `Dictionary` nachschlagen, unbekanntes Material abfangen],
    body: [
      + Legen Sie ein `Dictionary<string, double>` mit Wichten in kN/m³ an: Beton 25, Stahl 78.5, Holz 5.
      + Klasse `Component` mit `Name`, `Material` (Text) und `Volume` (m³).
      + Berechnen Sie für eine Liste von Bauteilen das Gesamtgewicht, indem Sie die Wichte im Dictionary nachschlagen.
      + Was passiert bei einem unbekannten Material? Fangen Sie den Fall mit `ContainsKey` ab.
    ],
    extension: [Geben Sie das Gewicht getrennt nach Material aus (zweites Dictionary).],
  ),

  (
    topic: "Verzweigungen",
    title: "Energieeffizienzklassen",
    summary: [Klasse nach spezifischem Heizwärmebedarf mit `if`/`else if`, Zählen mit `Dictionary`],
    body: [
      + Klasse `Building` mit `Name`, beheizter Fläche (m²) und Jahresheizwärmebedarf (kWh/a).
      + Methode `SpecificDemand()`: Bedarf pro m² und Jahr.
      + Methode `EfficiencyClass()` nach der Tabelle:
      #align(center, table(
        columns: 5,
        inset: (x: 5pt, y: 3pt),
        stroke: 0.4pt + luma(150),
        [A+], [A], [B], [C], [D],
        [< 30], [< 50], [< 75], [< 100], [≥ 100],
      ))
    ],
    extension: [Zählen Sie für eine Liste von Gebäuden mit einem `Dictionary<string, int>`, wie viele in jede Klasse fallen.],
  ),

  (
    topic: "Dictionary und HashSet",
    title: "Verkehrszählung",
    summary: [Verschiedene Fahrzeuge mit `HashSet`, Durchfahrten je Typ mit `Dictionary`],
    body: [
      An einer Zählstelle werden Fahrzeuge mit Kennzeichen und Typ („Pkw“, „Lkw“, „Bus“) erfasst. Ein Fahrzeug kann mehrfach vorbeikommen.

      + Klasse `Vehicle` mit `Plate` und `Type`.
      + Klasse `Count` mit einer Liste der erfassten Fahrzeuge.
      + Methode `DistinctVehicles()`: Anzahl verschiedener Fahrzeuge (mit `HashSet<string>`).
      + Methode `CountByType()`: Anzahl Durchfahrten je Typ als `Dictionary<string, int>`.
    ],
  ),

  // --- Kontrollstrukturen und Arrays ------------------------------------------

  (
    topic: "Schleifen",
    title: "Nullstelle mit Bisektion",
    summary: [Bisektionsverfahren mit `while` für $x^3 - 2x - 5$],
    results: [$x approx 2.0946$ nach 27 Schritten],
    body: [
      Gesucht ist die Nullstelle von $f(x) = x^3 - 2x - 5$ im Intervall $[2, 3]$.

      *Verfahren:* Mittelpunkt $m$ des Intervalls bestimmen. Haben $f(a)$ und $f(m)$ unterschiedliche Vorzeichen, liegt die Nullstelle in $[a, m]$, sonst in $[m, b]$. Wiederholen, bis das Intervall kürzer als $10^(-8)$ ist.

      + Programmieren Sie das Verfahren mit einer `while`-Schleife.
      + Geben Sie das Ergebnis und die Anzahl der Schritte aus.
    ],
    extension: [Wie viele Schritte erwarten Sie vorab? Begründen Sie.],
  ),

  (
    topic: "Schleifen",
    title: "Momentenverlauf",
    summary: [Tabelle $M(x)$ mit `for`, Maximum in der Schleife bestimmen],
    results: [$q L^2 \/ 8$ nur bei geradem $n$ exakt],
    body: [
      Für einen Einfeldträger unter Gleichstreckenlast gilt
      $ M(x) = (q x (L - x)) / 2 $

      + Klasse `SimpleBeam` mit `Length` und `Q` und Methode `Moment(double x)`.
      + Geben Sie mit einer `for`-Schleife eine Tabelle mit $x$ und $M(x)$ an $n + 1$ gleichmäßig verteilten Stellen aus.
      + Ermitteln Sie in der Schleife das größte Moment und vergleichen Sie mit $q L^2 \/ 8$.
    ],
    extension: [Was ändert sich, wenn $n$ ungerade ist?],
  ),

  (
    topic: "Arrays",
    title: "Polynome",
    summary: [Koeffizienten-Array, Auswertung, Ableitung als neues Objekt],
    results: [$p'(x) = -3 + 4x$],
    body: [
      Ein Polynom $p(x) = a_0 + a_1 x + a_2 x^2 + dots + a_n x^n$ wird durch seine Koeffizienten beschrieben.

      + Klasse `Polynomial` mit Attribut `double[] Coefficients`.
      + Methode `Evaluate(double x)` wertet das Polynom aus.
      + Methode `Derivative()` gibt die Ableitung als neues `Polynomial` zurück.
      + Testen Sie mit $p(x) = 1 - 3x + 2x^2$.
    ],
    extension: [Methode `Add(Polynomial other)` für Polynome mit unterschiedlichem Grad.],
  ),

  // --- Vererbung -----------------------------------------------------------------

  (
    topic: "Vererbung",
    title: "Knoten und Stäbe",
    summary: [`Node` erbt von `Point` mit `base`, Stablängen eines Fachwerks],
    results: [`Point p = new Node(...)` möglich, umgekehrt nicht],
    body: [
      + Klasse `Point` mit `X`, `Y` und Methode `DistanceTo(Point other)`.
      + Klasse `Node`, die von `Point` erbt und zusätzlich eine Knotennummer hat. Rufen Sie den Konstruktor der Basisklasse mit `base` auf.
      + Klasse `Bar` mit Anfangs- und Endknoten und Methode `Length()`.
      + Erstellen Sie ein Dreiecksfachwerk und berechnen Sie die Gesamtlänge aller Stäbe.
    ],
    extension: [Welche Variablentypen sind möglich: `Point p = new Node(...)` oder `Node n = new Point(...)`? Begründen Sie.],
  ),

  // --- Listen und Schleifen ---------------------------------------------------

  (
    topic: "Listen und Schleifen",
    title: "Bewehrung",
    summary: [Stabgruppen mit Fläche in cm², Gesamtfläche, Nachweis; Stabanzahl mit `while`],
    results: [10.30 cm² ≥ 9.5 cm²; 4 Ø 20 nötig],
    body: [
      Die Bewehrung eines Stahlbetonquerschnitts besteht aus mehreren Stabgruppen.

      + Klasse `RebarGroup` mit Anzahl $n$ und Durchmesser $d$ (mm) und Methode `Area()` in cm²: $A_s = n dot pi d^2 \/ 4$.
      + Klasse `Reinforcement` mit einer Liste von Stabgruppen, Methoden `Add(RebarGroup g)` und `TotalArea()`.
      + Methode `IsSufficient(double requiredArea)`.
      + Testen Sie mit 4 Ø 16 + 2 Ø 12 gegen $A_"s,erf" = 9.5$ cm².
    ],
    extension: [Ermitteln Sie mit einer `while`-Schleife, wie viele Stäbe Ø 20 mindestens nötig sind, um $A_"s,erf"$ allein abzudecken.],
  ),

  // --- Umweltingenieurwesen ---------------------------------------------------

  (
    topic: "Abstrakte Klassen",
    title: "CO₂-Bilanz",
    summary: [Emissionsquellen Transport, Strom, Heizung mit `Co2()`, Anteile in Prozent],
    body: [
      Für ein Bauprojekt sollen die CO₂-Emissionen verschiedener Quellen bilanziert werden.

      + Abstrakte Klasse `EmissionSource` mit Attribut `Name` und abstrakter Methode `Co2()` in kg.
      + Unterklassen:
        - `Transport`: Strecke (km) × Emissionsfaktor (kg/km)
        - `Electricity`: Verbrauch (kWh) × 0.38 kg/kWh
        - `Heating`: Erdgas (kWh) × 0.20 kg/kWh
      + Klasse `Balance` mit Liste von Quellen und Methode `Total()`.
    ],
    extension: [Geben Sie für jede Quelle ihren Anteil an der Gesamtemission in Prozent aus.],
  ),

  (
    topic: "Abstrakte Klassen",
    title: "Regenabfluss",
    summary: [Flächen mit `RunoffCoefficient()`, Abfluss $Q = psi r A$ eines Einzugsgebiets],
    results: [$Q = 9.7$ l/s; mit Rasengitter 7.4 l/s],
    body: [
      Der Abfluss einer Fläche ist $Q = psi dot r dot A$ mit Abflussbeiwert $psi$, Regenspende $r$ in l/(s ha) und Fläche $A$ in ha.

      + Abstrakte Klasse `Surface` mit Attribut `Area` (m²) und abstrakter Methode `RunoffCoefficient()`.
      + Unterklassen `Roof` ($psi = 0.9$), `Asphalt` ($psi = 0.9$) und `Lawn` ($psi = 0.1$).
      + Klasse `Catchment` mit Liste von Flächen und Methode `Runoff(double r)` in l/s.
      + Testen Sie: Dach 400 m², Asphalt 250 m², Rasen 600 m², $r = 150$ l/(s ha).
    ],
    extension: [Wie ändert sich der Abfluss, wenn der Asphalt durch Rasengittersteine ($psi = 0.3$) ersetzt wird?],
  ),

  (
    topic: "Listen",
    title: "Feinstaubmessung",
    summary: [Überschreitungstage, Jahresmittel, Einhaltung der PM10-Grenzwerte],
    body: [
      Für PM10 gilt ein Tagesgrenzwert von 50 µg/m³, der höchstens 35-mal im Jahr überschritten werden darf.

      + Klasse `Station` mit `Name` und einer `List<double>` der Tagesmittelwerte.
      + Methode `ExceedanceDays(double limit)`: Anzahl der Tage über dem Grenzwert.
      + Methode `Complies()`: prüft, ob der Grenzwert eingehalten ist.
      + Methode `AnnualMean()`: Jahresmittelwert (Grenzwert 40 µg/m³).
    ],
    extension: [Speichern Sie mehrere Stationen in einer Liste und geben Sie alle Stationen aus, die einen der Grenzwerte nicht einhalten.],
  ),

  (
    topic: "Schleifen",
    title: "Lärmpegel addieren",
    summary: [Energetische Pegeladdition, Abstand für 55 dB mit `while`],
    results: [$L_"ges" = 77.1$ dB; 55 dB ab 128 m],
    body: [
      Schallpegel addieren sich nicht linear, sondern energetisch:
      $ L_"ges" = 10 dot log_10 (sum_i 10^(L_i \/ 10)) $

      + Klasse `NoiseSource` mit `Name` und `Level` (dB, gemessen in 10 m Abstand).
      + Klasse `Site` mit Liste von Quellen und Methode `TotalLevel()`.
      + Testen Sie mit zwei Maschinen zu 70 dB und einer zu 75 dB.
    ],
    extension: [Der Pegel nimmt mit dem Abstand ab: $L(s) = L_"ges" - 20 log_10 (s \/ 10 "m")$. Ab welchem Abstand (in 1-m-Schritten) wird 55 dB unterschritten?],
  ),

  (
    topic: "Schleifen",
    title: "Schadstoffabbau",
    summary: [Zeitschrittverfahren mit `while`, Vergleich mit exakter Lösung],
    results: [6.0 d ($Delta t = 0.1$ d); exakt 6.03 d],
    body: [
      In einem Gewässer wird ein Schadstoff mit der Rate $k$ abgebaut. Für einen kleinen Zeitschritt $Delta t$ gilt näherungsweise
      $ c(t + Delta t) = c(t) dot (1 - k Delta t) $

      + Simulieren Sie mit einer `while`-Schleife den Verlauf für $c_0 = 20$ mg/l, $k = 0.23$ 1/d und $Delta t = 0.1$ d.
      + Nach wie vielen Tagen ist $c < 5$ mg/l?
      + Vergleichen Sie mit der exakten Lösung $c(t) = c_0 e^(-k t)$.
    ],
    extension: [Wie verändert sich das Ergebnis mit $Delta t = 1$ d und $Delta t = 0.01$ d?],
  ),

  (
    topic: "Dictionary und HashSet",
    title: "Abfallbilanz",
    summary: [Masse je Abfallart mit `Dictionary`, Recyclingquote mit `HashSet`],
    body: [
      Auf einem Wertstoffhof werden Anlieferungen mit Abfallart und Masse (t) erfasst.

      + Klasse `Delivery` mit `Fraction` (z.B. „Papier“, „Glas“, „Restabfall“) und `Mass`.
      + Klasse `WasteBalance` mit Liste von Anlieferungen.
      + Methode `MassByFraction()`: Masse je Abfallart als `Dictionary<string, double>`.
      + Methode `RecyclingRate()`: Anteil der verwertbaren Abfallarten an der Gesamtmasse. Die verwertbaren Arten stehen in einem `HashSet<string>`.
    ],
  ),
)

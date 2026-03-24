// Halle nach https://bauforumstahl.de/wp-content/uploads/2024/02/Typenhallen_aus_Stahl2016_1_.pdf
string material = "Stahl";
string projektname = "Brücke Nord";
double stahlDichte = 7850.0;  // in kg/m³

// Stab 1
double laenge1 = 3.75;   // in m
double querschnitt1 = 0.0005;  // in m²

// Stab 2
double laenge2 = 2.40;
double querschnitt2 = 0.0008;

// Stab 3
double laenge3 = 5.10;
double querschnitt3 = 0.0005;

int anzahlStaebe = 3;

// Berechnungen
double gesamtvolumen = laenge1 * querschnitt1
                     + laenge2 * querschnitt2
                     + laenge3 * querschnitt3;
double masse = gesamtvolumen * stahlDichte;

// Ausgabe
Console.WriteLine();
Console.WriteLine($"Projekt: {projektname}");
Console.WriteLine($"Material: {material}");
Console.WriteLine($"Anzahl Stäbe: {anzahlStaebe}");
Console.WriteLine();
Console.WriteLine($"  Stab 1: Länge {laenge1} m, Querschnitt {querschnitt1} m²");
Console.WriteLine($"  Stab 2: Länge {laenge2} m, Querschnitt {querschnitt2} m²");
Console.WriteLine($"  Stab 3: Länge {laenge3} m, Querschnitt {querschnitt3} m²");
Console.WriteLine();
Console.WriteLine($"Gesamtvolumen: {gesamtvolumen:F6} m³");
Console.WriteLine($"Gesamtmasse:   {masse:F1} kg");

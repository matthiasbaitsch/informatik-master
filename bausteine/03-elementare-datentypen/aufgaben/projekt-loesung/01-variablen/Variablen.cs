// Ausgabebereich löschen, probieren Sie aus, was passiert, 
// wenn Sie diese Zeile auskommentieren
Console.Clear();

// So wird Text ausgegeben
Console.WriteLine("Guten Morgen Bochum!");

// Variablen werden mit dem Datentyp deklariert und bei Bedarf 
// gleich mit einem Wert belegt
int m;
double x = 1.5;
string s = "Welt";

// Variablen kann man später beliebig ändern
m = 2;
m = 3;
x = 0.33;

// Das funktioniert nur, wenn die Datentypen passen. Kommentieren
// Sie aus, was nicht geht! Wo könnte jeweils das Problem liegen?
x = m;
// x = "0.66";
m = 177;
// m = 0.33;
// s = 1999;

// Variablen kann man ausgeben
Console.WriteLine(m);

// Schöner ist es mit etwas Text
Console.WriteLine($"m: {m}");
Console.WriteLine($"x: {x} und s: {s}");

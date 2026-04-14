// Ausgabebereich löschen
Console.Clear();

// So wird Text ausgegeben
Console.WriteLine("Guten Morgen Bochum!");

// Variablen werden mit dem Datentyp deklariert und bei Bedarf 
// gleich mit einem Wert belegt
int count;
double baseLength = 1.5;
string greetingToTheWorld = "Hallo Welt!";

// Variablen kann man später beliebig ändern
count = 2;
count = 3;
baseLength = 0.33;

// Das funktioniert nur, wenn die Datentypen passen. Kommentieren
// Sie aus, was nicht geht! Wo könnte jeweils das Problem liegen?
baseLength = count;
// baseLength = "0.66";
count = 177;
// count = 0.33;
// greeting = 1999;

// Variablen kann man ausgeben
Console.WriteLine(count);

// Schöner ist es mit etwas Text
Console.WriteLine($"m: {count}");
Console.WriteLine($"x: {baseLength} und s: {greetingToTheWorld}");

// Mathematische Funktionen importieren, muss ganz oben stehen
using static System.Math;

// Variablen
int a = 3;
int b = 4;
double x = 2.5;
double y = 0.5;

// Operatoren (% ist Rest bei ganzzahligem Teilen)
int c = 1 + a * b + b / a + b % a;
double z = a * (0.1 + 0.2 + x / y);

Console.Clear();
Console.WriteLine($"c: {c}");
Console.WriteLine($"z: {z}");

// Mathematische Funktionen und Konstanten aus System.Math
double u = Sqrt(a * a + b * b);
double v = Log(E);
double w = Sin(PI);

Console.WriteLine($"u: {u}");
Console.WriteLine($"v: {v}");
Console.WriteLine($"w: {w}");

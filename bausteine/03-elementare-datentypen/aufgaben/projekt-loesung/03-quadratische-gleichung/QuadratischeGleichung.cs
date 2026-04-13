using static System.Math;

Console.Clear();

double a = 4;
double b = -4;
double c = -24;

Console.WriteLine("Quadratische Gleichung");
Console.WriteLine($"  {a}x² {b:+ #; - #}x {c:+ #; - #} = 0");

double p = b / a;
double q = c / a;

Console.WriteLine("Normalisierte Gleichung");
Console.WriteLine($"  x² {p:+ #; - #}x {q:+ #; - #} = 0");

double d = Pow(p / 2, 2) - q;
double x1 = -p / 2 + Sqrt(d);
double x2 = -p / 2 - Sqrt(d);

Console.WriteLine("Diskriminante");
Console.WriteLine($"  D  = {d}");
Console.WriteLine("Lösungen");
Console.WriteLine($"  x₁ = {x1}");
Console.WriteLine($"  x₂ = {x2}");
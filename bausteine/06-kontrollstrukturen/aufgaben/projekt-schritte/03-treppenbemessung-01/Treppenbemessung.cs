// Lauflänge und Geschosshöhe in m
double l = 4.70;
double h = 2.5;

string line = new string('─', 43);

Console.Clear();
Console.WriteLine("");
Console.WriteLine($"Treppenbemessung: Lauflänge l = {l} m, Geschosshöhe h = {h} m");
Console.WriteLine("");
Console.WriteLine($"Regelung nach DIN 18065");
Console.WriteLine($"         Steigung: 140 mm ≤    s   ≤ 210 mm");
Console.WriteLine($"         Auftritt: 230 mm ≤    a   ≤ 370 mm");
Console.WriteLine($"  Schrittmaßregel: 590 mm ≤ 2s + a ≤ 650 mm");

Console.WriteLine();
Console.WriteLine(line);
Console.WriteLine($"{"n",-6} {"s (mm)",-10} {"a (mm)",-10} {"2s+a (mm)",-12}");
Console.WriteLine(line);


for (int n = 2; n <= 18; n++)
{
    double s = 1000 * h / n;
    double a = 1000 * l / (n - 1);
    double sm = 2 * s + a;

    Console.WriteLine($"{n,-6} {s,-10:F0} {a,-10:F0} {sm,-12:F0}");

}

Console.WriteLine(line);

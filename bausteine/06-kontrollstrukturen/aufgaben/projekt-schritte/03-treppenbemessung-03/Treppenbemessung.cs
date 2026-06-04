double l = 4.70;
double h = 2.5;
string line = new string('─', 85);

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
Console.WriteLine($"{"n",-6} {"s (mm)",-10} {"a (mm)",-10} {"2s+a (mm)",-12}Ergebnis");
Console.WriteLine(line);

for (int n = 2; n <= 18; n++)
{
    double s = 1000 * h / n;
    double a = 1000 * l / (n - 1);
    double sm = 2 * s + a;

    bool sOK = s >= 140 && s <= 210;
    bool aOK = a >= 230 && a <= 370;
    bool smOK = sm >= 590 && sm <= 650;

    if (sOK)
    {
        Console.Write($"{n,-6} {s,-10:F0} {a,-10:F0} {sm,-12:F0}");

        if (!aOK)
        {
            Console.Write("Auftritt");
        }
        if (!aOK && !smOK)
        {
            Console.Write($" und ");
        }
        if (!smOK)
        {
            Console.Write($"Schrittmaß");
        }
        if (aOK && smOK)
        {
            Console.WriteLine($"Gültig");
        }
        else
        {
            Console.WriteLine($" nicht eingehalten");
        }
    }
}

Console.WriteLine(line);

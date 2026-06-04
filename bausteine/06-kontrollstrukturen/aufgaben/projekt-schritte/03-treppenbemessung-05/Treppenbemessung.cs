using BoDraw;

double l = 6;
double h = 3;
string line = new string('─', 85);

Console.Clear();
Console.WriteLine("");
Console.WriteLine($"Treppenbemessung: Lauflänge l = {l} m, Geschosshöhe h = {h} m");
Console.WriteLine("");
Console.WriteLine($"Regelung nach DIN 18065");
Console.WriteLine($"         Steigung: 140 mm ≤    s   ≤ 210 mm");
Console.WriteLine($"         Auftritt: 230 mm ≤    a   ≤ 370 mm");
Console.WriteLine($"  Schrittmaßregel: 590 mm ≤ 2s + a ≤ 650 mm");

bool foundS = false;
bool foundOK = false;

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
        if (!foundS)
        {
            Console.WriteLine();
            Console.WriteLine(line);
            Console.WriteLine($"{"n",-6} {"s (mm)",-10} {"a (mm)",-10} {"2s+a (mm)",-12}Ergebnis");
            Console.WriteLine(line);
            foundS = true;
        }

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
            foundOK = true;
            Console.WriteLine($"Gültig");

            double d = 1;
            BoDrawApp app = new BoDrawApp();
            Polygon p1 = new Polygon();
            Polyline p2 = new Polyline();

            s /= 1000;
            a /= 1000;

            p1.LineColor = null;
            p2.Thickness = 3;
            p1.AddPoint(-d, -2 * a);
            p1.AddPoint(-d, 0);
            p2.AddPoint(-d, 0);
            p1.AddPoint(0, 0);
            p2.AddPoint(0, 0);
            p1.AddPoint(0, s);
            p2.AddPoint(0, s);
            for (int i = 0; i < n - 1; i++)
            {
                p1.AddPoint((i + 1) * a, (i + 1) * s);
                p1.AddPoint((i + 1) * a, (i + 2) * s);
                p2.AddPoint((i + 1) * a, (i + 1) * s);
                p2.AddPoint((i + 1) * a, (i + 2) * s);
            }
            p1.AddPoint(l + d, h);
            p2.AddPoint(l + d, h);
            p1.AddPoint(l + d, -2 * a);

            Text text = new Text("Treppenbemessung", -d, h, h / 15);
            text.VJust = 1;
            text.AppendLine($"l = {l} m, h = {h} m");
            text.AppendLine($"s = {1000 * s:0} mm, a = {1000 * a:0} mm");
            text.AppendLine($"n = {n}");

            app.Add(text, p1, p2);
            app.SaveImage($"treppe-{n}.png");
        }
        else
        {
            Console.WriteLine($" nicht eingehalten");
        }
    }
}

if (!foundS)
{
    Console.WriteLine("");
    Console.WriteLine("Treppe kann ohne Podest nicht gebaut werden!");
}
else if (!foundOK)
{
    Console.WriteLine(line);
    Console.WriteLine("");
    Console.WriteLine("Keine zulässige Auslegung gefunden");
}
Console.WriteLine("");
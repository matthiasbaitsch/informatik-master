using BoDraw;

using static System.Math;

// Funktion f - kann z.B. mit f(3) ausgewertet werden
double f(double x) => Log(2 - x * x);

Polyline l3 = new Polyline();
l3.Color = Colors.DarkMagenta;
l3.Thickness = 1.5;

double x = 0.2;
while (Abs(x - f(x)) > 1e-10)
{
    l3.AddPoint(x, x);
    l3.AddPoint(x, f(x));
    x = f(x);
}

Circle c = new Circle(x, f(x), 0.005);
c.FillColor = Colors.Red;

Console.WriteLine($"x = {x}, f(x) = {f(x)}");

// Zeichnen
int n = 20;
double a = 0.8;
BoDrawApp app = new BoDrawApp();
Line l1 = new Line(0, 0, a, a);
l1.Color = Colors.SteelBlue;
l1.Thickness = 2;
Polyline l2 = new Polyline();
for (int i = 0; i < n; i++)
{
    double xi = i * a / (n - 1);
    double yi = f(xi);
    l2.AddPoint(xi, yi);
}
l2.Color = Colors.DarkOrange;
l2.Thickness = 2;
app.Add(new Rectangle(0, 0, a, a));
app.Add(l1, l2, c, l3);
app.SaveImage("fixpunktiteration.png");
using BoDraw;

using static System.Math;

int n = 20;
double a = 0;
double b = PI;

double h = (b - a) / n;
double integral = 0;

BoDrawApp app = new BoDrawApp();

// Rectangles
for (int i = 0; i < n; i++)
{
    double xi = a + (i + 0.5) * h;
    integral += h * Sin(xi);

    Rectangle r = new Rectangle(xi - h / 2, 0, xi + h / 2, Sin(xi));
    r.FillColor = Colors.BlanchedAlmond;
    app.Add(r);
}
Console.WriteLine($"Integral I ≈ {integral}");

// Curve
Polyline p = new Polyline();
n = 500;
h = (b - a) / n;

p.AddPoint(0, 0);
for (int i = 1; i <= n; i++)
{
    double xi = a + i * h;
    p.AddPoint(xi, Sin(xi));
}
p.Thickness = 2;
p.Color = Colors.Red;
app.Add(p);

// Save image
app.SaveImage("integration-2.png");
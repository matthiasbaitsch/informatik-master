using BoDraw;

using static System.Math;

int n = 20;
var f = Sin;
double a = 0;
double b = PI;

double h = (b - a) / n;
double sum = 0;

BoDrawApp app = new BoDrawApp();

// Draw rectangles
for (int i = 0; i < n; i++)
{
    double xi = a + (i + 0.5) * h;
    double yi = f(xi);

    sum += h * yi;

    Rectangle r = new Rectangle(xi - h / 2, 0, xi + h / 2, yi);
    r.LineThickness = 2;
    r.FillColor = Colors.BlanchedAlmond;
    app.Add(r);
}

// Draw curve with more points
Polyline p = new Polyline();
n = 500;
h = (b - a) / n;

p.AddPoint(0, 0);
for (int i = 1; i <= n; i++)
{
    double xi = a + i * h;
    double yi = f(xi);

    p.AddPoint(xi, yi);
}
p.Thickness = 4;
p.Color = Colors.Red;
app.Add(p);

// Results
app.SaveImage("integration-2.png");
Console.WriteLine($"Integral I ≈ {sum}");

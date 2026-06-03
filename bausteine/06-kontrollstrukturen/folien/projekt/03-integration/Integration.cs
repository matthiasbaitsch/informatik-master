using static System.Math;

int n = 20;
double a = 0;
double b = PI;

double h = (b - a) / n;
double integral = 0;

for (int i = 0; i < n; i++)
{
    double xi = a + (i + 0.5) * h;
    integral += h * Sin(xi);
}
Console.WriteLine($"Integral I ≈ {integral}");
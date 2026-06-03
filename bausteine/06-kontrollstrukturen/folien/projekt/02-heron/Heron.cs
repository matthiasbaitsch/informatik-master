using static System.Math;

double x = 4.0;
double a = 1.5;
double b;

while (Abs(a * a - x) > 1e-10)
{
    b = x / a;
    Console.WriteLine($" a = {a,-18}  b = {b,-18}");
    a = 0.5 * (a + b);
}

Console.WriteLine($"\nDie Wurzel aus {x} beträgt in etwa {a}");
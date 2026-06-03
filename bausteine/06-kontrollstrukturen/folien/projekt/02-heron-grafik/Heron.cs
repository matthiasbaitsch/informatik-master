using BoDraw;
using static System.Math;

BoDrawApp app = new BoDrawApp();

double p = 0.0;
double x = 4.0;
double a = 1.5;
double b;

while (Abs(a * a - x) > 1e-12)
{
    b = x / a;

    Rectangle rect = new Rectangle(p, 0, p + a, b);
    Text text = new Text($"{a,6:0.0000} x {b,6:0.0000}", p + a / 2, 0, 0.2);
    text.VJust = 1.2;
    text.HJust = 0.5;
    app.Add(rect, text);

    p += a + 0.5;
    a = 0.5 * (a + b);
}

Text t = new Text($"Alle Flächen haben den Inhalt x = {x}", 2.0, x / 1.5, 0.3);
t.VJust = 1.0;
app.Add(t);

app.SaveImage("heron.png", 1200);
// app.Show();

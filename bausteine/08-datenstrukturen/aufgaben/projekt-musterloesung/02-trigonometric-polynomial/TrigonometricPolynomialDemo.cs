using BoDraw;
using static System.Math;

TrigonometricPolynomial p = new TrigonometricPolynomial();
p.AddCoefficient(-5, new Complex(0.4, 0));
p.AddCoefficient(1, new Complex(1, 0));
p.AddCoefficient(7, new Complex(0.25, 0));

p.Evaluate(0.1).Print("p(0.1)");
Console.WriteLine($"Grad: {p.Degree()}");
Console.WriteLine($"Real: {p.IsReal()}");

BoDrawApp app = new BoDrawApp();

p.Plot(app, 1000);
p.PlotArrows(app, 0.1 * PI);
p.PlotArrows(app, 0.35 * PI);
p.PlotArrows(app, PI);
// p.PlotComponents(app, 1000);
app.SaveImage("trigonometric-polynomial.png");
// app.Show();
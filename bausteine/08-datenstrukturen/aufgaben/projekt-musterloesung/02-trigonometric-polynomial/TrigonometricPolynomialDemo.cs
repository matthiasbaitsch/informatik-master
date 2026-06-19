using BoDraw;

TrigonometricPolynomial p = new TrigonometricPolynomial();

p.AddCoefficient(-1, new Complex(1, -1));
p.AddCoefficient(1, new Complex(1, 2));

p.Evaluate(0.1).Print("p(0.1)");
Console.WriteLine($"Real: {p.IsReal()}");

BoDrawApp app = new BoDrawApp();
p.PlotComponents(app, 1000);
app.SaveImage("trigonometric-polynomial.png");
app.Show();
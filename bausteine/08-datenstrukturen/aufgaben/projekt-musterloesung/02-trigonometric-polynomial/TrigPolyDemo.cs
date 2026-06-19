using BoDraw;

TrigPoly p = new TrigPoly();

p.AddCoefficient(1, new Complex(1, 1));
p.AddCoefficient(5, new Complex(2, 2));

p.Evaluate(0.1).Print("p(0.1)");

BoDrawApp app = new BoDrawApp();
p.Plot(app, 1000);
app.SaveImage("test.png");
using BoDraw;

Circle c = new Circle(0, 0, 1);
c.FillColor = Colors.LightGoldenrodYellow;
Rectangle r1 = new Rectangle(1.1, -1, 3.1, 1);
r1.FillColor = Colors.HotPink;
Rectangle r2 = r1;
r2.Move(2.2, 0);
r2.FillColor = Colors.SteelBlue;

BoDrawApp app = new BoDrawApp();
app.Add(c, r1, r2);
app.Show();

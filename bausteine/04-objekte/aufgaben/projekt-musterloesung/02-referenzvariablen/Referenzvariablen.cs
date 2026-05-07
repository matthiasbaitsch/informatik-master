using BoDraw;

Circle c1;
Circle c2 = new Circle(0, 0, 1);
Circle c3 = new Circle(2, 0, 1);
BoDrawApp app = new BoDrawApp();

app.Add(c2, c3);

c1 = c3;
c1.FillColor = Colors.HotPink;
c3 = c2;
c3.FillColor = Colors.SkyBlue;
c1 = c3;
c1.Scale(0.5);

app.Show();

using BoDraw;

Rectangle r1 = new Rectangle(0, 0, 1, 1);
r1.FillColor = Colors.HotPink;
Rectangle r2 = new Rectangle(1, 0, 2, 1);
r2.FillColor = Colors.Orange;
Rectangle r3 = new Rectangle(0, 1, 1, 2);
r3.FillColor = Colors.PaleVioletRed;
Rectangle r4 = new Rectangle(1, 1, 2, 2);
r4.FillColor = Colors.DarkRed;

BoDrawApp app = new BoDrawApp();
app.Add(r1, r2, r3, r4);
app.Show();

using BoDraw;

Image image = new Image("assets/hs-bo_logo_en.png", 0, 0, 400);

Rectangle rectangle = new Rectangle(-20, -20, image.Width + 20, image.Height + 20);
rectangle.LineThickness = 8;
rectangle.FillColor = Colors.Linen;
rectangle.LineColor = Colors.OrangeRed;

Text text = new Text("BoDraw ist ein Zeichenpaket...", -20, -40);
text.Color = Colors.DarkBlue;
text.FontSize = 12;

Polygon s1 = new Polygon();
s1.AddPoint(6, 0);
s1.AddPoint(1, 1);
s1.AddPoint(1, 5);
s1.AddPoint(-1, 1);
s1.AddPoint(-4, 1);
s1.AddPoint(-1, -1);
s1.AddPoint(-1, -6);
s1.AddPoint(1, -1);
s1.Scale(3);
s1.Move(-20, image.Height + 20);
s1.LineThickness = 1;
s1.FillColor = Colors.Lime;

Polygon s2 = (Polygon)s1.Copy(image.Width + 40, 0);
s2.LineColor = Colors.DarkBlue;
s2.FillColor = Colors.Orange;

BoDrawApp app = new BoDrawApp();
app.Background = Colors.White;
app.Add(text, rectangle, image, s1, s2);
app.Show();

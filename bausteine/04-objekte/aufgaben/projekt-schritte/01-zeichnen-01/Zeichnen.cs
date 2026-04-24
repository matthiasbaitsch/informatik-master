using BoDraw;

Image image = new Image("assets/hs-bo_logo_en.png", 0, 0, 400);

Rectangle rectangle = new Rectangle(-20, -20, image.Width + 20, image.Height + 20);
rectangle.LineThickness = 8;
rectangle.FillColor = Colors.Linen;
rectangle.LineColor = Colors.OrangeRed;

Text text = new Text("BoDraw ist ein Zeichenpaket...", -20, -40);
text.Color = Colors.DarkBlue;
text.FontSize = 12;

BoDrawApp app = new BoDrawApp();
app.Add(text, rectangle, image);
app.Show();

using BoDraw;

Image image = new Image("assets/hs-bo_logo_en.png", 0, 0, 400);

Rectangle rectangle = new Rectangle(-20, -20, image.Width + 20, image.Height + 20);

Text text = new Text("BoDraw ist ein Zeichenpaket...", -20, -40);

BoDrawApp app = new BoDrawApp();
app.Add(text, image, rectangle);
app.Show();

using BoDraw;

BoDrawApp app = new BoDrawApp();
Beam beam = new Beam(8, "Free", "Fixed", 4);
beam.Draw(app);
// app.Show();
app.SaveImage("beam.png");

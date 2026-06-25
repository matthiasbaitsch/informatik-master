using BoDraw;

BoDrawApp app = new BoDrawApp();
Beam beam = new Beam(8, "Free", "Fixed", 4);
// beam.Section = new ISection(0.2, 0.4, 0.05, 0.01);
beam.Draw(app);
// app.Show();
app.SaveImage("beam-with-section.png", 1200);

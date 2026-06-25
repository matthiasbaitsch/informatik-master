using BoDraw;
double a = 0.4; // Symbolgröße

// Einfeldträger
Structure beam = new Structure(a);
beam.Add(new Beam(0, 0, 0, 4));
beam.Add(new Beam(4, 0, 0, 4));
beam.Add(new MomentHinge(4, 0));
beam.Add(new PinnedSupport(0, 0, 0));
beam.Add(new FixedSupport(8, 0, 90));
beam.Add(new Load(0, 0, 0, 8, 1.5));

// Rahmen
Structure frame = new Structure(a);
frame.Add(new Beam(0, 0, 90, 5));
frame.Add(new Beam(0, 5, 0, 8));
frame.Add(new Beam(8, 5, -90, 5));
frame.Add(new FixedSupport(0, 0, 0));
frame.Add(new Spring(8, 0, 0));
frame.Add(new Spring(8, 0, 90));
frame.Add(new Load(0, 0, 90, 5, 0.5));
frame.Add(new Load(0, 5, 0, 8, 1.5));

// Layout und anzeigen
BoDrawApp app = new BoDrawApp();
GridLayout layout = new GridLayout(4, 0);
layout.Add(0, 0, beam.Draw());
layout.Add(0, 1, frame.Draw());
app.Add(layout);

app.SaveImage("sysdraw-extension.png", 1200);
// app.Show();
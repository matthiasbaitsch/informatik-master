using BoDraw;
double a = 0.4; // Symbolgröße

// Einfeldträger
Beam b1 = new Beam(0, 0, 0, 8);
PinnedSupport s11 = new PinnedSupport(0, 0, 0);
FixedSupport s12 = new FixedSupport(8, 0, 90);
Load l1 = new Load(0, 0, 8, 0, 1.5);
Group sys1 = new Group(b1.Draw(a), s11.Draw(a), s12.Draw(a), l1.Draw(a));

// Rahmen
Beam b21 = new Beam(0, 0, 90, 5);
Beam b22 = new Beam(0, 5, 0, 8);
Beam b23 = new Beam(8, 5, -90, 5);
FixedSupport s21 = new FixedSupport(0, 0, 0);
FixedSupport s22 = new FixedSupport(8, 0, 0);
Load l21 = new Load(0, 0, 5, 90, 0.5);
Load l22 = new Load(0, 5, 8, 0, 1.5);
Group sys2 = new Group(b21.Draw(a), b22.Draw(a), b23.Draw(a), s21.Draw(a), s22.Draw(a), l21.Draw(a), l22.Draw(a));

// Layout und anzeigen
BoDrawApp app = new BoDrawApp();
GridLayout layout = new GridLayout(4, 0);
layout.Add(0, 0, sys1);
layout.Add(0, 1, sys2);
app.Add(layout);
app.Show();


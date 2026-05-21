using BoDraw;

SteelHall hall = new SteelHall("Halle S2-12-075");
hall.RoofPitch = 3;
hall.NumberOfFrames = 8;

BoDrawApp app = new BoDrawApp();
hall.Draw(app);
app.Show();
using BoDraw;

TimeSeries timeSeries = DWD.ReadTemperature("data/produkt_tu_stunde_19510101_20251231_01303.txt");
timeSeries.Repair(-60, 60);

// Auf zwei Jahre reduzieren
timeSeries = timeSeries.Clip(DateTime.Parse("1.1.2001"), DateTime.Parse("1.1.2006"));
timeSeries.PrintSummary();

BoDrawApp app = new BoDrawApp();
timeSeries.Plot(app);
// app.Show();
app.SaveImage("time-series-temperature.png");
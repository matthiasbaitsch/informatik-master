using BoDraw;

TimeSeries timeSeries = new TimeSeries("data/produkt_tu_stunde_19510101_20251231_01303.txt");
timeSeries.Repair(-60, 60);
timeSeries = timeSeries.Clip("1.1.2000", "1.1.2001");
timeSeries.PrintSummary();

BoDrawApp app = new BoDrawApp();
timeSeries.Plot(app);
app.Show();

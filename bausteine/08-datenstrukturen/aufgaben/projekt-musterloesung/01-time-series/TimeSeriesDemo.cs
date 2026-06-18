
using BoDraw;

double dt = 0.1;

TimeSeries timeSeries = new TimeSeries(dt, [1.1, 1.2, 1.3, 1.01, 2.2, 2.1, 2.0]);

Console.WriteLine($"{timeSeries.Count()} values");
Console.WriteLine($"Duration: {timeSeries.Duration()}");
Console.WriteLine($"Min: {timeSeries.Min()}");
Console.WriteLine($"Max: {timeSeries.Max()}");

BoDrawApp app = new BoDrawApp();
timeSeries.Plot(app);
app.Show();
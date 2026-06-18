using BoDraw;

List<double> values = new List<double>();

foreach (string line in File.ReadAllLines("data/produkt_tu_stunde_19510101_20251231_01303.txt").Skip(1))
{
    string[] entries = line.Split(";");
    double value = Double.Parse(entries[3]);
    values.Add(value);
}

TimeSeries timeSeries = new TimeSeries(1, values.ToArray());

timeSeries.Repair(-60, 60);

Console.WriteLine($"{timeSeries.Count()} values");
Console.WriteLine($"Duration: {timeSeries.Duration()}");
Console.WriteLine($"Min: {timeSeries.Min()}");
Console.WriteLine($"Max: {timeSeries.Max()}");

BoDrawApp app = new BoDrawApp();
timeSeries.Plot(app);
app.Show();

Console.WriteLine(DateTime.Parse("1951010101"));

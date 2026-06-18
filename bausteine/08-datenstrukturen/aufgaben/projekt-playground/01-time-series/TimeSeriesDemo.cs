
using BoDraw;

TimeSeries ts = new TimeSeries(
    DateTime.Parse("1.1.2000"),
    TimeSpan.FromSeconds(1),
    [1.1, 1.2, 1.3, 1.01, 2.2, 2.1, 2.0, -10, 3, 2, 1.1, 3.3, 4.7]
);

ts.PrintSummary();

BoDrawApp app = new BoDrawApp();
ts.Plot(app);
// app.Show();
app.SaveImage("time-series.png");

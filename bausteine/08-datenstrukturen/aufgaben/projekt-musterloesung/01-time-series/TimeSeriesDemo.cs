
using BoDraw;

double dt = 0.1;

TimeSeries timeSeries = new TimeSeries(
    DateTime.Now,
    TimeSpan.FromSeconds(1), [1.1, 1.2, 1.3, 1.01, 2.2, 2.1, 2.0]
);


BoDrawApp app = new BoDrawApp();
timeSeries.Plot(app);
app.Show();
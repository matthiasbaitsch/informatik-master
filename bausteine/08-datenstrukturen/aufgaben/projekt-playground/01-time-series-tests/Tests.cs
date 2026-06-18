namespace time_series_tests;

public class Tests
{

    private TimeSeries timeSeries = new TimeSeries(
        DateTime.Parse("1.1.2026"),
        TimeSpan.FromSeconds(1),
        [1.1, 1.2, 1.3, 1.01, 2.2, 2.1, 20.0]
    );


    [Fact]
    public void DWDTests()
    {
        Assert.Equal(DateTime.Parse("1.1.1951 1:0:0"), DWD.ParseDate("1951010101"));
        Assert.Equal(DateTime.Parse("31.12.1951 23:0:0"), DWD.ParseDate("1951123123"));
    }

    [Fact]
    public void NTests()
    {
        Assert.Equal(7, this.timeSeries.N());
    }

    [Fact]
    public void DurationTests()
    {
        Assert.Equal(TimeSpan.FromSeconds(6), this.timeSeries.Duration());
    }

    [Fact]
    public void TimestampTests()
    {
        Assert.Equal(DateTime.Parse("1.1.2026 0:0:6"), this.timeSeries.Timestamp(6));
    }

    [Fact]
    public void TimeInSecondsTests()
    {
        Assert.Equal(1.0, this.timeSeries.TimeInSeconds(1) - this.timeSeries.TimeInSeconds(0), 5);
        Assert.Equal(6.0, this.timeSeries.TimeInSeconds(6) - this.timeSeries.TimeInSeconds(0), 5);
    }

    [Fact]
    public void RepairTests()
    {
        TimeSeries ts = new TimeSeries(
            DateTime.Parse("1.1.2026"),
            TimeSpan.FromSeconds(1),
            [1.1, 1.2, 1.3, 1.01, 2.2, 2.1, 20.0]
        );
        ts.Repair(0, 15);
        Assert.Equal(1.1, ts.Value(0), 5);
        Assert.Equal(2.1, ts.Value(5), 5);
        Assert.Equal(2.1, ts.Value(6), 5);  // 20.0 durch vorherigen Wert ersetzt
    }

    [Fact]
    public void ClipTests()
    {
        TimeSeries clipped = this.timeSeries.Clip(
            DateTime.Parse("1.1.2026 0:0:2"),
            DateTime.Parse("1.1.2026 0:0:5")
        );
        Assert.Equal(3, clipped.N());
        Assert.Equal(1.3, clipped.Value(0), 5);
        Assert.Equal(1.01, clipped.Value(1), 5);
        Assert.Equal(2.2, clipped.Value(2), 5);
    }

    [Fact]
    public void FitLineTests()
    {
        double[] line = this.timeSeries.FitLine();
        Assert.Equal(2.1214, line[1], 4);
    }

    [Fact]
    public void DriftTests()
    {
        Assert.Equal(12.7286, this.timeSeries.Drift(), 4);
    }
}

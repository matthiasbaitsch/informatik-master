namespace time_series_tests;

public class Tests
{

    private TimeSeries timeSeries = new TimeSeries(
        DateTime.Parse("1.1.2026"),
        TimeSpan.FromSeconds(1),
        [1.1, 1.2, 1.3, 1.01, 2.2, 2.1, 2.0]
    );


    [Fact]
    public void DWDTests()
    {
        Assert.Equal(DateTime.Parse("1.1.1951 1:0:0"), DWD.ParseDate("1951010101"));
        Assert.Equal(DateTime.Parse("31.12.1951 23:0:0"), DWD.ParseDate("1951123123"));
    }

    [Fact]
    public void BasicTests()
    {
        Assert.Equal(7, this.timeSeries.N());
        Assert.Equal(TimeSpan.FromSeconds(6), this.timeSeries.Duration());
        Assert.Equal(DateTime.Parse("1.1.2026 0:0:6"), this.timeSeries.Time(6));
    }
}

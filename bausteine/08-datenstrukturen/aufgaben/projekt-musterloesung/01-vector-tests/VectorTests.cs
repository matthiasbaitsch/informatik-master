using Xunit;

public class VectorTests
{
    [Fact]
    public void Constructor()
    {
        double[] values = [1.0, 2.0, 3.0];
        Vector v = new Vector(values);
        Assert.Equal(values, v.Values);
    }

    [Fact]
    public void N()
    {
        Vector x = new Vector([1.0, 2.0, 3.0]);
        Assert.Equal(3, x.N());
    }

    [Fact]
    public void Dot()
    {
        Vector x = new Vector([1.0, 2.0, 3.0]);
        Vector y = new Vector([4.0, 5.0, 6.0]);
        Assert.Equal(x.Dot(y), y.Dot(x));
        Assert.Equal(32.0, x.Dot(y));
    }

    [Fact]
    public void EuclidianNorm()
    {
        Vector x = new Vector([3.0, 0.0, 4.0, 0.0]);
        Assert.Equal(5.0, x.EuclidianNorm());
    }

    [Fact]
    public void MaxNorm()
    {
        Vector x = new Vector([3.0, 4.0, 10.0]);
        Vector y = new Vector([3.0, -40.0, 10.0]);
        Assert.Equal(10, x.MaxNorm());
        Assert.Equal(40, y.MaxNorm());
    }

    [Fact]
    public void Add()
    {
        Vector x = new Vector([1.0, 2.0, 3.0]);
        Vector y = new Vector([4.0, 5.0, 6.0]);
        Vector z = x.Add(y);
        Assert.Equal([5.0, 7.0, 9.0], z.Values);
    }

    [Fact]
    public void Subtract()
    {
        Vector x = new Vector([4.0, 5.0, 6.0]);
        Vector y = new Vector([1.0, 2.0, 3.0]);
        Vector z = x.Subtract(y);
        Assert.Equal([3.0, 3.0, 3.0], z.Values);
    }

    [Fact]
    public void Multiply()
    {
        Vector x = new Vector([1.0, 2.0, 3.0]);
        Vector z = x.Multiply(3.0);
        Assert.Equal([3.0, 6.0, 9.0], z.Values);
    }

}

using Xunit;

public class VectorTests
{
    [Fact]
    public void Constructor_StoresValues()
    {
        double[] values = [1.0, 2.0, 3.0];
        Vector v = new Vector(values);
        Assert.Equal(values, v.Values);
    }

    [Fact]
    public void N_ReturnsNumberOfElements()
    {
        Vector v = new Vector([1.0, 2.0, 3.0]);
        Assert.Equal(3, v.N());
    }

    [Fact]
    public void Print_DoesNotThrow()
    {
        Vector v = new Vector([1.0, 2.0, 3.0]);
        v.Print("v");
    }

    [Fact]
    public void Dot_ReturnsCorrectDotProduct()
    {
        Vector a = new Vector([1.0, 2.0, 3.0]);
        Vector b = new Vector([4.0, 5.0, 6.0]);
        // 1*4 + 2*5 + 3*6 = 32
        Assert.Equal(32.0, a.Dot(b));
    }

    [Fact]
    public void Dot_IsCommutative()
    {
        Vector a = new Vector([1.0, 2.0, 3.0]);
        Vector b = new Vector([4.0, 5.0, 6.0]);
        Assert.Equal(a.Dot(b), b.Dot(a));
    }

    [Fact]
    public void Norm_ReturnsCorrectLength()
    {
        // 3-4-5-Dreieck: sqrt(9 + 16) = 5
        Vector v = new Vector([3.0, 4.0]);
        Assert.Equal(5.0, v.Norm());
    }

    [Fact]
    public void Norm_UnitVectorHasLengthOne()
    {
        Vector v = new Vector([1.0, 0.0, 0.0]);
        Assert.Equal(1.0, v.Norm());
    }

    [Fact]
    public void Add_ReturnsCorrectSum()
    {
        Vector a = new Vector([1.0, 2.0, 3.0]);
        Vector b = new Vector([4.0, 5.0, 6.0]);
        Vector result = a.Add(b);
        Assert.Equal(new double[] { 5.0, 7.0, 9.0 }, result.Values);
    }

    [Fact]
    public void Add_ReturnsNewVector()
    {
        Vector a = new Vector([1.0, 2.0, 3.0]);
        Vector b = new Vector([4.0, 5.0, 6.0]);
        Vector result = a.Add(b);
        Assert.NotSame(a, result);
        Assert.NotSame(b, result);
    }
}

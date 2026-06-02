public class FractionTest
{
    [Fact]
    public void TestSimplify()
    {
        Assert.Equal(new Fraction(1, 2), new Fraction(4, 8).Simplify());
        Assert.Equal(new Fraction(2, 1), new Fraction(8, 4).Simplify());
        Assert.Equal(new Fraction(0, 1), new Fraction(0, 33).Simplify());
        Assert.Equal(new Fraction(1, 3), new Fraction(-1, -3).Simplify());
        Assert.Equal(new Fraction(0, 1), new Fraction(0, 5).Simplify());
        Assert.Equal(new Fraction(0, 1), new Fraction(0, -5).Simplify());
    }
}

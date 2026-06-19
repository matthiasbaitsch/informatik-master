using Xunit;

public class TrigonometricPolynomialTests
{
    [Fact]
    public void GetCoefficient_ExistingKey()
    {
        TrigonometricPolynomial p = new TrigonometricPolynomial();
        p.AddCoefficient(1, new Complex(2.0, 3.0));
        Complex c = p.GetCoefficient(1);
        Assert.Equal(2.0, c.Re);
        Assert.Equal(3.0, c.Im);
    }

    [Fact]
    public void GetCoefficient_MissingKey()
    {
        TrigonometricPolynomial p = new TrigonometricPolynomial();
        Complex c = p.GetCoefficient(5);
        Assert.Equal(0.0, c.Re);
        Assert.Equal(0.0, c.Im);
    }

    [Fact]
    public void Degree_NegativeKeyDominates()
    {
        TrigonometricPolynomial p = new TrigonometricPolynomial();
        p.AddCoefficient(-3, new Complex(1.0, 0.0));
        p.AddCoefficient(1, new Complex(0.0, 1.0));
        Assert.Equal(3, p.Degree());
    }

    [Fact]
    public void Degree_SymmetricKeys()
    {
        TrigonometricPolynomial p = new TrigonometricPolynomial();
        p.AddCoefficient(-2, new Complex(1.0, -1.0));
        p.AddCoefficient(2, new Complex(1.0, 1.0));
        Assert.Equal(2, p.Degree());
    }

    [Fact]
    public void Evaluate_ConstantTerm()
    {
        // k=0: e^(i*0*t) = 1, daher p(t) = c_0 für alle t
        TrigonometricPolynomial p = new TrigonometricPolynomial();
        p.AddCoefficient(0, new Complex(3.0, 2.0));
        Complex v = p.Evaluate(1.5);
        Assert.Equal(3.0, v.Re);
        Assert.Equal(2.0, v.Im);
    }

    [Fact]
    public void Evaluate_AtZero()
    {
        // e^(ik*0) = 1 für alle k, daher p(0) = Summe aller Koeffizienten
        TrigonometricPolynomial p = new TrigonometricPolynomial();
        p.AddCoefficient(1, new Complex(2.0, 0.0));
        p.AddCoefficient(2, new Complex(1.0, 0.0));
        Complex v = p.Evaluate(0.0);
        Assert.Equal(3.0, v.Re);
        Assert.Equal(0.0, v.Im);
    }

    [Fact]
    public void IsReal_True()
    {
        // Reellwertiges Polynom: c_k = konjugiert(c_{-k})
        TrigonometricPolynomial p = new TrigonometricPolynomial();
        p.AddCoefficient(1, new Complex(1.0, 2.0));
        p.AddCoefficient(-1, new Complex(1.0, -2.0));
        Assert.True(p.IsReal());
    }

    [Fact]
    public void IsReal_False()
    {
        TrigonometricPolynomial p = new TrigonometricPolynomial();
        p.AddCoefficient(1, new Complex(1.0, 2.0));
        p.AddCoefficient(-1, new Complex(1.0, 2.0));
        Assert.False(p.IsReal());
    }
}
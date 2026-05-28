public class MandelbrotSet
{
    public int N = 20;
    public double EscapeRadius = 2.0;

    public int StepsInside(Complex c)
    {
        int i;
        Complex z = new Complex(0, 0);
        for (i = 0; i <= this.N && z.Abs() < 2; i++)
        {
            z = z.Multiply(z).Add(c);
        }
        return i;
    }

    public bool Contains(Complex z)
    {
        return this.StepsInside(z) > this.N;
    }
}
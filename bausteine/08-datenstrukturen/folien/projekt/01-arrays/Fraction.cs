public class Fraction
{

    public int A;
    public int B;

    public Fraction(int a, int b)
    {
        this.A = a;
        this.B = b;
    }

    public void Print(string label)
    {
        Console.WriteLine($"{label} = {this.A} / {this.B}");
    }

    public Fraction Inverse()
    {
        return new Fraction(this.B, this.A);
    }

    public double ToDouble()
    {
        return (double)this.A / this.B;
    }

    public Fraction Add(Fraction q)
    {
        int a = this.A * q.B + this.B * q.A;
        int b = this.B * q.B;

        return new Fraction(a, b);
    }

    public Fraction Subtract(Fraction q)
    {
        int a = this.A * q.B - this.B * q.A;
        int b = this.B * q.B;

        return new Fraction(a, b);
    }

    public Fraction Multiply(Fraction q)
    {
        int a = this.A * q.A;
        int b = this.B * q.B;

        return new Fraction(a, b);
    }

    public Fraction Divide(Fraction q)
    {
        return this.Multiply(q.Inverse());
    }

}

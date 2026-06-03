using static System.Math;

public class Fraction
{

    public int A;
    public int B;

    public Fraction(int a, int b)
    {
        if (a * b >= 0)
        {
            this.A = Abs(a);
            this.B = Abs(b);
        }
        else
        {
            this.A = -Abs(a);
            this.B = Abs(b);
        }
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

    public int CompareTo(Fraction q)
    {
        int z1 = this.A * q.B;
        int z2 = this.B * q.A;

        if (z1 < z2)
        {
            return -1;
        }
        else if (z1 == z2)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    public bool Equals(Fraction q)
    {
        return this.A == q.A && this.B == q.B;
    }

    public bool IsEquivalent(Fraction q)
    {
        return this.A * q.B == q.A * this.B;
    }

    public Fraction Simplify()
    {
        int a = Abs(this.A);
        int b = Abs(this.B);

        while (b != 0)
        {
            int h = a % b;
            a = b;
            b = h;
        }

        return new Fraction(this.A / a, this.B / a);
    }

}

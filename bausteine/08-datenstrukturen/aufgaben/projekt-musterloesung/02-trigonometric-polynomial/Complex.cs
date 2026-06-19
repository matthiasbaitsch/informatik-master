using static System.Math;

public class Complex
{

    public double Re;
    public double Im;

    public Complex(double re, double im)
    {
        this.Re = re;
        this.Im = im;
    }

    public void Print(string label)
    {
        Console.WriteLine($"{label} = {this.Re:0.####} {this.Im:+ 0.####;- 0.####}i");
    }

    public Complex Add(Complex w)
    {
        double re = this.Re + w.Re;
        double im = this.Im + w.Im;

        return new Complex(re, im);
    }

    public Complex Subtract(Complex w)
    {
        double re = this.Re - w.Re;
        double im = this.Im - w.Im;

        return new Complex(re, im);
    }

    public Complex Multiply(Complex w)
    {
        double re = this.Re * w.Re - this.Im * w.Im;
        double im = this.Re * w.Im + this.Im * w.Re;

        return new Complex(re, im);
    }

    public Complex Divide(Complex w)
    {
        double denom = w.Re * w.Re + w.Im * w.Im;
        double re = (this.Re * w.Re + this.Im * w.Im) / denom;
        double im = (this.Im * w.Re - this.Re * w.Im) / denom;

        return new Complex(re, im);
    }

    public Complex Conjugate()
    {
        return new Complex(this.Re, -this.Im);
    }

    public double Abs()
    {
        Complex w = this.Multiply(this.Conjugate());

        return Sqrt(w.Re);
    }

    public double Arg()
    {
        return Atan2(this.Im, this.Re);
    }

    public bool Equals(Complex w)
    {
        return this.Re == w.Re && this.Im == w.Im;
    }

    public Complex Exp()
    {
        double r = Math.Exp(this.Re);
        return new Complex(r * Cos(this.Im), r * Sin(this.Im));
    }

    public Complex Power(double n)
    {
        double rn = Pow(this.Abs(), n);
        double nphi = n * this.Arg();
        double re = rn * Cos(nphi);
        double im = rn * Sin(nphi);

        return new Complex(re, im);
    }
}
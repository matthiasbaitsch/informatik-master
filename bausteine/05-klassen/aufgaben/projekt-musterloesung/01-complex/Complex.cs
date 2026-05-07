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

    public double Abs()
    {
        return Sqrt(this.Re * this.Re + this.Im * this.Im);
    }

    public double Arg()
    {
        return Atan2(this.Im, this.Re);
    }

    public Complex Conjugate()
    {
        return new Complex(this.Re, -this.Im);
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

    public Complex Power(double n)
    {
        double r = Pow(this.Abs(), n);
        double phi = this.Arg();
        double re = r * Cos(n * phi);
        double im = r * Sin(n * phi);
        return new Complex(re, im);
    }

    public void Print(string l)
    {
        Console.WriteLine($"{l} = {this.Re:0.####} + ({this.Im:0.####})i");
    }
}
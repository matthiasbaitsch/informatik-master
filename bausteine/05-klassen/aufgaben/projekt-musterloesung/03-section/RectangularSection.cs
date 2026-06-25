using static System.Math;

public class RectangularSection
{

    public double W;
    public double H;

    public RectangularSection(double w, double h)
    {
        this.W = w;
        this.H = h;
    }

    public double A()
    {
        return this.W * this.H;
    }

    public double Iy()
    {
        return this.W * Pow(this.H, 3) / 12;
    }

    public double Iz()
    {
        return Pow(this.W, 3) * this.H / 12;
    }
}

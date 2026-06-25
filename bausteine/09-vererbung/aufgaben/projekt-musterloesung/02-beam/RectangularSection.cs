using BoDraw;
using static System.Math;

public class RectangularSection : Section
{

    public double W;
    public double H;

    public RectangularSection(double w, double h)
    {
        this.W = w;
        this.H = h;
    }

    public override double A()
    {
        return this.W * this.H;
    }

    public override double Iy()
    {
        return this.W * Pow(this.H, 3) / 12;
    }

    public override double Iz()
    {
        return Pow(this.W, 3) * this.H / 12;
    }

    public override Shape Draw()
    {
        return new Rectangle(-this.W / 2, -this.H / 2, this.W / 2, this.H / 2);
    }
}

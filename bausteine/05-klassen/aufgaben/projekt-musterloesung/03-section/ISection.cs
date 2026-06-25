using static System.Math;

public class ISection
{

    public double W;
    public double H;
    public double Tw;
    public double Tf;

    public ISection(double w, double h, double tw, double tf)
    {
        this.W = w;
        this.H = h;
        this.Tw = tw;
        this.Tf = tf;
    }

    public double A()
    {
        return this.W * this.H - (this.W - this.Tw) * (this.H - 2 * this.Tf);
    }

    public double Iy()
    {
        return (this.W * Pow(this.H, 3) - Pow(this.H - 2 * this.Tf, 3) * (this.W - this.Tw)) / 12;
    }

    public double Iz()
    {
        return (2 * Pow(this.W, 3) * this.Tf + Pow(this.Tw, 3) * (this.H - 2 * this.Tf)) / 12;
    }
}

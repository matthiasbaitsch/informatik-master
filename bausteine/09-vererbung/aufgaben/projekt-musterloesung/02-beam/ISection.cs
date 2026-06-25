using BoDraw;
using static System.Math;

public class ISection : CrossSection
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

    public override double A()
    {
        return this.W * this.H - (this.W - this.Tw) * (this.H - 2 * this.Tf);
    }

    public override double Iy()
    {
        return (this.W * Pow(this.H, 3) - Pow(this.H - 2 * this.Tf, 3) * (this.W - this.Tw)) / 12;
    }

    public override double Iz()
    {
        return (2 * Pow(this.W, 3) * this.Tf + Pow(this.Tw, 3) * (this.H - 2 * this.Tf)) / 12;
    }

    public override double Height()
    {
        return this.H;
    }

    public override Shape Draw()
    {
        double z1 = this.H / 2;
        double z2 = z1 - this.Tf;
        double y1 = this.W / 2;
        double y2 = this.Tw / 2;

        return new Polygon(
            -y1, -z1,
            y1, -z1,
            y1, -z2,
            y2, -z2,
            y2, z2,
            y1, z2,
            y1, z1,
            -y1, z1,
            -y1, z2,
            -y2, z2,
            -y2, -z2,
            -y1, -z2
        );
    }
}

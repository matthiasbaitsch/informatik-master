using static System.Math;

public class ISection
{

    public double w;
    public double h;
    public double tw;
    public double tf;

    public ISection(double w, double h, double tw, double tf)
    {
        this.w = w;
        this.h = h;
        this.tw = tw;
        this.tf = tf;
    }

    public double A()
    {
        return this.w * this.h - (this.w - this.tw) * (this.h - 2 * this.tf);
    }

    public double Iy()
    {
        return (this.w * Pow(this.h, 3) - Pow(this.h - 2 * this.tf, 3) * (this.w - this.tw)) / 12;
    }

    public double Iz()
    {
        return (2 * Pow(this.w, 3) * this.tf + Pow(this.tw, 3) * (this.h - 2 * this.tf)) / 12;
    }
}

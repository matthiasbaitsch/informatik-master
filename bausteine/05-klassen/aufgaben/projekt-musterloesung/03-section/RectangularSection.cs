using static System.Math;

public class RectangularSection
{

    private double w;
    private double h;

    public RectangularSection(double w, double h)
    {
        this.w = w;
        this.h = h;
    }

    public double A()
    {
        return this.w * this.h;
    }

    public double Iy()
    {
        return this.w * Pow(this.h, 3) / 12;
    }

    public double Iz()
    {
        return Pow(this.w, 3) * this.h / 12;
    }
}

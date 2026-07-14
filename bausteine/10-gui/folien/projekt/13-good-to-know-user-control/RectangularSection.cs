namespace good_to_know_user_control;

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
}

using BoDraw;

public class FixedSupport
{
    public double X;
    public double Y;
    public double Angle;


    public FixedSupport(double x, double y, double angle)
    {
        this.X = x;
        this.Y = y;
        this.Angle = angle;
    }

    public void MoveTo(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    public Group Draw(double a)
    {
        double d = 0.2 * a;
        return new Group(
            new Line(-0.5 * a, 0, 0.5 * a, 0).WithThickness(2),
            new Grid(new Line(-0.5 * a, - d, -0.5 * a + d, 0)).WithX(5, d)
        ).Rotate(this.Angle, 0, 0).Move(this.X, this.Y);
    }
}
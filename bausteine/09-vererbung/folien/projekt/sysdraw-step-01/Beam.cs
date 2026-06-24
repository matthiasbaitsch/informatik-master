using BoDraw;

public class Beam
{
    public double X;
    public double Y;
    public double Angle;
    public double Length;

    public Beam(double x, double y, double angle, double length)
    {
        this.X = x;
        this.Y = y;
        this.Angle = angle;
        this.Length = length;
    }

    public void MoveTo(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    public Group Draw(double a)
    {
        return new Group(
            new Line(0, 0, this.Length, 0).WithThickness(3.0),
            new Line(0.4 * this.Length, -a / 5, 0.6 * this.Length, -a / 5).WithDashStyle(20 * a, 20 * a)
        ).Rotate(this.Angle, 0, 0).Move(this.X, this.Y);
    }
}
using BoDraw;

public class Beam : StructuralElement
{
    public double Length;

    public Beam(double x, double y, double angle, double length) : base(x, y, angle)
    {
        this.Length = length;
    }

    public override Group Draw(double a)
    {
        return new Group(
            new Line(0, 0, this.Length, 0).WithThickness(3.0),
            new Line(0.4 * this.Length, -a / 5, 0.6 * this.Length, -a / 5).WithDashStyle(20 * a, 20 * a)
        ).Rotate(this.Angle, 0, 0).Move(this.X, this.Y);
    }
}
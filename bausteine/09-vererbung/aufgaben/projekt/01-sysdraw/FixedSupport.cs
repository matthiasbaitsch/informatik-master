using BoDraw;

public class FixedSupport : StructuralElement
{
    public FixedSupport(double x, double y, double angle) : base(x, y, angle) { }

    public override Shape Draw(double a)
    {
        double d = 0.2 * a;
        return new Group(
            new Line(-0.5 * a, 0, 0.5 * a, 0).WithThickness(2),
            new Grid(new Line(-0.5 * a, -d, -0.5 * a + d, 0)).WithX(5, d)
        ).Rotate(this.Angle, 0, 0).Move(this.X, this.Y);
    }
}
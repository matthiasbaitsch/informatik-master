using BoDraw;

public class PinnedSupport : StructuralElement
{
    public PinnedSupport(double x, double y, double angle) : base(x, y, angle) { }

    public Shape Draw(double a)
    {
        double d = 0.2 * a;
        return new Group(
            new Polyline(0, 0, -0.5 * a, -0.87 * a, 0.5 * a, -0.87 * a, 0, 0),
            new Grid(new Line(-0.5 * a, -0.87 * a - d, -0.5 * a + d, -0.87 * a)).WithX(5, d)
        ).Rotate(this.Angle, 0, 0).Move(this.X, this.Y);
    }
}

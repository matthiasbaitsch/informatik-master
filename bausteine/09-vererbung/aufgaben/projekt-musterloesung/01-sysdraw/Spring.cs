using BoDraw;

public class Spring : StructuralElement
{
    public Spring(double x, double y, double angle) : base(x, y, angle)
    {
    }

    public override Shape Draw(double a)
    {
        double d1 = 0.25 * a;
        double d2 = 0.15 * a;
        Group g = new Group();
        g.Add(new Polyline(
                0, 0,
                0, -2 * d2,
                -d1, -3 * d2,
                d1, -4 * d2,
                -d1, -5 * d2,
                d1, -6 * d2,
                -d1, -7 * d2,
                d1, -8 * d2,
                0, -9 * d2,
                0, -11 * d2
            )
        );
        g.Add(new Line(-a / 2, -11 * d2, a / 2, -11 * d2).WithThickness(2));
        return g.Rotate(this.Angle, 0, 0).Move(this.X, this.Y);
    }
}
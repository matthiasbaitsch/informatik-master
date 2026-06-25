using BoDraw;

public class MomentHinge : StructuralElement
{
    public MomentHinge(double x, double y) : base(x, y, 0) { }

    public override Shape Draw(double a)
    {
        return new Circle(this.X, this.Y, 0.2 * a).WithFillColor(Colors.White);
    }
}
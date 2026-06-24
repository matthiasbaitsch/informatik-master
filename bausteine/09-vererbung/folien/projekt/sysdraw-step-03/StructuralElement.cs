using BoDraw;

public abstract class StructuralElement
{
    public double X;
    public double Y;
    public double Angle;

    public StructuralElement(double x, double y, double angle)
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

    public abstract Group Draw(double a);
}
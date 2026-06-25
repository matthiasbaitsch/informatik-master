using BoDraw;

public class Load
{
    public double X;
    public double Y;
    public double Angle;
    public double Length;
    public double Q;

    public Load(double x, double y, double angle, double length, double q)
    {
        this.X = x;
        this.Y = y;
        this.Angle = angle;
        this.Length = length;
        this.Q = q;
    }

    public void MoveTo(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    public Group Draw(double a)
    {
        int n = (int)(this.Length / a);
        return new Group(
            new Line(0, 0, this.Length, 0).WithColor(Colors.Red),
            new Grid(new Arrow(0, a * this.Q, 0, 0).WithColor(Colors.Red)).WithX(n, this.Length / (n - 1)),
            new Line(0, a * this.Q, this.Length, a * this.Q).WithColor(Colors.Red)
        ).Move(0, a).Rotate(this.Angle, 0, 0).Move(this.X, this.Y);
    }
}
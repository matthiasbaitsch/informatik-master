using BoDraw;

using static System.Math;

public class Beam
{

    public double Length;
    public string SupportA;
    public string SupportB;
    public double Load;

    public Beam(double length, string supportB, string supportA, double load)
    {
        this.Length = length;
        this.SupportA = supportB;
        this.SupportB = supportA;
        this.Load = load;
    }

    public double MA()
    {
        double ql2 = this.Load * this.Length * this.Length;
        if (this.SupportA == "Fixed")
        {
            if (this.SupportB == "Free")
            {
                return -ql2 / 2;
            }
            else if (this.SupportB == "Pinned")
            {
                return -ql2 / 8;
            }
            else
            {
                return -ql2 / 12;
            }
        }
        return 0;
    }

    public double MB()
    {
        double ql2 = this.Load * this.Length * this.Length;
        if (this.SupportB == "Fixed")
        {
            if (this.SupportA == "Free")
            {
                return -ql2 / 2;
            }
            else if (this.SupportA == "Pinned")
            {
                return -ql2 / 8;
            }
            else
            {
                return -ql2 / 12;
            }
        }
        return 0;
    }

    public double M(double x)
    {
        double mA = this.MA();
        double mB = this.MB();
        return mA + (mB - mA) * x / this.Length - this.Load / 2 * x * (x - this.Length);
    }

    public double MMax()
    {
        double m1 = -this.M(0);
        double m2 = this.M(this.Length / 2);
        double m3 = -this.M(this.Length);
        return Max(m1, Max(m2, m3));
    }

    public void Draw(BoDrawApp app)
    {
        double a = this.Length / 30;
        app.Add(this.DrawSystem(a));
        app.Add(this.DrawMomentLine(a));
    }

    private Group DrawSystem(double a)
    {
        double b = a / 3;
        Group group = new Group();

        // Beam
        Line l = new Line(0, 0, this.Length, 0);
        l.Thickness = 2;
        group.Add(l);

        // Dimension line
        Dimensioning d = new Dimensioning(2 * a);
        d.Format = "0.00 m";
        d.Start(0, -3 * a);
        d.HStep(this.Length);
        group.Add(d);

        // Supports
        group.Add(this.DrawSupport(0, a, this.SupportA));
        group.Add(this.DrawSupport(this.Length, a, this.SupportB));

        // Load
        Arrow p1 = new Arrow(0, 4 * a, 0, 2 * a);
        p1.Color = Colors.Red;
        Grid load = new Grid(p1);
        load.Nx = 16;
        load.Dx = this.Length / 15;
        group.Add(load);

        // Text
        group.Add(new Text("System", this.Length + a, 0, a));
        group.Add(new Text($"{this.Load:0.00} kN/m", this.Length + a, 3 * a, 0.75 * a));

        return group;
    }

    public Group DrawSupport(double x, double a, string type)
    {
        Group group = new Group();
        if (type == "Fixed")
        {
            Line sa = new Line(0, -a, 0, a);
            sa.Thickness = 4;
            group.Add(sa);
        }
        else if (this.SupportA == "Pinned")
        {
            Polygon sa = new Polygon(-a / 2, -a, a / 2, -a, 0, 0);
            group.Add(sa);
        }
        group.Move(x, 0);
        return group;
    }

    public Group DrawMomentLine(double a)
    {
        // Helper variables
        int n = 100;
        double xMax = 0;
        double s = 5 * a / this.MMax();
        double dx = this.Length / (n - 1);

        // Group
        Group group = new Group();

        // Beam
        Line l = new Line(0, 0, this.Length, 0);
        l.Thickness = 2;
        group.Add(l);

        // Moment line
        Polyline m = new Polyline();
        for (int i = 0; i < n; i++)
        {
            double x = i * dx;
            double y = -s * this.M(x);
            if (this.M(x) > this.M(xMax))
            {
                xMax = x;
            }
            m.AddPoint(x, y);
        }
        group.Add(m);

        // Moment labels
        group.Add(this.DrawMomentText(0, s, a));
        group.Add(this.DrawMomentText(xMax, s, a));
        group.Add(this.DrawMomentText(this.Length, s, a));

        // Text
        group.Add(new Text("Momentenlinie", this.Length + a, 0, a));
        group.Add(new Text("(kNm)", this.Length + a, -a, 0.75 * a));

        // Move group after adding shapes
        group.Move(0, -12 * a);

        return group;
    }

    public Group DrawMomentText(double x, double s, double a)
    {
        double mx = this.M(x);
        Group group = new Group();

        if (mx != 0)
        {
            // Text
            Text text = new Text($"{mx:0.00}", x, -s * mx - Sign(mx) * a / 3, 0.75 * a);
            text.HJust = 0.5;
            if (mx > 0) { text.VJust = 1; }
            group.Add(text);

            // Line
            group.Add(new Line(x, 0, x, -s * mx));
        }

        return group;
    }
}
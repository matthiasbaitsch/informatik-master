using BoDraw;

using static System.Math;

public class TrigonometricPolynomial
{
    public Dictionary<int, Complex> Coefficients = [];

    public void AddCoefficient(int k, Complex ck)
    {
        this.Coefficients[k] = ck;
    }

    public int Degree()
    {
        int kmin = this.Coefficients.Keys.Min();
        int kmax = this.Coefficients.Keys.Max();
        return Max(Abs(kmin), Abs(kmax));
    }

    public Complex GetCoefficient(int k)
    {
        if (this.Coefficients.ContainsKey(k))
        {
            return this.Coefficients[k];
        }
        else
        {
            return new Complex(0, 0);
        }
    }

    public Complex EvaluatePart(int k, double t)
    {
        return this.Coefficients[k].Multiply(new Complex(Cos(k * t), Sin(k * t)));
    }

    public Complex Evaluate(double t)
    {
        Complex v = new Complex(0, 0);
        foreach (int k in this.Coefficients.Keys)
        {
            v = v.Add(this.EvaluatePart(k, t));
        }
        return v;
    }

    public bool IsReal()
    {
        foreach (int k in this.Coefficients.Keys)
        {
            if (!this.GetCoefficient(k).Equals(this.GetCoefficient(-k).Conjugate()))
            {
                return false;
            }
        }
        return true;
    }

    public void Plot(BoDrawApp app, int nsteps)
    {
        double dt = 2 * PI / (nsteps - 1);
        Polygon pl = new Polygon();

        for (int i = 0; i < nsteps; i++)
        {
            double t = i * dt;
            Complex v = this.Evaluate(t);
            pl.AddPoint(v.Re, v.Im);
        }
        pl.FillColor = Colors.Orange;
        pl.FillOpacity = 0.3;
        pl.LineColor = Colors.HotPink;
        pl.LineThickness = 2;

        app.Add(pl);
    }

    public void PlotArrows(BoDrawApp app, double t)
    {
        Complex p1 = new Complex(0, 0);

        foreach (var k in this.Coefficients.Keys)
        {
            Complex p2 = p1.Add(this.EvaluatePart(k, t));
            app.Add(new Arrow(p1.Re, p1.Im, p2.Re, p2.Im).WithColor(Colors.DarkSlateBlue));
            p1 = p2;
        }
    }

    public void PlotComponents(BoDrawApp app, int nsteps)
    {
        double dt = 2 * PI / (nsteps - 1);
        Polyline pRe = new Polyline();
        Polyline pIm = new Polyline();

        for (int i = 0; i < nsteps; i++)
        {
            double t = i * dt;
            Complex v = this.Evaluate(t);
            pRe.AddPoint(t, v.Re);
            pIm.AddPoint(t, v.Im);
        }
        pRe.Color = Colors.HotPink;
        pRe.Thickness = 2;

        app.Add(pRe, pIm, new Arrow(0, 0, 2 * PI, 0));
    }

}
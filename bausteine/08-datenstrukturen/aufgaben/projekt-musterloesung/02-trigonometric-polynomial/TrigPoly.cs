using BoDraw;

using static System.Math;

public class TrigPoly
{
    public Dictionary<int, Complex> Coefficients = [];

    public void AddCoefficient(int k, Complex ck)
    {
        this.Coefficients[k] = ck;
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

    public Complex Evaluate(double t)
    {
        Complex v = new Complex(0, 0);
        foreach (int k in this.Coefficients.Keys)
        {
            v = v.Add(this.Coefficients[k].Multiply(new Complex(0, k * t).Exp()));
        }
        return v;
    }

    public void Plot(BoDrawApp app, int nsteps)
    {
        double dt = 2 * PI / (nsteps - 1);
        Polyline pl = new Polyline();

        for (int i = 0; i < nsteps; i++)
        {
            double t = i * dt;
            Complex v = this.Evaluate(t);
            pl.AddPoint(v.Re, v.Im);
        }
        pl.Color = Colors.HotPink;
        pl.Thickness = 2;

        app.Add(pl);
    }

}
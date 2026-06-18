using BoDraw;

public class TimeSeries
{
    public double DeltaT;
    public double[] Values;

    public TimeSeries(double deltaT, double[] values)
    {
        this.DeltaT = deltaT;
        this.Values = values;
    }

    public int Count()
    {
        return this.Values.Length;
    }

    public double Time(int i) { return i * this.DeltaT; }

    public double Value(int i) { return this.Values[i]; }

    public double Duration()
    {
        return (this.Count() - 1) * this.DeltaT;
    }


    public double Min()
    {
        return this.Values.Min();
    }

    public double Max()
    {
        return this.Values.Max();
    }

    public void Plot(BoDrawApp app)
    {
        Rectangle r1 = new Rectangle(0, this.Min(), this.Duration(), this.Max());
        Rectangle r2 = new Rectangle(0, 0, 16, 9);

        double sx = r2.Bounds.Width / r1.Bounds.Width;
        double sy = r2.Bounds.Height / r1.Bounds.Height;
        double ox = 0;
        double oy = -sy * this.Min();

        Polyline pl = new Polyline();
        for (int i = 0; i < this.Count(); i++)
        {
            pl.AddPoint(ox + sx * this.Time(i), oy + sy * this.Value(i));
        }
        // pl.Thickness = 3;
        pl.Color = Colors.Red;


        app.Add(r2, pl);
    }

    public void Repair(int v1, int v2)
    {
        for (int i = 1; i < this.Count(); i++)
        {
            if (this.Values[i] < v1 || this.Values[i] > v2)
            {
                this.Values[i] = this.Values[i - 1];
            }
        }
    }
}
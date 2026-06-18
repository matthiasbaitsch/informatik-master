using BoDraw;

public class TimeSeries
{
    public DateTime StartTime;
    public TimeSpan DeltaT;
    public double[] Values;

    public TimeSeries(DateTime startTime, TimeSpan deltaT, double[] values)
    {
        this.StartTime = startTime;
        this.DeltaT = deltaT;
        this.Values = values;
    }

    public int N()
    {
        return this.Values.Length;
    }

    public TimeSpan Duration()
    {
        return (this.N() - 1) * this.DeltaT;
    }

    public DateTime Timestamp(int i)
    {
        return this.StartTime + i * this.DeltaT;
    }

    public double TimeInSeconds(int i)
    {
        return (this.Timestamp(i) - DateTime.MinValue).TotalSeconds;
    }

    public double Value(int i)
    {
        return this.Values[i];
    }

    public void PrintSummary()
    {
        Console.WriteLine($"N:        {this.N()}");
        Console.WriteLine($"Start:    {this.StartTime}");
        Console.WriteLine($"End:      {this.StartTime + this.Duration()}");
        Console.WriteLine($"Duration: {this.Duration()}");
        Console.WriteLine($"Min:      {this.Values.Min()}");
        Console.WriteLine($"Max:      {this.Values.Max()}");
        Console.WriteLine($"Drift:    {this.Drift()}");
    }

    public void Repair(int v1, int v2)
    {
        for (int i = 1; i < this.N(); i++)
        {
            if (this.Values[i] < v1 || this.Values[i] > v2)
            {
                this.Values[i] = this.Values[i - 1];
            }
        }
    }

    // Rückgabe: [0] = alpha (Achsabschnitt), [1] = beta (Steigung)
    public double[] FitLine()
    {
        int n = this.N();
        double tSum = 0;
        double vSum = 0;
        double t2Sum = 0;
        double tvSum = 0;
        double t0 = this.TimeInSeconds(0);

        for (int i = 0; i < n; i++)
        {
            double t = this.TimeInSeconds(i) - t0;
            double v = this.Values[i];
            tSum += t;
            vSum += v;
            t2Sum += t * t;
            tvSum += t * v;
        }

        double beta = (n * tvSum - tSum * vSum) / (n * t2Sum - tSum * tSum);
        double alpha = (vSum - beta * tSum) / n - beta * t0;

        return [alpha, beta];
    }

    public double Drift()
    {
        TimeSpan d = this.Duration();
        double[] line = this.FitLine();
        return line[1] * d.TotalSeconds;
    }

    public TimeSeries Clip(DateTime start, DateTime end)
    {
        List<double> values = new List<double>();
        for (int i = 0; i < this.N(); i++)
        {
            if (start <= this.Timestamp(i) && this.Timestamp(i) < end)
            {
                values.Add(this.Value(i));
            }
        }
        return new TimeSeries(start, this.DeltaT, values.ToArray());
    }

    public void Plot(BoDrawApp app)
    {
        Group g = new Group();
        Rectangle r = new Rectangle(0, 0, 16, 9);

        Polyline p = new Polyline();
        for (int i = 0; i < this.N(); i++)
        {
            p.AddPoint(this.TimeInSeconds(i), this.Value(i));
        }
        p.Color = Colors.Red;
        g.Add(p);

        double t1 = this.TimeInSeconds(0);
        double t2 = this.TimeInSeconds(this.N() - 1);
        double[] fit = this.FitLine();
        double alpha = fit[0];
        double beta = fit[1];
        double v1 = alpha + beta * t1;
        double v2 = alpha + beta * t2;
        Line line = new Line(t1, v1, t2, v2);
        line.Color = Colors.Blue;
        g.Add(line);

        g.FitInto(r);
        app.Add(r, g);
    }

}
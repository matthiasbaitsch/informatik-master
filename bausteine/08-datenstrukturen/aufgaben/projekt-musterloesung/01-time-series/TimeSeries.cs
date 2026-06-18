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

    public TimeSeries(string file)
    {
        string[] lines = File.ReadAllLines(file);
        List<double> values = new List<double>();
        DateTime d1 = DWD.ParseDate(lines[1].Split(";")[1].Trim());
        DateTime d2 = DWD.ParseDate(lines[2].Split(";")[1].Trim());

        foreach (string line in lines.Skip(1))
        {
            string[] entries = line.Split(";");
            double value = Double.Parse(entries[3]);
            values.Add(value);
        }

        this.StartTime = d1;
        this.DeltaT = d2 - d1;
        this.Values = values.ToArray();
    }

    public int N()
    {
        return this.Values.Length;
    }

    public DateTime Time(int i)
    {
        return this.StartTime + i * this.DeltaT;
    }

    public double Value(int i)
    {
        return this.Values[i];
    }

    public TimeSpan Duration()
    {
        return (this.N() - 1) * this.DeltaT;
    }

    public void PrintSummary()
    {
        Console.WriteLine($"{this.N()} values");
        Console.WriteLine($"Start: {this.StartTime}");
        Console.WriteLine($"Duration: {this.Duration()}");
        Console.WriteLine($"Min: {this.Values.Min()}");
        Console.WriteLine($"Max: {this.Values.Max()}");
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

    public TimeSeries Clip(string start, string end)
    {
        DateTime s = new DateTime();
        DateTime d1 = DateTime.Parse(start);
        DateTime d2 = DateTime.Parse(end);
        List<double> values = new List<double>();

        for (int i = 0; i < this.N(); i++)
        {
            DateTime t = this.Time(i);
            if (d1 <= t && t < d2)
            {
                values.Add(this.Value(i));
            }
            if (t == d1)
            {
                s = t;
            }
        }
        return new TimeSeries(s, this.DeltaT, values.ToArray());
    }

    public Polyline AsPolyline()
    {
        Polyline pl = new Polyline();
        for (int i = 0; i < this.N(); i++)
        {
            pl.AddPoint(i * this.DeltaT.TotalSeconds, this.Value(i));
        }
        return pl;
    }

    public void Plot(BoDrawApp app)
    {
        Polyline p = this.AsPolyline();
        Rectangle r = new Rectangle(0, 0, 16, 9);
        p.Color = Colors.Red;
        p.FitInto(r);
        app.Add(r, p);
    }

}
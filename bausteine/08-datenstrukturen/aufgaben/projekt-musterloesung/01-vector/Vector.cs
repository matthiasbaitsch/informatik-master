using static System.Math;

public class Vector
{
    public double[] Values;

    public Vector(double[] values)
    {
        this.Values = values;
    }

    public void Print(string label)
    {
        Console.WriteLine($"{label} = [{string.Join(", ", this.Values)}]");
    }

    public int N()
    {
        return this.Values.Length;
    }

    public double Dot(Vector x)
    {
        double s = 0;
        for (int i = 0; i < this.N(); i++)
        {
            s += this.Values[i] * x.Values[i];
        }
        return s;
    }

    public double Norm()
    {
        return Sqrt(this.Dot(this));
    }

    public Vector Add(Vector x)
    {
        double[] values = new double[this.N()];
        for (int i = 0; i < this.N(); i++)
        {
            values[i] = this.Values[i] + x.Values[i];
        }
        return new Vector(values);
    }
}
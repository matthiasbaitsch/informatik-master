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
        return 0;
    }

    public double MB()
    {
        return 0;
    }

    public double M(double x)
    {
        return 0;
    }

    public double MMax()
    {
        return 0;
    }
}
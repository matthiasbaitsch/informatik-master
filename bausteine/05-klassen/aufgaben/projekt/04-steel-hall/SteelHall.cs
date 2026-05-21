using BoDraw;
using ISections;

using static System.Math;

public class SteelHall
{

    public string Project;
    // TODO
    public double RoofPitch = 5.0;
    public ISection ProfileColumns = ISection.Get("HE-A", 200);
    // TODO

    public SteelHall(string project)
    {
        this.Project = project;
    }

    public double RoofPitchRad()
    {
        return this.RoofPitch * PI / 180;
    }

    // TODO
}
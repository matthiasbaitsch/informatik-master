using BoDraw;
using ISections;

using static System.Math;

public class SteelHall
{

    public string Project;
    public int NumberOfFrames = 11;
    public double Span = 15.0;
    public double Height = 4.0;
    public double FrameSpacing = 6.0;
    public double RoofPitch = 5.0;
    public ISection ProfileColumns = ISection.Get("HE-A", 200);
    public ISection ProfileBeams = ISection.Get("IPE", 500);

    public SteelHall(string project)
    {
        this.Project = project;
    }

    public double RoofPitchRad()
    {
        return this.RoofPitch * PI / 180;
    }

    public double Length()
    {
        return (this.NumberOfFrames - 1) * this.FrameSpacing;
    }

    public double GroundArea()
    {
        return this.Length() * this.Span;
    }

    public double LengthColumns()
    {
        return this.NumberOfFrames * 2 * this.Height;
    }

    public double LengthBeams()
    {
        return this.NumberOfFrames * this.Span / Cos(this.RoofPitchRad());
    }

    public double SteelWeight()
    {
        return this.LengthColumns() * this.ProfileColumns.G + this.LengthBeams() * this.ProfileBeams.G;
    }

    public void Draw(BoDrawApp app)
    {
        double colW = this.ProfileColumns.w / 1000;
        double colH = this.ProfileColumns.h / 1000;
        double beamW = this.ProfileBeams.w / 1000;
        double beamH = this.ProfileBeams.h / 1000;

        // ------------------------------------------------------------------------------------------------
        // Section of Warehouse
        // ------------------------------------------------------------------------------------------------
        Group sectionPlan = new Group();
        double hr = this.Span / 2 * Tan(this.RoofPitchRad());
        double hb = beamH / Cos(this.RoofPitchRad());
        double x1 = -colW / 2;
        double x2 = colW / 2;
        double x3 = this.Span / 2;
        double x4 = this.Span - colW / 2;
        double x5 = this.Span + colW / 2;
        double y1 = this.Height - hb / 2;
        double y2 = this.Height;
        double y3 = this.Height + hb / 2;
        double y4 = this.Height + hr - hb / 2;
        double y5 = this.Height + hr + hb / 2;

        // Floor slab
        Rectangle slab1 = new Rectangle(-1, -0.3, this.Span + 1, 0);
        sectionPlan.Add(slab1);

        // Columns
        Rectangle col1 = new Rectangle(x1, 0, x2, y2);
        col1.FillColor = Colors.SteelBlue;
        Rectangle col2 = col1.Copy(this.Span, 0);
        sectionPlan.Add(col1, col2);

        // Beam
        Polygon beam1 = new Polygon();
        beam1.AddPoint(x1, y1);
        beam1.AddPoint(x3, y4);
        beam1.AddPoint(x3, y5);
        beam1.AddPoint(x1, y3);
        beam1.FillColor = Colors.SteelBlue;
        Polygon beam2 = new Polygon();
        beam2.AddPoint(x3, y4);
        beam2.AddPoint(x5, y1);
        beam2.AddPoint(x5, y3);
        beam2.AddPoint(x3, y5);
        beam2.FillColor = Colors.SteelBlue;
        sectionPlan.Add(beam1, beam2);

        // Dimensioning
        Dimensioning dim1 = new Dimensioning(1);
        dim1.ScalingFactor = 1000;
        dim1.Format = "0";
        dim1.Start(0, -3);
        dim1.HStep(this.Span);
        dim1.StartNext();
        dim1.HStep(this.Span / 2);
        dim1.HStep(this.Span);
        dim1.Start(-2, 0);
        dim1.VStep(this.Height);
        dim1.StartNext();
        dim1.VStep(y5);
        sectionPlan.Add(dim1);

        sectionPlan.Move(5, -12);
        app.Add(sectionPlan);

        // ------------------------------------------------------------------------------------------------
        // Floor plan of Warehouse
        // ------------------------------------------------------------------------------------------------
        Group floorPlan = new Group();

        // Floor slab
        Rectangle slab2 = new Rectangle(-1, -1, this.Length() + 1, this.Span + 1);
        floorPlan.Add(slab2);

        // Wind bracing
        Line wb1 = new Line(0, 0, this.Length(), 0);
        Grid wb1s = new Grid(wb1);
        wb1s.Ny = 4;
        wb1s.Dy = this.Span / 3;
        floorPlan.Add(wb1s);
        Line wb2 = new Line(0, 0, this.FrameSpacing, this.Span / 3);
        Line wb3 = new Line(0, this.Span / 3, this.FrameSpacing, 0);
        Group wb4 = new Group(wb2, wb3);
        Grid wb4s = new Grid(wb4);
        wb4s.Nx = 2;
        wb4s.Dx = (this.NumberOfFrames - 2) * this.FrameSpacing;
        wb4s.Ny = 3;
        wb4s.Dy = this.Span / 3;
        floorPlan.Add(wb4s);

        // Frames
        Rectangle frame = new Rectangle(-beamW / 2, -colH / 2, beamW / 2, this.Span + colH / 2);
        frame.FillColor = Colors.SteelBlue;
        Grid frames = new Grid(frame);
        frames.Nx = this.NumberOfFrames;
        frames.Dx = this.FrameSpacing;
        floorPlan.Add(frames);

        // Dimension lines
        Dimensioning dim2 = new Dimensioning(1);
        dim2.ScalingFactor = 1000;
        dim2.Format = "0";
        dim2.Start(0, -3);
        dim2.HStep(this.Length());
        dim2.StartNext();
        dim2.HStep(this.FrameSpacing);
        floorPlan.Add(dim2);
        dim2.Start(-3, 0);
        dim2.VStep(this.Span);

        app.Add(floorPlan);

        // ------------------------------------------------------------------------------------------------
        // Output
        // ------------------------------------------------------------------------------------------------
        Text text = new Text(this.Length(), -5, 0.5);
        text.HJust = 1;
        text.VJust = 1;
        text.FontFamilyName = "Courier New";
        text.AppendLine("───────────────────────────────────────");
        text.AppendLine($"  Hallenrechner – {this.Project}");
        text.AppendLine("───────────────────────────────────────");
        text.AppendLine("  Eingabewerte");
        text.AppendLine($"    Anzahl Rahmen      {this.NumberOfFrames,9:D}");
        text.AppendLine($"    Stützenhöhe        {this.Height,9:F2} m");
        text.AppendLine($"    Stützweite         {this.Span,9:F2} m");
        text.AppendLine($"    Achsabstand        {this.FrameSpacing,9:F2} m");
        text.AppendLine($"    Dachneigung        {this.RoofPitch,9:F2} °");
        text.AppendLine($"    Profil Stützen     {this.ProfileColumns.Name,9}");
        text.AppendLine($"    Profil Riegel      {this.ProfileBeams.Name,9}");
        text.AppendLine("───────────────────────────────────────");
        text.AppendLine("  Ergebnisse");
        text.AppendLine($"    Länge der Halle    {this.Length(),9:F2} m");
        text.AppendLine($"    Grundfläche        {this.GroundArea(),9:F2} m²");
        text.AppendLine($"    Länge Stützen      {this.LengthColumns(),9:F2} m");
        text.AppendLine($"    Länge Riegel       {this.LengthBeams(),9:F2} m");
        text.AppendLine($"    Gesamtgewicht      {this.SteelWeight() / 1000,9:F2} to");
        text.AppendLine("───────────────────────────────────────");
        app.Add(text);
    }

}

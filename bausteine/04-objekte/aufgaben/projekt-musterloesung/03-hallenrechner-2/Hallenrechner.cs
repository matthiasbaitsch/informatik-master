using BoDraw;
using ISections;

using static System.Math;

// Basic values
string project = "Halle S2-12-075";
int numberOfFrames = 11;
double span = 15.0;
double height = 5.0;
double frameSpacing = 6.0;
double roofPitch = 5.0;
ISection profileColumns = ISection.Get("HE-A", 200);
ISection profileBeams = ISection.Get("IPE", 550);

// Derived values
double length = (numberOfFrames - 1) * frameSpacing;
double groundArea = length * span;
double roofPitchRad = roofPitch * PI / 180;
double lengthColumns = numberOfFrames * 2 * height;
double lengthBeams = numberOfFrames * span / Cos(roofPitch * PI / 180);
double steelWeight = lengthColumns * profileColumns.G + lengthBeams * profileBeams.G;

// Useful variables
double colW = profileColumns.w / 1000;
double colH = profileColumns.h / 1000;
double beamW = profileBeams.w / 1000;
double beamH = profileBeams.h / 1000;

// App
BoDrawApp app = new BoDrawApp();

// ------------------------------------------------------------------------------------------------
// Warehouse section
// ------------------------------------------------------------------------------------------------
{
    Group sectionPlan = new Group();

    // Helper variables
    double hd = 0.5 * span * Tan(roofPitchRad);
    double beamH2 = beamH / Cos(roofPitchRad);
    double x1 = -colH / 2;
    double x2 = colH / 2;
    double x3 = span / 2;
    double x4 = span - colH / 2;
    double x5 = span + colH / 2;
    double y1 = height - beamH2 / 2;
    double y2 = height + beamH2 / 2;
    double y3 = height + hd - beamH2 / 2;
    double y4 = height + hd + beamH2 / 2;

    // Floor slab
    Rectangle slab = new Rectangle(-1, -0.3, span + 1, 0);
    sectionPlan.Add(slab);

    // Beam
    Polygon beam1 = new Polygon(x1, y1, x3, y3, x3, y4, x1, y2);
    beam1.FillColor = Colors.SteelBlue;
    Polygon beam2 = new Polygon(x3, y3, x5, y1, x5, y2, x3, y4);
    beam2.FillColor = Colors.SteelBlue;
    sectionPlan.Add(beam1, beam2);

    // Columns
    Rectangle col1 = new Rectangle(x1, 0, x2, y2);
    col1.FillColor = Colors.SteelBlue;
    Rectangle col2 = col1.Copy(span, 0);
    sectionPlan.Add(col1, col2);

    // Dimension lines
    Dimensioning dim1 = new Dimensioning(1.3);
    dim1.Format = "0";
    dim1.ScalingFactor = 1000;
    dim1.Start(0, -3);
    dim1.HStep(span);
    dim1.StartNext();
    dim1.HStep(span / 2, span);
    dim1.Start(-2, 0);
    dim1.VStep(height);
    dim1.StartNext();
    dim1.VStep(y4);
    sectionPlan.Add(dim1);

    // Move and add
    sectionPlan.Move(10, -13);
    app.Add(sectionPlan);
}

// ------------------------------------------------------------------------------------------------
// Warehouse floor plan
// ------------------------------------------------------------------------------------------------
{
    Group floorPlan = new Group();

    // Floor slab
    Rectangle slab = new Rectangle(-1, -1, length + 1, span + 1);
    floorPlan.Add(slab);

    // Frames
    Rectangle oneFrame = new Rectangle(-beamW / 2, -colH / 2, beamW / 2, span + colH / 2);
    oneFrame.FillColor = Colors.SteelBlue;
    Grid frames = new Grid(oneFrame);
    frames.Nx = numberOfFrames;
    frames.Dx = frameSpacing;
    floorPlan.Add(frames);

    // Wind bracings 1
    Line wb1 = new Line(0, 0, length, 0);
    Grid wb1Grid = new Grid(wb1);
    wb1Grid.Ny = 4;
    wb1Grid.Dy = span / 3;
    floorPlan.Add(wb1Grid);

    // Wind bracings 2
    Line wb21 = new Line(0, 0, frameSpacing, span / 3);
    Line wb22 = new Line(0, span / 3, frameSpacing, 0);
    Group wb2 = new Group(wb21, wb22);
    Grid wb2Grid = new Grid(wb2);
    wb2Grid.Nx = 2;
    wb2Grid.Dx = (numberOfFrames - 2) * frameSpacing;
    wb2Grid.Ny = 3;
    wb2Grid.Dy = span / 3;
    floorPlan.Add(wb2Grid);

    // Dimension lines
    Dimensioning dim = new Dimensioning(1.3);
    dim.ScalingFactor = 1000;
    dim.Start(0, -3.5);
    dim.HStep(length);
    dim.StartNext();
    dim.HStep(frameSpacing);
    dim.Start(-2, 0);
    dim.VStep(span);
    floorPlan.Add(dim);

    // Add
    app.Add(floorPlan);
}

// Output
{
    Text text = new Text(length + 1, -5);
    text.VJust = 1;
    text.HJust = 1;
    text.FontSize = 0.6;
    text.FontFamilyName = "Courier New";
    text.AppendLine("───────────────────────────────────────");
    text.AppendLine($"  Hallenrechner – {project}");
    text.AppendLine("───────────────────────────────────────");
    text.AppendLine("  Eingabewerte");
    text.AppendLine($"    Anzahl Rahmen      {numberOfFrames,9:D}");
    text.AppendLine($"    Stützenhöhe        {height,9:F2} m");
    text.AppendLine($"    Stützweite         {span,9:F2} m");
    text.AppendLine($"    Achsabstand        {frameSpacing,9:F2} m");
    text.AppendLine($"    Dachneigung        {roofPitch,9:F2}°");
    text.AppendLine($"    Profil Stützen     {profileColumns.Name,9}");
    text.AppendLine($"    Profil Riegel      {profileBeams.Name,9}");
    text.AppendLine("───────────────────────────────────────");
    text.AppendLine("  Ergebnisse");
    text.AppendLine($"    Länge der Halle    {length,9:F2} m");
    text.AppendLine($"    Grundfläche        {groundArea,9:F2} m²");
    text.AppendLine($"    Länge Stützen      {lengthColumns,9:F2} m");
    text.AppendLine($"    Länge Riegel       {lengthBeams,9:F2} m");
    text.AppendLine($"    Gesamtgewicht      {steelWeight / 1000,9:F2} to");
    text.AppendLine("───────────────────────────────────────");

    // Add
    app.Add(text);
}

app.Show();
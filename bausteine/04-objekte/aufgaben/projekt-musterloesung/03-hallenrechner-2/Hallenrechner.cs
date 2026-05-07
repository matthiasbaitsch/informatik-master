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
double lengthColumns = numberOfFrames * 2 * height;
double lengthBeams = numberOfFrames * span / Cos(roofPitch * PI / 180);
double steelWeight = lengthColumns * profileColumns.G + lengthBeams * profileBeams.G;

// Useful variables
double pcw = profileColumns.w / 1000;
double pch = profileColumns.h / 1000;
double pctf = profileColumns.tf / 1000;
double pctw = profileColumns.tw / 1000;
double pbw = profileBeams.w / 1000;
double pbh = profileBeams.h / 1000;
double pbtf = profileBeams.tf / 1000;
double pbtw = profileBeams.tw / 1000;

// App
BoDrawApp app = new BoDrawApp();

// Section
{
    Rectangle groundPlate = new Rectangle(-1, -0.3, span + 1, 0);
    Rectangle c1 = new Rectangle(-pcw / 2, 0, pcw / 2, height + pbh / 2);
    c1.FillColor = Colors.SteelBlue;
    Rectangle c2 = c1.Copy(span, 0);

    Polygon beam = new Polygon();
    double dd = 0.5 * span * Sin(roofPitch * PI / 180);
    beam.FillColor = Colors.SteelBlue;
    beam.AddPoint(-pch / 2, height - pbh / 2);
    beam.AddPoint(span / 2, height - pbh / 2 + dd);
    beam.AddPoint(span + pch / 2, height - pbh / 2);
    beam.AddPoint(span + pch / 2, height + pbh / 2);
    beam.AddPoint(span / 2, height + pbh / 2 + dd);
    beam.AddPoint(-pch / 2, height + pbh / 2);
    Line l = new Line(span / 2, height + pbh / 2 + dd, span / 2, height - pbh / 2 + dd);

    // Dimension lines
    Dimensioning dim = new Dimensioning(1.3);
    dim.ScalingFactor = 1000;
    dim.Start(0, -3);
    dim.HStep(span);
    dim.StartNext();
    dim.HStep(span / 2, span);
    dim.Start(-2, 0);
    dim.VStep(height);
    dim.StartNext();
    dim.VStep(height + dd);

    // All together
    Group sectionPlan = new Group(groundPlate, beam, l, c1, c2, dim);
    sectionPlan.Move(10, -13);

    // Add
    app.Add(sectionPlan);
}

// Floor plan
{
    Rectangle groundPlate = new Rectangle(-1, -1, length + 1, span + 1);

    // One Frame
    Rectangle b1 = new Rectangle(-pbw / 2, -pch / 2, pbw / 2, span + pch / 2);
    b1.FillColor = Colors.SteelBlue;
    Polygon c1 = new Polygon();
    c1.AddPoint(-pcw / 2, -pch / 2);  // 1
    c1.AddPoint(pcw / 2, -pch / 2);
    c1.AddPoint(pcw / 2, -pch / 2 + pctf);
    c1.AddPoint(pctw / 2, -pch / 2 + pctf);
    c1.AddPoint(pctw / 2, pch / 2 - pctf); // 5
    c1.AddPoint(pcw / 2, pch / 2 - pctf);
    c1.AddPoint(pcw / 2, pch / 2);
    c1.AddPoint(-pcw / 2, pch / 2);
    c1.AddPoint(-pcw / 2, pch / 2 - pctf);
    c1.AddPoint(-pctw / 2, pch / 2 - pctf); // 10
    c1.AddPoint(-pctw / 2, -pch / 2 + pctf);
    c1.AddPoint(-pcw / 2, -pch / 2 + pctf);
    Polygon c2 = c1.Copy(0, span);
    Group oneFrame = new Group(b1, c1, c2);

    // All frames
    Grid allFrames = new Grid(oneFrame);
    allFrames.Nx = numberOfFrames;
    allFrames.Dx = frameSpacing;

    // Axial stiffeners
    Line oneAxialStiff = new Line(0, 0, length, 0);
    Grid allAxialStiff = new Grid(oneAxialStiff);
    allAxialStiff.Ny = 4;
    allAxialStiff.Dy = span / 3;

    // Cross stiffeners
    Line crossStiff1 = new Line(0, 0, frameSpacing, span / 3);
    Line crossStiff2 = new Line(0, span / 3, frameSpacing, 0);
    Group crossStiff = new Group(crossStiff1, crossStiff2);
    Grid allCrossStiffeners = new Grid(crossStiff);
    allCrossStiffeners.Nx = 2;
    allCrossStiffeners.Dx = (numberOfFrames - 2) * frameSpacing;
    allCrossStiffeners.Ny = 3;
    allCrossStiffeners.Dy = span / 3;

    // Dimension lines
    Dimensioning dim = new Dimensioning(1.3);
    dim.ScalingFactor = 1000;
    dim.Start(0, -3.5);
    dim.HStep(length);
    dim.StartNext();
    dim.HStep(frameSpacing);
    dim.Start(-2, 0);
    dim.VStep(span);

    // All together
    Group floorPlan = new Group(groundPlate, allAxialStiff, allCrossStiffeners, allFrames, dim);

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
    text.AppendLine( $"  Hallenrechner – {project}");
    text.AppendLine( "───────────────────────────────────────");
    text.AppendLine( "  Eingabewerte");
    text.AppendLine( $"    Anzahl Rahmen      {numberOfFrames,9:D}");
    text.AppendLine( $"    Stützenhöhe        {height,9:F2} m");
    text.AppendLine( $"    Stützweite         {span,9:F2} m");
    text.AppendLine( $"    Achsabstand        {frameSpacing,9:F2} m");
    text.AppendLine( $"    Dachneigung        {roofPitch,9:F2} °");
    text.AppendLine( $"    Profil Stützen     {profileColumns.Name,9}");
    text.AppendLine( $"    Profil Riegel      {profileBeams.Name,9}");
    text.AppendLine( "───────────────────────────────────────");
    text.AppendLine( "  Ergebnisse");
    text.AppendLine( $"    Länge der Halle    {length,9:F2} m");
    text.AppendLine( $"    Grundfläche        {groundArea,9:F2} m²");
    text.AppendLine( $"    Länge Stützen      {lengthColumns,9:F2} m");
    text.AppendLine( $"    Länge Riegel       {lengthBeams,9:F2} m");
    text.AppendLine( $"    Gesamtgewicht      {steelWeight / 1000,9:F2} to");
    text.AppendLine( "───────────────────────────────────────");

    // Add
    app.Add(text);
}

app.SaveImage("test.png", 2400);
app.Show();
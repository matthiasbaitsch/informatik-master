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
ISection profileBeams = ISection.Get("IPE", 500);

// Derived values
double length = (numberOfFrames - 1) * frameSpacing;
double groundArea = length * span;
double lengthColumns = numberOfFrames * 2 * height;
double lengthBeams = numberOfFrames * span / Cos(roofPitch * PI / 180);
double steelWeight = lengthColumns * profileColumns.G + lengthBeams * profileBeams.G;

// Profiles
double colW = profileColumns.w / 1000;
double colH = profileColumns.h / 1000;
double beamW = profileBeams.w / 1000;
double beamH = profileBeams.h / 1000;
double roofPitchRad = roofPitch * PI / 180;

// BoDraw App
BoDrawApp app = new BoDrawApp();

// ------------------------------------------------------------------------------------------------
// Section of Warehouse
// ------------------------------------------------------------------------------------------------
Group sectionPlan = new Group();
double hr = span / 2 * Tan(roofPitchRad);
double hb = beamH / Cos(roofPitchRad);

double x1 = -colW / 2;
double x2 = colW / 2;
double x3 = span / 2;
double x4 = span - colW / 2;
double x5 = span + colW / 2;
double y1 = height - hb / 2;
double y2 = height;
double y3 = height + hb / 2;
double y4 = height + hr - hb / 2;
double y5 = height + hr + hb / 2;

// Floor slab
Rectangle slab1 = new Rectangle(-1, -0.3, span + 1, 0);
sectionPlan.Add(slab1);

// Columns
Rectangle col1 = new Rectangle(x1, 0, x2, y2);
col1.FillColor = Colors.SteelBlue;
Rectangle col2 = col1.Copy(span, 0);
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
dim1.HStep(span);
dim1.StartNext();
dim1.HStep(span / 2);
dim1.HStep(span);
dim1.Start(-2, 0);
dim1.VStep(height);
dim1.StartNext();
dim1.VStep(y5);
sectionPlan.Add(dim1);

// Add section plan
sectionPlan.Move(5, -12);
app.Add(sectionPlan);

// ------------------------------------------------------------------------------------------------
// Floor plan of Warehouse
// ------------------------------------------------------------------------------------------------
Group floorPlan = new Group();

// Floor slab
Rectangle slab2 = new Rectangle(-1, -1, length + 1, span + 1);
floorPlan.Add(slab2);

// Wind bracing
Line wb1 = new Line(0, 0, length, 0);
Grid wb1s = new Grid(wb1);
wb1s.Ny = 4;
wb1s.Dy = span / 3;
floorPlan.Add(wb1s);
Line wb2 = new Line(0, 0, frameSpacing, span / 3);
Line wb3 = new Line(0, span / 3, frameSpacing, 0);
Group wb4 = new Group(wb2, wb3);
Grid wb4s = new Grid(wb4);
wb4s.Nx = 2;
wb4s.Dx = (numberOfFrames - 2) * frameSpacing;
wb4s.Ny = 3;
wb4s.Dy = span / 3;
floorPlan.Add(wb4s);

// Frames
Rectangle frame = new Rectangle(-beamW / 2, -colH / 2, beamW / 2, span + colH / 2);
frame.FillColor = Colors.SteelBlue;
Grid frames = new Grid(frame);
frames.Nx = numberOfFrames;
frames.Dx = frameSpacing;
floorPlan.Add(frames);

// Dimension lines
Dimensioning dim2 = new Dimensioning(1);
dim2.ScalingFactor = 1000;
dim2.Format = "0";
dim2.Start(0, -3);
dim2.HStep(length);
dim2.StartNext();
dim2.HStep(frameSpacing);
floorPlan.Add(dim2);
dim2.Start(-3, 0);
dim2.VStep(span);

// Add floor plan
app.Add(floorPlan);

// ------------------------------------------------------------------------------------------------
// Output
// ------------------------------------------------------------------------------------------------
Text text = new Text(length, -5, 0.5);
text.HJust = 1;
text.VJust = 1;
text.FontFamilyName = "Courier New";
text.AppendLine("───────────────────────────────────────");
text.AppendLine($"  Hallenrechner – {project}");
text.AppendLine("───────────────────────────────────────");
text.AppendLine("  Eingabewerte");
text.AppendLine($"    Anzahl Rahmen      {numberOfFrames,9:D}");
text.AppendLine($"    Stützenhöhe        {height,9:F2} m");
text.AppendLine($"    Stützweite         {span,9:F2} m");
text.AppendLine($"    Achsabstand        {frameSpacing,9:F2} m");
text.AppendLine($"    Dachneigung        {roofPitch,9:F2} °");
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
app.Add(text);

app.Show();
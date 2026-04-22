using ISections;

using static System.Math;

// Basic values
string project = "Halle S2-12-075";
int numberOfFrames = 11;
double span = 15.0;
double height = 4.0;
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

// Output
Console.Clear();
Console.WriteLine("───────────────────────────────────────");
Console.WriteLine($"  Hallenrechner – {project}");
Console.WriteLine("───────────────────────────────────────");
Console.WriteLine("  Eingabewerte");
Console.WriteLine($"    Anzahl Rahmen      {numberOfFrames,9:D}");
Console.WriteLine($"    Stützenhöhe        {height,9:F2} m");
Console.WriteLine($"    Stützweite         {span,9:F2} m");
Console.WriteLine($"    Achsabstand        {frameSpacing,9:F2} m");
Console.WriteLine($"    Dachneigung        {roofPitch,9:F2} °");
Console.WriteLine($"    Profil Stützen     {profileColumns.Name,9}");
Console.WriteLine($"    Profil Riegel      {profileBeams.Name,9}");
Console.WriteLine("───────────────────────────────────────");
Console.WriteLine("  Ergebnisse");
Console.WriteLine($"    Länge der Halle    {length,9:F2} m");
Console.WriteLine($"    Grundfläche        {groundArea,9:F2} m²");
Console.WriteLine($"    Länge Stützen      {lengthColumns,9:F2} m");
Console.WriteLine($"    Länge Riegel       {lengthBeams,9:F2} m");
Console.WriteLine($"    Gesamtgewicht      {steelWeight / 1000,9:F2} to");
Console.WriteLine("───────────────────────────────────────");
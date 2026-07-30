using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Runtime.CompilerServices;

// Hilfsfunktion für Pfad relativ zu Projekt
static string ResolvePath(string fileName, [CallerFilePath] string sourceFile = "") => Path.Combine(Path.GetDirectoryName(sourceFile)!, fileName);

// Werte für Excel-Datei
double[] heights = [3.5, 4.0, 4.5, 5.0];
double[] moments = [120.7, 138.2, 156.9, 176.8];

// Arbeitsmappe und Tabellenblatt erzeugen
XSSFWorkbook workbook = new XSSFWorkbook();
ISheet sheet = workbook.CreateSheet("Results");

// Kopfzeile
IRow header = sheet.CreateRow(0);
header.CreateCell(0).SetCellValue("Height");
header.CreateCell(1).SetCellValue("Moment");

// Weitere Zeilen
for (int i = 0; i < heights.Length; i++)
{
    IRow row = sheet.CreateRow(i + 1);
    row.CreateCell(0).SetCellValue(heights[i]);
    row.CreateCell(1).SetCellValue(moments[i]);
}

// Schreiben
using FileStream fs = File.Create(ResolvePath("data/results.xlsx"));
workbook.Write(fs);

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Runtime.CompilerServices;

// Hilfsfunktion für Pfad relativ zu Projekt (einfach kopieren)
static string ResolvePath(string fileName, [CallerFilePath] string sourceFile = "") => Path.Combine(Path.GetDirectoryName(sourceFile)!, fileName);

// Arbeitsmappe und Tabellenblatt
XSSFWorkbook workbook = new XSSFWorkbook(ResolvePath("data/profile.xlsx"));
ISheet sheet = workbook.GetSheetAt(0);

// Zeilen einlesen
for (int i = 1; i <= sheet.LastRowNum; i++)
{
    IRow row = sheet.GetRow(i);
    string profile = row.GetCell(0).StringCellValue;
    double width = row.GetCell(1).NumericCellValue;
    double height = row.GetCell(2).NumericCellValue;
    Console.WriteLine($"{profile}: Breite {width} cm, Höhe {height} cm");
}

Console.WriteLine("Schaltjahre von 1800 bis 2026");
for (int year = 1800; year <= 2026; year++)
{
    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
    {
        Console.Write($"{year} ");
    }
}
Console.WriteLine("");

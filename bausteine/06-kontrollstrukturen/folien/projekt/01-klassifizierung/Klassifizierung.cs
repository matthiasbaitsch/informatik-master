// | Energieeffizienzklasse | Heizwärmebedarf $q_h$ |
// |------------------------|-----------------------|
// | A+                     | < 30                  |
// | A                      | 30 – 50               |
// | B oder schlechter      | ≥ 50                  |


double qh = 49.9;

Console.Clear();
Console.WriteLine($"Heizwärmebedarf: {qh}");
Console.Write("Energieeffizienzklasse: ");

if (qh < 30)
{
    Console.WriteLine("A+");
}
else if (qh < 50)
{
    Console.WriteLine("A");
}
else
{
    Console.WriteLine("B oder schlechter");
}
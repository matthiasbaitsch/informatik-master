Console.Clear();


Console.WriteLine("Bochum, ich komm' aus dir");

{
    double x = 1.0 / 3.0;
    Console.WriteLine(x);
}

{
    double x = 1.0 / 3.0;
    Console.WriteLine($"Ein drittel ist etwa {x}");
}

// Beispiele Format
Console.WriteLine();

double force = 12345.6789;
Console.WriteLine($"| Kraft: {force} N        |");
Console.WriteLine($"| Kraft: {force:0.00} N          |");
Console.WriteLine($"| Kraft: {force,19:0.000} |");
Console.WriteLine($"| Kraft: {force,-19:0.0000} |");
Console.WriteLine($"| Kraft: {-force:0.000 N (Zug)  ;0.000 N (Druck)} |");
Console.WriteLine($"| Kraft: {force:0.000 N (Zug)  ;0.000 N (Druck)} |");
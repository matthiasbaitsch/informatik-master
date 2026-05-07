Complex z1 = new Complex(3, 4);
Complex z2 = new Complex(4, 2);

Console.Clear();
z1.Print("z1");
z2.Print("z2");

Console.WriteLine();
Console.WriteLine($"Betrag z1          = {z1.Abs()}");
Console.WriteLine($"Argument z1        = {z1.Arg()}");
z1.Conjugate().Print("Konjugierte z1");

Console.WriteLine();
z1.Add(z2).Print("z1 + z2");
z1.Subtract(z2).Print("z1 - z2");
z1.Multiply(z2).Print("z1 * z2");
z1.Divide(z2).Print("z1 / z2");
z1.Power(3).Print("z1 ^ 3");
z1.Power(3).Power(1.0 / 3.0).Print("(z1 ^ 3)^(1/3)");

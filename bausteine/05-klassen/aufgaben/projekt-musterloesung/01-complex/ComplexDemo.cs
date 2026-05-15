Complex z1 = new Complex(3, 4);
Complex z2 = new Complex(4, 2);

Console.Clear();
Console.WriteLine("Direkter Zugriff auf Eigenschaften");
Console.WriteLine($"Re(z1) = {z1.Re}, Im(z1) = {z1.Im}");
Console.WriteLine($"Re(z2) = {z2.Re}, Im(z2) = {z2.Im}");

Console.WriteLine("\nAusgabe mit Print-Methode");
z1.Print("z1");
z2.Print("z2");

Console.WriteLine("\nAddition und Subtraktion");
Complex z3 = z1.Add(z2);
Complex z4 = z1.Subtract(z2);
z3.Print("z3");
z4.Print("z4");

Console.WriteLine("\nMultiplikation und Division");
Complex z5 = z1.Multiply(z2);
Complex z6 = z1.Divide(z2);
z5.Print("z5");
z6.Print("z6");

Console.WriteLine("\nKonjugiert-komplexe Zahl");
Complex z7 = z1.Conjugate();
Complex z8 = z1.Multiply(z7);
z7.Print("z7");
z8.Print("z8");

Console.WriteLine("\nPolarkoordinaten");
double a = z1.Abs();
double b = z1.Arg();
Console.WriteLine($"|z1| = {a}");
Console.WriteLine($"arg(z1) = {b}");

Console.WriteLine("\nPotenz");
Complex z9 = z1.Power(1.0 / 3.0);
Complex z10 = z9.Power(3);
z9.Print("z9");
z10.Print("z10");

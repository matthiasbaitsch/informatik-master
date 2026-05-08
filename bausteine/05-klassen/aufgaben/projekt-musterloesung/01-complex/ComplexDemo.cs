Complex z1 = new Complex(3, 4);
Complex z2 = new Complex(4, 2);

Console.Clear();
z1.Print("z1");
z2.Print("z2");

Complex z3 = z1.Add(z2);
Complex z4 = z1.Subtract(z2);
z3.Print("z3");
z4.Print("z4");

Complex z5 = z1.Multiply(z2);
Complex z6 = z1.Divide(z2);
z5.Print("z5");
z6.Print("z6");

Complex z7 = z1.Multiply(z1.Conjugate());
z7.Print("z7");
Console.WriteLine($"|z1|    = {z1.Abs()}");
Console.WriteLine($"arg(z1) = {z1.Arg()}");

Complex z8 = z1.Power(1.0 / 3.0);
Complex z9 = z8.Power(3);
z8.Print("z8");
z9.Print("z9");

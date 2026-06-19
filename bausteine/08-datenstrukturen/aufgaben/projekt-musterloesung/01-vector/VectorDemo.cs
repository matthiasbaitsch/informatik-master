Vector x = new Vector([1.7, 2.1, 0.1, 3.7]);
Vector y = new Vector([2.1, 1.2, 11.9, 7.3]);

// Ausgabe
x.Print("x");
y.Print("y");

// Skalarprodukt und Norm
Console.WriteLine($"x⋅y = {x.Dot(y)}");
Console.WriteLine($"|x| = {x.Norm()}");

// Addition
Vector z = x.Add(y);
z.Print("z");

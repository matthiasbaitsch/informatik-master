Vector x = new Vector([1.7, 2.1, 0.1, 3.7]);
Vector y = new Vector([2.1, 1.2, -11.9, 7.3]);

// Ausgabe
x.Print("x");
y.Print("y");

// Skalarprodukt und Norm
Console.WriteLine($"x⋅y = {x.Dot(y)}");
Console.WriteLine($"|x|2 = {x.EuclidianNorm()}");
Console.WriteLine($"|x|max = {x.MaxNorm()}");
Console.WriteLine($"|y|max = {y.MaxNorm()}");

// Addition, Subtraktion und Multiplikation
Vector z1 = x.Add(y);
Vector z2 = x.Subtract(y);
Vector z3 = x.Multiply(4);
z1.Print("z1 = x + y");
z2.Print("z2 = x - y");
z3.Print("z3 =   4 x");

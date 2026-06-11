{
    int[] a = new int[3];
    a[0] = 7;
    a[1] = 54;
    a[2] = 42;
    int s = a[0] + a[1] + a[2];
    int n = a.Count();
    Console.WriteLine($"s = {s} und n = {n}");
}

{
    // ### Arrayvariablen sind Referenzvariablen
    int[] a = new int[3];
    a[0] = 4;
    a[1] = 8;
    a[2] = 1;
    int[] b = a;
    b[1] = 71;
    Console.WriteLine($"a[0] = {a[0]}");
    Console.WriteLine($"a[1] = {a[1]}");
    Console.WriteLine($"a[2] = {a[2]}");
}

{
    // int[] a = new int[3];
    // a[3] = 1;
}

{
    int[] a = { 1, 98, 4 };
    Console.WriteLine($"a[0] = {a[0]}, a[1] = {a[1]}, a[2] = {a[2]}");
}

{
    int[,] a = new int[2, 2];
    a[0, 0] = 1;
    a[0, 1] = 2;
    a[1, 0] = 3;
    a[1, 1] = 4;
}

{
    double[] a = { 3.5, 1.2, 4.8, 2.1 };
    Array.Sort(a);
    Console.WriteLine($"{a[0]}, {a[1]}, {a[2]}, {a[3]}");
}

{
    int[] a = { 4, 6, 3, 0 };
    Console.WriteLine(String.Join(", ", a));
}

{
    double[] a = { 3.5, 1.2, 4.8, 2.1 };
    Array.Sort(a);
    Console.WriteLine(String.Join("; ", a));
}

{
    double[] values = { 3.5, 1.2, 4.8, 2.1 };
    int i1 = Array.IndexOf(values, 4.8);
    int i2 = Array.IndexOf(values, 9.9);
    Console.WriteLine($"i1 = {i1}, i2 = {i2}");
}

{
    // ## Arrays von Objekten
    Fraction[] a = new Fraction[3];
    Console.WriteLine(a[0] == null);
    a[0] = new Fraction(1, 2);
    a[1] = new Fraction(3, 4);
    a[2] = a[0];
    a[0].Print("a[0]");
    a[1].Print("a[1]");
    a[2].Print("a[2]");
}
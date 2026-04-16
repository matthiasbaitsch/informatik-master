// Folie Operatoren
{
    double a = 0.1;
    double b = 0.2;
    double c = a + b;
    Console.WriteLine($"c: {c}");
}

{
    int a = 9;
    int b = 4;
    int c = a / b;
    Console.WriteLine($"c: {c}");
}

{
    int a = 9;
    int b = 5;
    int c = a % b;
    Console.WriteLine($"c: {c}");
}

{
    string a = "Bochum";
    string b = "ich komm' aus dir";
    string c = a + ", " + b + " - " + 4630;
    Console.WriteLine($"c: {c}");
}

{
    double x = 0.1 + 0.2;
    Console.WriteLine($"x: {x}");
}

// Folie Gleitkommazahlen

static void PrintBinary(double value)
{
    long bits = BitConverter.DoubleToInt64Bits(value);
    string binary = Convert.ToString(bits, 2).PadLeft(64, '0');
    Console.WriteLine($"Dezimal: {value}");
    Console.WriteLine($"  Binär: {binary[0..1]} {binary[1..12]} {binary[12..64]}");
}

PrintBinary(15);
PrintBinary(Math.PI);
PrintBinary(0.3);

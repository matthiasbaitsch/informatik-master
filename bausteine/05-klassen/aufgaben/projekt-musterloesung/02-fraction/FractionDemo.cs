Fraction q1 = new Fraction(22, 7);
Fraction q2 = new Fraction(-3, 2);

Console.Clear();
Console.WriteLine("1. Direkter Zugriff auf Felder");
Console.WriteLine($"q1: Zähler = {q1.A}, Nenner = {q1.B}");
Console.WriteLine($"q2: Zähler = {q2.A}, Nenner = {q2.B}");

Console.WriteLine("\n2. Ausgabe mit Print-Methode");
q1.Print("q1");
q2.Print("q2");

Console.WriteLine("\n3. Kehrwert");
Fraction q3 = q1.Inverse();
q3.Print("q3 = 1 / q1");

Console.WriteLine("\n4. Umwandlung in Dezimalzahl");
double x1 = q1.ToDouble();
Console.WriteLine($"q1 ≈ {x1}");

Console.WriteLine("\n5. Addition und Subtraktion");
Fraction q4 = q1.Add(q2);
Fraction q5 = q1.Subtract(q2);
q4.Print("q4 = q1 + q2");
q5.Print("q5 = q1 - q2");

Console.WriteLine("\n6. Multiplikation und Division");
Fraction q6 = q1.Multiply(q2);
Fraction q7 = q1.Divide(q2);
q6.Print("q6 = q1 * q2");
q7.Print("q7 = q1 / q2");

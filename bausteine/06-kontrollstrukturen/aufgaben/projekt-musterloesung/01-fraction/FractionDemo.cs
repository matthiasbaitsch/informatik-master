Fraction q1 = new Fraction(-22, -7);
Fraction q2 = new Fraction(3, -2);
Fraction q3 = new Fraction(44, 14);

Console.WriteLine("Konstruktor");
q1.Print("q1");
q2.Print("q2");
q3.Print("q3");

Console.WriteLine("\nVergleich");
int c1 = q1.CompareTo(q2);
int c2 = q2.CompareTo(q1);
int c3 = q1.CompareTo(q3);
Console.WriteLine($"q1 and q2: {c1}");
Console.WriteLine($"q2 and q1: {c2}");
Console.WriteLine($"q1 and q3: {c3}");

Console.WriteLine("\nGleichheit und Äquivalenz");
bool b1 = q1.Equals(q3);
bool b2 = q1.IsEquivalent(q3);
Console.WriteLine($"q1 ==  q3: {b1}");
Console.WriteLine($"q1 ~   q3: {b2}");

Console.WriteLine("\nVereinfachen");
Fraction q4 = new Fraction(462, 1071);
Fraction q5 = q4.Simplify();
q4.Print("q4");
q5.Print("q5");

Console.WriteLine("\nEulersche Zahl");
int kf = 1;
Fraction e = new Fraction(1, 1);
for (int i = 1; i < 8; i++)
{
    kf *= i;
    e = e.Add(new Fraction(1, kf)).Simplify();
}
Console.WriteLine($"e ≈ {e.ToDouble()}");

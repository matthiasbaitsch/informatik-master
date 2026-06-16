{
    // ## Listen: Das Allerwichtigste
    List<string> names = [];
    names.Add("Gilmore");
    names.Add("Slater");
    names.Add("Machado");
    names[1] = "Lopez";
    Console.WriteLine($"n = {names.Count}");
    Console.WriteLine(names[2]);
    Console.WriteLine(String.Join(" | ", names));
}

{
    // ## `List`-Klasse: Elemente suchen und entfernen
    List<int> numbers = [42, 54, 1];
    Console.WriteLine(numbers.Contains(1));
    Console.WriteLine(numbers.IndexOf(54));
    Console.WriteLine(numbers.IndexOf(1));
    numbers.RemoveAt(0);
    numbers.Remove(1);
    numbers.Remove(99);
    Console.WriteLine(String.Join(", ", numbers));
}

{
    // ## Beispiel 1: Mit Array
    double s2 = 0;
    double[] forces = [12.5, 3.2, 8.7, 1.4, 9.1];

    foreach (double f in forces)
    {
        s2 += f * f;
    }
    Console.WriteLine($"Summe der Quadrate: {s2}");
    Console.WriteLine($"Summe mit Sum: {forces.Sum()}");
    Console.WriteLine($"Min und Max: {forces.Min()} - {forces.Max()}");
}

{
    // ## Dinge nur einmal speichern: `HashSet`
    HashSet<string> materials = ["Concrete", "Wood"];
    materials.Add("Steel");
    materials.Add("Steel");
    Console.WriteLine(String.Join(" • ", materials));
    materials.Remove("Concrete");
    materials.Add("Glass");
    Console.WriteLine(String.Join(" • ", materials));
    Console.WriteLine(materials.Contains("Steel"));
    Console.WriteLine(materials.Contains("Concrete"));
}

{
    // ### Array und Liste umwandeln
    double[] array = [3.5, 1.2, 4.8];
    List<double> list = array.ToList();
    list.Add(2.1);
    array = list.ToArray();
    Console.WriteLine(array.Length);
}

{
    // `IEnumerable` als Text ausgeben
    List<string> names = ["Alice", "Bob", "Carol"];
    Console.WriteLine(String.Join(", ", names));

}

{
    // ## Beispiel 3: Schlüssel und Werte eines `Dictionary`
    Dictionary<string, double> height = [];
    height["Eiffel Tower"] = 330.0;
    height["Burj Khalifa"] = 828.0;
    height["Empire State"] = 443.0;

    foreach (string building in height.Keys)
    {
        Console.WriteLine($"{building}: {height[building]}");
    }
}
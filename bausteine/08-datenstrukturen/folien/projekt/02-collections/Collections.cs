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
    List<int> numbers = [42, 54, 1];
    Console.WriteLine(numbers.Contains(1));
    Console.WriteLine(numbers.IndexOf(54));
    numbers.RemoveAt(0);
    numbers.Remove(1);
    numbers.Remove(99);
    Console.WriteLine(String.Join(", ", numbers));
}

{
    double sum = 0;
    double[] sizes = [3.5, 1.2, 4.8, 2.1];
    foreach (double s in sizes)
    {
        sum += s;
    }
    Console.WriteLine($"Summe = {sum}");
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
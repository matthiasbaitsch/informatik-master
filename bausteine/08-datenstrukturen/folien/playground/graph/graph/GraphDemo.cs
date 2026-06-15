Graph g = new Graph();

g.AddRoute("S", "A", 6);
g.AddRoute("S", "B", 2);
g.AddRoute("A", "B", 3);
g.AddRoute("B", "Z", 5);
g.AddRoute("A", "Z", 1);

Console.WriteLine($"Nodes: {String.Join(", ", g.Places)}");
g.Print();
Console.WriteLine($"Neighbours of B: {String.Join(", ", g.Neighbours("B"))}");

HashSet<string> places = [ "A", "B", "C", "D" ];
Dictionary<string, double> distances = [];
BoxWithPlaces box = new BoxWithPlaces(places, distances);
distances["A"] = 4;
distances["B"] = 1;
distances["C"] = 2;
distances["D"] = 2;
while (box.IsEmpty())
{
    Console.WriteLine(box.TakeClosestPlace());
}

ShortestPath sp = new ShortestPath("S", "Z", g);
Console.WriteLine(sp.Distance);
Console.WriteLine(String.Join(", ", sp.Places));
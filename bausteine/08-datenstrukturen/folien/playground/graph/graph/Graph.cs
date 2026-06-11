public class Graph
{

    public HashSet<string> Places = [];

    private Dictionary<string, Dictionary<string, double>> routes = [];

    public void AddPlace(string n)
    {
        this.Places.Add(n);
        if (!this.routes.ContainsKey(n)) { this.routes[n] = []; }
    }

    public void AddRoute(string p1, string p2, double weight)
    {
        this.AddPlace(p1);
        this.AddPlace(p2);
        this.routes[p1][p2] = weight;
        this.routes[p2][p1] = weight;
    }

    public double Distance(string n1, string n2)
    {
        return this.routes[n1][n2];
    }

    public string[] Neighbours(string n1)
    {
        return this.routes[n1].Keys.ToArray();
    }

    public void Print()
    {
        foreach (string n1 in this.routes.Keys)
        {
            foreach (string n2 in this.routes[n1].Keys)
            {
                Console.WriteLine($"{n1,10} - {n2,-10}: {this.routes[n1][n2]}");
            }
        }
    }
}
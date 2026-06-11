public class ShortestPath
{
    private Dictionary<string, double> InitializeDist(string from, Graph g)
    {
        Dictionary<string, double> dist = [];
        foreach (string node in g.Places)
        {
            dist[node] = Double.PositiveInfinity;
        }
        dist[from] = 0;
        return dist;
    }

    public double Distance;
    public List<string> Places = [];

    public ShortestPath(string from, string to, Graph g)
    {
        Dictionary<string, string> prev = [];
        Dictionary<string, double> dist = InitializeDist(from, g);
        BoxWithPlaces box = new BoxWithPlaces(g.Places, dist);

        while (!box.IsEmpty())
        {
            string place = box.TakeClosestPlace();
            foreach (string neighbour in g.Neighbours(place))
            {
                double d = dist[place] + g.Distance(place, neighbour);
                if (d < dist[neighbour])
                {
                    dist[neighbour] = d;
                    prev[neighbour] = place;
                }
            }
        }

        string nn = to;
        while (nn != from)
        {
            this.Places.Add(nn);
            nn = prev[nn];
        }
        this.Places.Add(nn);
        this.Places.Reverse();
        this.Distance = dist[to];
    }
}
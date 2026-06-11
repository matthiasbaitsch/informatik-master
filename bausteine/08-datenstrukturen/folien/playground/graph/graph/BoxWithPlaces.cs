public class BoxWithPlaces
{
    private HashSet<string> places;
    private Dictionary<string, double> distances;

    public BoxWithPlaces(HashSet<string> places, Dictionary<string, double> distances)
    {
        this.places = new HashSet<string>(places);
        this.distances = distances;
    }

    public bool IsEmpty() { return this.places.Count == 0; }

    public string TakeClosestPlace()
    {
        string closestPlace = this.places.First();
        foreach (string place in this.places)
        {
            if (this.distances[place] < this.distances[closestPlace])
            {
                closestPlace = place;
            }
        }
        this.places.Remove(closestPlace);
        return closestPlace;
    }
}
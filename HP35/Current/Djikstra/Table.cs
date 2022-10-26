namespace HP35.Current.Djikstra;

public class Table
{
    private const int ARRAYSIZE = 541;
    private CityNode[] cities;
    private int[] distances;
    private CityNode[] prevCities;

    public Table(CityNode[] cities, CityNode start)
    {
        this.cities = cities;
        distances = new int[ARRAYSIZE];
        prevCities = new CityNode[ARRAYSIZE];
        foreach (var city in this.cities)
        {
            distances[city.hashCode] = Int32.MaxValue;
        }
        distances[start.hashCode] = 0;
    }

    public int getDistance(CityNode city)
    {
        return distances[city.hashCode];
    }

    public void updateValues(CityNode city, int dist, CityNode prev)
    {
        distances[city.hashCode] = dist;
        prevCities[city.hashCode] = prev;
    }

    public CityNode getPrevVertex(CityNode city)
    {
        return prevCities[city.hashCode];
    }
}
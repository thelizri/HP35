using HP35.Current.Graph;

namespace HP35.Current.Djikstra;

public class PriorityQueue
{
    private const int ARRAYSIZE = 541;
    private CityNode[] unvisitedCities;
    private Table[] pathTable;

    public PriorityQueue(CityNode[] cities, CityNode start)
    {
        unvisitedCities = cities.ToArray();
        
        pathTable = new Table[ARRAYSIZE];

        pathTable[start.hashCode] = new Table(start, 0);
        foreach (var city in cities)
        {
            if (city is not null && !city.Equals(start))
            {
                pathTable[city.hashCode] = new Table(city);
            }
        }
    }

    public Table[] getTable()
    {
        return pathTable;
    }

    public CityNode next()
    {
        CityNode result = null;
        foreach (var city in unvisitedCities)
        {
            if (city is null) continue;
            if (result is null) result = city;
            if (pathTable[city.hashCode].minDistance < pathTable[result.hashCode].minDistance)
                result = city;
        }
        if(result is not null) unvisitedCities[result.hashCode] = null;
        return result;
    }
}
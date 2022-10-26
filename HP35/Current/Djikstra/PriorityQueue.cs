using HP35.Current.Graph;

namespace HP35.Current.Djikstra;

public class PriorityQueue
{
    private const int ARRAYSIZE = 541;
    private CityNode[] unvisitedCities;
    private Table[] pathTable;

    public PriorityQueue(CityNode[] cities, CityNode start)
    {
        makeCopyOfCities(cities);
        
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

    private void makeCopyOfCities(CityNode[] cities)
    {
        unvisitedCities = new CityNode[52];
        int i = 0;
        foreach (var city in cities)
        {
            if (city is null) continue;
            unvisitedCities[i++] = city;
        }
    }

    public Table[] getTable()
    {
        return pathTable;
    }

    public CityNode next()
    {
        CityNode result = null;
        int i = -1;
        int index = 0;
        foreach (var city in unvisitedCities)
        {
            i++;
            if (city is null) continue;
            if (result is null)
            {
                result = city;
                index = i;
            }
            if (pathTable[city.hashCode].minDistance < pathTable[result.hashCode].minDistance)
            {
                result = city;
                index = i;
            }
        }
        if(result is not null) unvisitedCities[index] = null;
        return result;
    }
}
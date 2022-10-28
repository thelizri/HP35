using HP35.Current.Graph;

namespace HP35.Current.Djikstra;

public class PriorityQueue
{
    private CityNode[] unvisitedCities;
    private Table table;
    private int minIndex;

    public PriorityQueue(CityNode[] cities, CityNode start)
    {
        makeCopyOfCities(cities);
        table = new Table(unvisitedCities, start);
        minIndex = 0;
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

    public Table getTable()
    {
        return table;
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
            if (table.getDistance(city) < table.getDistance(result))
            {
                result = city;
                index = i;
            }
        }
        if(result is not null) unvisitedCities[index] = null;
        return result;
    }
    
}
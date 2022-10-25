using HP35.Current.Graph;

namespace HP35.Current.Djikstra;

public class Djikstra
{
    private const int ARRAYSIZE = 541;
    private CityNode[] cities;
    private readonly string fileAddress;

    public Djikstra()
    {
        fileAddress = Path.GetFullPath("trains.csv");
        cities = new CityNode[ARRAYSIZE];
        read();
    }
    private void read()
    {
        if (!File.Exists(fileAddress))
        {
            Console.WriteLine("File does not exist");
            return;
        }
        string[] lines = File.ReadAllLines(fileAddress);
        foreach (string line in lines)
        {
            var rows = line.Split(',');
            CityNode a = addOrGetCity(rows[0]);
            CityNode b = addOrGetCity(rows[1]);
            RailRoadConnection railRoadConnection = new RailRoadConnection(a, b, Int32.Parse(rows[2]));
        }
    }

    private CityNode addOrGetCity(string name)
    {
        int index = hash(name);
        CityNode result = new CityNode(name, index);
        if (cities[index] is null)
        {
            cities[index] = result;
        }
        else
        {
            if(!cities[index].Equals(result)) Console.WriteLine("Collision");
            result = cities[index];
        }

        return result;
    }

    private int hash(string name) {
        int hash = 7;
        int power = 1;
        for (int i = 0; i < name.Length; i++) {
            hash +=  name[i]*power;
            power = (power*13)%cities.Length;
        }
        return hash % ARRAYSIZE; //ARRAYSIZE is 541
    }

    private CityNode lookupCity(string name)
    {
        CityNode result = cities[hash(name)];
        if (result is null || !name.Equals(result.city))
            throw new ArgumentException($"City \"{name}\" does not exist");
        return result;
    }

    public void search(string cityA, string cityB)
    {
        CityNode start = lookupCity(cityA);
        CityNode destination = lookupCity(cityB);
        
        var unvisited = cities.ToArray();
        Table[] pathTable = new Table[ARRAYSIZE];

        pathTable[start.hashCode] = new Table(start, 0);
        foreach (var city in cities)
        {
            if (city is not null && !city.Equals(start))
            {
                pathTable[city.hashCode] = new Table(city);
            }
        }
        
        while (true)
        {
            var city = getClosestUnvisitedVertex(unvisited, pathTable);
            if (city is null) break;
            int distance = pathTable[city.hashCode].minDistance;
            calculateDistanceFromStartVertex(city, pathTable, distance);
            unvisited[city.hashCode] = null;
        }
        
        printResults(pathTable, start, destination);
    }

    private void calculateDistanceFromStartVertex(CityNode currentCity, Table[] pathTable, int distance)
    {
        var neighbors = currentCity.getNeighbors();
        foreach (var neighbor in neighbors)
        {
            int index = neighbor.hashCode;
            int newDistance = currentCity.getDistanceToNode(neighbor) + distance;
            if (newDistance < pathTable[index].minDistance)
            {
                pathTable[index].minDistance = newDistance;
                pathTable[index].prevVertex = currentCity;
            }
        }
    }

    private CityNode getClosestUnvisitedVertex(CityNode[] unvisited, Table[] pathTable)
    {
        CityNode result = null;
        foreach (var city in unvisited)
        {
            if (city is null) continue;
            if (result is null) result = city;
            if (pathTable[city.hashCode].minDistance < pathTable[result.hashCode].minDistance)
                result = city;
        }
        return result;
    }

    private void printResults(Table[] pathTable, CityNode start, CityNode destination)
    {
        int distance = pathTable[destination.hashCode].minDistance;
        Console.WriteLine($"Distance from {start} to {destination} is {distance}");
        var next = destination;
        while (next is not null)
        {
            Console.Write(next+", ");
            next = pathTable[next.hashCode].prevVertex;
        } Console.WriteLine();
    }

}
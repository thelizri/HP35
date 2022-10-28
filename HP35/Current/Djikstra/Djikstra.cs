using HP35.Current.Graph;

namespace HP35.Current.Djikstra;

public class Djikstra
{
    private const int ARRAYSIZE = 541;
    private CityNode[] cities;
    private readonly string fileAddress;
    private Results ourResults;

    public Djikstra()
    {
        fileAddress = Path.GetFullPath("trains.csv");
        cities = new CityNode[ARRAYSIZE];
        ourResults = new Results();
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
            power = (power*13)%ARRAYSIZE;
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

        //if (checkResults(start, destination)) return;
        
        var queue = new PriorityQueue(cities, start);
        var table = queue.getTable();

        while (true)
        {
            var city = queue.next();
            if (city is null) break;
            int distance = table.getDistance(city);
            calculateDistanceFromStartVertex(city, table, distance);
        }
        
        printResults(table, start, destination);
        //ourResults.add(table, start);
    }

    private bool checkResults(CityNode start, CityNode destination)
    {
        var table = ourResults.get(start);
        if (table is not null)
        {
            printResults(table, start, destination);
            return true;
        }

        table = ourResults.get(destination);
        if (table is not null)
        {
            printResults(table, destination, start);
            return true;
        }
        
        return false;
    }

    private void calculateDistanceFromStartVertex(CityNode currentCity, Table table, int distance)
    {
        var neighbors = currentCity.getNeighbors();
        foreach (var neighbor in neighbors)
        {
            int newDistance = currentCity.getDistanceToNode(neighbor) + distance;
            if (newDistance < table.getDistance(neighbor))
            {
                table.updateValues(neighbor, newDistance, currentCity);
            }
        }
    }

    private void printResults(Table table, CityNode start, CityNode destination)
    {
        int distance = table.getDistance(destination);
        Console.WriteLine($"Distance from {start} to {destination} is {distance}");
        var next = destination;
        while (next is not null)
        {
            Console.Write(next+", ");
            next = table.getPrevVertex(next);
        } Console.WriteLine();
    }

}
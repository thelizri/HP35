using HP35.Current.Graph;

namespace HP35.Current.Djikstra;

public class Djikstra
{
    private const int ARRAYSIZE = 541;
    public CityNode[] cities;
    private CityNode[] minPath;
    private int minimumTime;
    private int maxDepthSearch;
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

    private CityNode lookup(string name)
    {
        CityNode result = cities[hash(name)];
        if (result is null || !name.Equals(result.city))
            throw new ArgumentException($"City \"{name}\" does not exist");
        return result;
    }
    
    public void depthFirstSearch(string cityStart, string cityDestination, int max)
    {
        var start = lookup(cityStart);
        var destination = lookup(cityDestination);
        maxDepthSearch = max;
        minimumTime = Int32.MaxValue;
        minPath = null;
        var path = new List<CityNode>();
        path.Add(start);
        findDestination(null,start, destination, 1, path);
        if (minPath is not null)
        {
            Console.WriteLine($"Total minutes to travel: {minimumTime}");
            var time = TimeSpan.FromMinutes(minimumTime);
            Console.WriteLine($"It takes {time.Hours} hours and {time.Minutes} minutes to travel between {start} and {destination}.");
            Console.WriteLine("Path: ");
            foreach (var city in minPath)
            {
                Console.Write($"{city}, ");
            }
            Console.WriteLine();
        }
    }

    private void findDestination(CityNode previous, CityNode current, CityNode destination,
         int depth, List<CityNode> path)
    {
        if (current.Equals(destination))
        {
            int distance = calculateDistance(path);
            if (distance < minimumTime)
            {
                minimumTime = distance;
                minPath = path.ToArray();
            }

            return;
        }
        if (depth > maxDepthSearch) return;
        if (amIWalkingInCircles(path, current)) return;
        var neighbors = current.getNeighbors();
        foreach (var city in neighbors)
        {
            if (city.Equals(previous)) continue;
            //Clone path then add node to path
            var clone = path.ToList();
            clone.Add(city);
            findDestination(current, city, destination,
                depth+1, clone);
        }
    }

    private int calculateDistance(List<CityNode> path)
    {
        int distance = 0;
        for (int i = 0; i < path.Count - 1; i++)
        {
            var city = path[i];
            distance += city.getDistanceToNode(path[i+1]);
        }
        return distance;
    }

    private bool amIWalkingInCircles(List<CityNode> path, CityNode node)
    {
        for (int i = 0; i < path.Count - 1; i++)
        {
            if (node.Equals(path[i])) return true;
        }
        return false;
    }

    public void searchMinPath(string cityA, string cityB)
    {
        CityNode start = lookup(cityA);
        CityNode destination = lookup(cityB);
        
        List<CityNode> unvisited = new List<CityNode>();
        Table[] pathTable = new Table[ARRAYSIZE];
        
        unvisited.Add(start);
        int index = start.hashCode;
        pathTable[index] = new Table(start, 0);
        
        foreach (var city in cities)
        {
            if (city is not null && !city.Equals(start))
            {
                unvisited.Add(city);
                pathTable[city.hashCode] = new Table(start);
            }
        }
        
        while (true)
        {
            var city = getClosestUnvisitedVertex(unvisited, pathTable);
            if (city is null) break;
            int distance = pathTable[city.hashCode].minDistance;
            calculateDistanceFromStartVertex(city, pathTable, distance);
            unvisited.Remove(city);
        }
        
        printResults(pathTable, start, destination);
    }

    private void calculateDistanceFromStartVertex(CityNode currentCity, Table[] pathTable, int distance)
    {
        currentCity.visited = true;
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

    private CityNode getClosestUnvisitedVertex(List<CityNode> unvisited, Table[] pathTable)
    {
        CityNode result = null;
        foreach (var city in unvisited)
        {
            if (city.visited) continue;
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
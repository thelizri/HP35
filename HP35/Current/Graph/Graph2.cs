namespace HP35.Current.Graph;

public class Graph2
{
    public CityNode[] cities;
    private readonly string fileAddress;
    private CityNode[] minPath;
    private int minimumTime;
    private int maxDepthSearch;
    public class RailroadConnection
    {
        public CityNode a;
        public CityNode b;
        public int weight;

        public RailroadConnection(CityNode a, CityNode b, int weight)
        {
            this.a = a;
            this.b = b;
            this.weight = weight;
            a.adjacencyList.Add(this);
            b.adjacencyList.Add(this);
        }

        public CityNode getDestination(CityNode start)
        {
            if (start.Equals(a)) return b;
            if (start.Equals(b)) return a;
            throw new Exception("Something is wrong");
        }
    }

    public class CityNode
    {
        public List<RailroadConnection> adjacencyList;
        public readonly string city;

        protected bool Equals(CityNode other)
        {
            return city.Equals(other.city);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CityNode)obj);
        }

        public override int GetHashCode()
        {
            return city.GetHashCode();
        }

        public CityNode(string city)
        {
            adjacencyList = new List<RailroadConnection>();
            this.city = city;
        }

        public override string ToString()
        {
            return city;
        }

        public CityNode[] getNeighbors()
        {
            CityNode[] array = new CityNode[adjacencyList.Count];
            int i = 0;
            foreach (var edge in adjacencyList)
            {
                array[i++] = edge.getDestination(this);
            }
            return array;
        }

        public int getDistanceToNode(CityNode neighbor)
        {
            foreach (var edge in adjacencyList)
            {
                if (neighbor.Equals(edge.getDestination(this)))
                    return edge.weight;
            }
            throw new Exception("Fuck myself in the ass");
        }
    }
    
    public Graph2()
    {
        fileAddress = Path.GetFullPath("trains.csv");
        cities = new CityNode[541];
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
            RailroadConnection railroadConnection = new RailroadConnection(a, b, Int32.Parse(rows[2]));
        }
    }

    private CityNode addOrGetCity(string name)
    {
        CityNode result = new CityNode(name);
        int index = hash(name);
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
    
    public void print()
    {
        int i = 1;
        foreach (var city in cities)
        {
            if(city is not null) Console.WriteLine(city+", "+(i++));
        }
    }

    private int hash(string name) {
        int hash = 7;
        int power = 1;
        for (int i = 0; i < name.Length; i++) {
            hash +=  name[i]*power;
            power = (power*13)%cities.Length;
        }
        return hash % cities.Length;
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
        var neighbors = current.getNeighbors();
        foreach (var city in neighbors)
        {
            if (city.Equals(previous)) continue;
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

}
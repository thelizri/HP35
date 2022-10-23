namespace HP35.Current.Graph;

public class Graph
{
    public CityNode[] cities;
    private readonly string fileAddress;
    private static int globalCount;
    private CityNode[] minPath;
    private int maxDepthSearch;
    public class Edge
    {
        public CityNode a;
        public CityNode b;
        public int weight;

        public Edge(CityNode a, CityNode b, int weight)
        {
            this.a = a;
            this.b = b;
            this.weight = weight;
        }

        public void addItSelf()
        {
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
        public List<Edge> adjacencyList;
        public readonly string city;
        public bool visited;
        public bool instantiated;
        public List<Edge>.Enumerator enumerator;

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
            adjacencyList = new List<Edge>();
            this.city = city;
            visited = false;
        }

        public override string ToString()
        {
            visited = true;
            return city;
        }

        public CityNode getNextCity()
        {
            if (!instantiated)
            {
                instantiated = true;
                enumerator = adjacencyList.GetEnumerator();
            }

            if (enumerator.MoveNext())
            {
                CityNode destination = enumerator.Current.getDestination(this);
                return destination;
            }
            return null;
        }

        public CityNode getNextUnvisitedCity()
        {
            if (!instantiated)
            {
                instantiated = true;
                enumerator = adjacencyList.GetEnumerator();
            }
            while (enumerator.MoveNext())
            {
                CityNode destination = enumerator.Current.getDestination(this);
                if (!destination.visited)
                {
                    destination.visited = true;
                    return destination;
                }
            }
            return null;
        }
        
        public CityNode getNextUnvisitedCity(out int distance)
        {
            if (!instantiated)
            {
                instantiated = true;
                enumerator = adjacencyList.GetEnumerator();
            }
            while (enumerator.MoveNext())
            {
                CityNode destination = enumerator.Current.getDestination(this);
                if (!destination.visited)
                {
                    distance = enumerator.Current.weight;
                    return destination;
                }
            }
            distance = 0;
            return null;
        }

        public CityNode getClosestUnvisitedCity()
        {
            int min = Int32.MaxValue;
            CityNode closestCity = null;
            foreach (var edge in adjacencyList)
            {
                var city = edge.getDestination(this);
                if (!city.visited)
                {
                    if (edge.weight < min)
                    {
                        min = edge.weight;
                        closestCity = city;
                    }
                }
            }
            if (closestCity is not null) 
                closestCity.visited = true;
            return closestCity;
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
    
    public Graph()
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
            Edge edge = new Edge(a, b, Int32.Parse(rows[2]));
            edge.addItSelf();
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
    
    public void depthFirstSearchTest(string cityName)
    {
        globalCount = 1;
        var city = lookup(cityName);
        var stack = new Stack<CityNode>();
        Console.WriteLine(city);
        stack.Push(city);
        depthFirstSearchTest(city.getNextUnvisitedCity(), stack);
        reset();
    }

    private void depthFirstSearchTest(CityNode node, Stack<CityNode> stack)
    {
        if (node is null)
        {
            while (node is null)
            {
                if (stack.Count <= 0) return;
                node = stack.Pop();
                node = node.getNextUnvisitedCity();
            }

            Console.WriteLine(node);
            stack.Push(node);
            depthFirstSearchTest(node.getNextUnvisitedCity(), stack);
        }
        else
        {
            Console.WriteLine(node);
            stack.Push(node);
            depthFirstSearchTest(node.getNextUnvisitedCity(), stack);
        }
    }
    
    public void depthFirstSearch(string cityStart, string cityDestination, int max)
    {
        var start = lookup(cityStart);
        var destination = lookup(cityDestination);
        maxDepthSearch = max;
        var stack = new Stack<CityNode>();
        start.visited = true;
        stack.Push(start);
        var next = start.getNextUnvisitedCity();
        stack.Push(next);
        if (findDestination(next, destination, 1,stack))
        {
            int ii = 0;
            int totalDistance = calculateDistance();
            var time = TimeSpan.FromMinutes(totalDistance);
            Console.WriteLine($"It takes {time.Hours} hours and {time.Minutes} minutes to travel between {start} and {destination}.");
            Console.WriteLine("Path: ");
            for (int i = minPath.Length - 1; i >= 1; i--)
            {
                var node = minPath[i];
                if (ii++ > 8)
                {
                    ii = 0;
                    Console.WriteLine(node+", ");
                }
                else
                {
                    Console.Write(node+", ");
                }
            }
            Console.Write(minPath[0]+".");
        }
        reset();
    }

    private bool findDestination(CityNode current, CityNode destination,
         int depth, Stack<CityNode> stack)
    {
        if (depth > maxDepthSearch) return false;
        var next = current.getClosestUnvisitedCity();
        while (next is null)
        {
            if (stack.Count <= 0) return false;
            stack.Pop();
            current = stack.Peek();
            next = current.getClosestUnvisitedCity();
        }
        stack.Push(next);
        if (next.Equals(destination))
        {
            minPath = stack.ToArray();
            return true;
        }
        else
        {
            return findDestination(next, destination,  depth + 1, stack);
        }
    }

    private void reset()
    {
        foreach (var city in cities)
        {
            if (city is not null)
            {
                city.visited = false;
                city.instantiated = false;
            }
        }
    }

    private int calculateDistance()
    {
        int distance = 0;
        for (int i = 0; i < minPath.Length - 1; i++)
        {
            var city = minPath[i];
            distance += city.getDistanceToNode(minPath[i + 1]);
        }
        return distance;
    }

}
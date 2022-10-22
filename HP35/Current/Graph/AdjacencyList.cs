using System.Linq.Expressions;

namespace HP35.Current.Graph;

public class AdjacencyList
{
    public class CityNode
    {
        public string city;
        public bool visited;
        public bool instantiated;
        public LinkedList<CityNode> adjacentCities;
        public LinkedList<CityNode>.Enumerator enumerator;

        public CityNode(string name)
        {
            city = name;
            adjacentCities = new LinkedList<CityNode>();
        }

        public void addAdjacentCity(CityNode newCity)
        {
            adjacentCities.AddFirst(newCity);
            instantiated = false;
        }

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

        public CityNode getNextCity()
        {
            if (!instantiated)
            {
                enumerator = adjacentCities.GetEnumerator();
                instantiated = true;
            }
            if (enumerator.MoveNext())
            {
                return enumerator.Current;
            }
            else
            {
                enumerator = adjacentCities.GetEnumerator(); 
                return getNextCity(); //Possible infinite loop
            }
        }

        public CityNode getNextUnvisitedCity()
        {
            if (!instantiated)
            {
                enumerator = adjacentCities.GetEnumerator();
                instantiated = true;
            }
            while (enumerator.MoveNext())
            {
                if (!enumerator.Current.visited) 
                    return enumerator.Current;
            }
            return null;
        }

        public override string ToString()
        {
            visited = true;
            return city;
        }
    }

    private List<CityNode> cities;

    public AdjacencyList()
    {
        cities = new List<CityNode>();
    }

    public void addEdge(string cityA, string cityB)
    {
        CityNode a = createOrGetNode(cityA);
        CityNode b = createOrGetNode(cityB);
        a.addAdjacentCity(b);
        b.addAdjacentCity(a);
    }

    private CityNode createOrGetNode(string city)
    {
        CityNode a = new CityNode(city);
        if (cities.Contains(a))
        {
            int index = cities.IndexOf(a);
            a = cities[index];
        }
        else
        {
            cities.Add(a);
        }
        return a;
    }

    public CityNode lookup(string city)
    {
        CityNode a = new CityNode(city);
        if (cities.Contains(a))
        {
            int index = cities.IndexOf(a);
            a = cities[index];
        }
        else
        {
            throw new ArgumentException("This city does not exist");
        }
        return a;
    }

    public void depthFirstSearch(string cityName)
    {
        var city = lookup(cityName);
        var stack = new Stack<CityNode>();
        Console.WriteLine(city);
        stack.Push(city);
        depthFirstSearch(city.getNextUnvisitedCity(), stack);
        reset();
    }

    private void depthFirstSearch(CityNode node, Stack<CityNode> stack)
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
            depthFirstSearch(node.getNextUnvisitedCity(), stack);
        }
        else
        {
            Console.WriteLine(node);
            stack.Push(node);
            depthFirstSearch(node.getNextUnvisitedCity(), stack);
        }
    }

    public void reset()
    {
        foreach (var city in cities)
        {
            city.visited = false;
        }
    }
}
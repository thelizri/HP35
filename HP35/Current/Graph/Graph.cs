namespace HP35.Current.Graph;

public class Graph
{
    public Node[] cities;
    private readonly string fileAddress;
    public class Edge
    {
        public Node a;
        public Node b;
        public int weight;

        public Edge(Node a, Node b, int weight)
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
    }

    public class Node
    {
        public List<Edge> adjacencyList;
        public readonly string city;
        public bool visited;

        protected bool Equals(Node other)
        {
            return city.Equals(other.city);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node)obj);
        }

        public override int GetHashCode()
        {
            return city.GetHashCode();
        }

        public Node(string city)
        {
            adjacencyList = new List<Edge>();
            this.city = city;
            visited = false;
        }

        public override string ToString()
        {
            return city;
        }
    }

    public Graph()
    {
        fileAddress = Path.GetFullPath("trains.csv");
        cities = new Node[541];
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
            Node a = addCity(rows[0]);
            Node b = addCity(rows[1]);
            Edge edge = new Edge(a, b, Int32.Parse(rows[2]));
            edge.addItSelf();
        }
    }

    private Node addCity(string name)
    {
        Node result = new Node(name);
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
}
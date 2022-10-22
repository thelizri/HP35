namespace HP35.Current.Graph;

public class AdjList2
{
    public class CityNode
    {
        public string city;
        public bool visited;

        public CityNode(string name)
        {
            city = name;
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

        public override string ToString()
        {
            return city;
        }
    }
    private List<LinkedList<CityNode>> cities;

    public AdjList2()
    {
        cities = new List<LinkedList<CityNode>>();
    }
    
    public void addEdge(string cityA, string cityB)
    {
        CityNode a = createOrGetNode(cityA);
        CityNode b = createOrGetNode(cityB);
    }
    
    private CityNode createOrGetNode(string city)
    {
        CityNode searchTerm = new CityNode(city);
        foreach (var list in cities)
        {
            foreach (var cityNode in list)
            {
                if (cityNode.Equals(searchTerm))
                    return cityNode;
            }
        }
        return searchTerm;
    }
}
namespace HP35.Current.Djikstra;

public class CityNode
{
    public List<RailRoadConnection> adjacencyList;
    public readonly string city;
    public readonly int hashCode;
    public bool visited;
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

    public CityNode(string city, int index)
    {
        adjacencyList = new List<RailRoadConnection>();
        this.city = city;
        this.hashCode = index;
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
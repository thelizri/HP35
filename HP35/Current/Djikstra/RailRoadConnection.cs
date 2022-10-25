namespace HP35.Current.Djikstra;

public class RailRoadConnection
{
    public CityNode a;
    public CityNode b;
    public int weight;

    public RailRoadConnection(CityNode a, CityNode b, int weight)
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
using HP35.Current.Graph;

namespace HP35.Current.Djikstra;

public class Table
{
    public readonly CityNode vertex;
    public int minDistance;
    public CityNode prevVertex;

    public Table(CityNode vertex)
    {
        this.vertex = vertex;
        minDistance = Int32.MaxValue;
        prevVertex = null;
    }
    
    public Table(CityNode vertex, int distance)
    {
        this.vertex = vertex;
        minDistance = distance;
        prevVertex = null;
    }
}
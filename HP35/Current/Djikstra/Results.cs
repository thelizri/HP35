namespace HP35.Current.Djikstra;

public class Results
{
    private const int ARRAYSIZE = 541;
    private Table[][] results;

    public Results()
    {
        results = new Table[ARRAYSIZE][];
    }

    public void add(Table[] result, CityNode start)
    {
        results[start.hashCode] = result;
    }

    public Table[] get(CityNode start)
    {
        return results[start.hashCode];
    }
    
}
namespace HP35.Current.Graph;

public class Graph
{
    public Edge[] cities;
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
    }

    public class Node
    {
        public List<Edge> adjacencyList;
        public string city;

        public Node(string city)
        {
            adjacencyList = new List<Edge>();
            this.city = city;
        }

        public void addConnection(Node node, int weight)
        {
            Edge edge = new Edge(this, node, weight);
            adjacencyList.Add(edge);
        }
    }
}
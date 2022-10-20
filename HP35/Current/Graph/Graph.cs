namespace HP35.Current.Graph;

public class Graph
{
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

        public Node()
        {
            adjacencyList = new List<Edge>();
        }

        public void addConnection(Node node, int weight)
        {
            Edge edge = new Edge(this, node, weight);
            adjacencyList.Add(edge);
        }
    }
}
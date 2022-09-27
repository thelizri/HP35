namespace HP35;

public class Node
{
    public int data;
    public Node child;
    public Node parent;
        
    public Node(int data)
    {
        this.data = data;
    }

    public Node(int data, Node child, Node parent)
    {
        this.data = data;
        this.child = child;
        this.parent = parent;
    }
        
    public Node()
    {
    }
}
namespace HP35;

public class DoublyLinkedList
{
    private Node topNode;
    private Node bottomNode;

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

    public DoublyLinkedList()
    {
        topNode = null;
    }

    public void push(int data)
    {
        if (topNode == null)
        {
            topNode = new Node(data);
            bottomNode = topNode;
        }
        else
        {
            topNode.parent = new Node(data, topNode, null);
            topNode = topNode.parent;
        }
    }

    public int pop()
    {
        if (topNode == null) throw new StackOverflowException("Stack is empty");
        var result = topNode.data;
        topNode = topNode.child;
        if (topNode != null) topNode.parent = null; //We can't access node.next if node is null
        return result;
    }

    public void append(int item)
    {
        bottomNode.child = new Node(item, null, bottomNode);
        bottomNode = bottomNode.child;
    }

    public bool isEmpty()
    {
        if (topNode == null) return true;

        return false;
    }

    public void swap(Node a, Node b)
    {
        (a.data, b.data) = (b.data, a.data);
    }
    public void print_backwards()
    {
        if (isEmpty())
        {
            Console.WriteLine("\nIs empty");
            return;
        }

        var next = bottomNode;
        Console.Write("\n " + next.data);
        while (next.parent != null)
        {
            next = next.parent;
            Console.Write(" " + next.data);
        }
    }

    public void print_forwards()
    {
        if (isEmpty())
        {
            Console.WriteLine("\nIs empty");
            return;
        }

        Node next = topNode;
        Console.Write("\n " + next.data);
        while (next.child != null)
        {
            next = next.child;
            Console.Write(" " + next.data);
        }
    }
}
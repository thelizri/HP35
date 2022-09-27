namespace HP35;

public class DoublyLinkedList
{
    private Node topNode;
    private Node bottomNode;
    private int length;
    
    public void removeNode(Node node)
    {
        if (topNode==bottomNode)
        {
            topNode = bottomNode = null;
            length = 0;
        }
        else if (node == topNode)
        {
            topNode = topNode.child;
            topNode.parent = null;
        }
        else if (node == bottomNode)
        {
            bottomNode = bottomNode.parent;
            bottomNode.child = null;
        }
        else
        {
            
            Node child = node.child;
            Node parent = node.parent;
            parent.child = child;
            child.parent = parent;
        }
    }

    public DoublyLinkedList()
    {
        topNode = null;
        length = 0;
    }

    public void push(int data)
    {
        length++;
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
    
    public void push(Node node)
    {
        length++;
        if (topNode == null)
        {
            topNode = node;
            bottomNode = topNode;
        }
        else
        {
            topNode.parent = node;
            node.child = topNode;
            topNode = topNode.parent;
        }
    }

    public int pop()
    {
        if (topNode == null)
        {
            throw new StackOverflowException("Stack is empty");
        }
        else
        {
            length--;
            int result = topNode.data;
            topNode = topNode.child;
            if(topNode!=null) topNode.parent = null; //We can't access node.next if node is null
            return result;
        }
    }
    
    public void append(int item)
    {
        length++;
        bottomNode.child = new Node(item, null, bottomNode);
        bottomNode = bottomNode.child;
    }

    public bool isEmpty()
    {
        if (topNode == null)
        {
            return true;
        }

        return false;
    }

    public void print_backwards()
    {
        if (length == 0)
        {
            Console.WriteLine("\nIs empty");
            return;
        }
        Node next = bottomNode;
        Console.Write("\n "+next.data);
        while (next.parent != null)
        {
            next = next.parent;
            Console.Write(" "+next.data);
        }
    }

    public void print_forwards()
    {
        if (length == 0)
        {
            Console.WriteLine("\nIs empty");
            return;
        }
        Node next = topNode;
        Console.Write("\n "+next.data);
        while (next.child != null)
        {
            next = next.child;
            Console.Write(" "+next.data);
        }
    }

    public Node[] getNodeArray()
    {
        Node[] result = new Node[length];
        int index = 1;
        result[0] = topNode;
        Node next = topNode;
        while (next.child != null)
        {
            next = next.child;
            result[index] = next;
            index++;
        }
        return result;
    }
}
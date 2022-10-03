namespace HP35;

public class StackLinkedList
{
    private Node topNode;
    private Node bottomNode;
    
    public class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
        }

        public Node()
        {
        }
    }
    public StackLinkedList()
    {
        topNode = null;
        bottomNode = null;
    }

    public void push(int data)
    {
        if (topNode == null)
        {
            topNode = bottomNode = new Node(data);
        }
        else
        {
            bottomNode.next = new Node(data);
            bottomNode = bottomNode.next;
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
            int result = topNode.data;
            topNode = topNode.next;
            return result;
        }
    }

    public void print_forwards()
    {
        Node next = topNode;
        
        Console.Write("\n "+next.data);
        while (next.next != null)
        {
            next = next.next;
            Console.Write(" "+next.data);
        }
    }
    
    
}
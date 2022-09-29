namespace HP35;

public class StackLinkedList
{
    private Node top;
    
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
    public StackLinkedList()
    {
        top = null;
    }
    public void addData(int data, int index)
    {
        if(index==0) push(data);
        
        Node next = top;
        int position = 0;
        while (next.child != null)
        {
            next = next.child;
            position++;
            if (position == index-1)
            {
                addData(data, next);
                break;
            }
        }
    }
    private void addData(int data, Node node)
    {
        Node newnode = new Node(data);
        newnode.child = node.child;
        node.child = newnode;
    }

    public void removeNode(Node node)
    {
        if (node == top)
        {
            pop();
            return;
        }

        Node next = top;
        while (next.child != node)
        {
            next = next.child;
        }
        
        next.child = node.child;
    }


    public void push(Node node)
    {
        if (top == null)
            top = node;
        else
        {
            node.child = top;
            top = node;
        }
    }
    public void push(int data)
    {
        if (top == null)
        {
            top = new Node();
            top.data = data;
            top.child = null;
        }
        else
        {
            Node temp = new Node();
            temp.data = data;
            temp.child = top;
            top = temp;
        }
    }

    public int pop()
    {
        if (top == null)
        {
            throw new StackOverflowException("Stack is empty");
        }
        else
        {
            int result = top.data;
            top = top.child;
            return result;
        }
    }

    public void print_forwards()
    {
        Node next = top;
        
        Console.Write("\n "+next.data);
        while (next.child != null)
        {
            next = next.child;
            Console.Write(" "+next.data);
        }
    }
    
    public Node[] getNodeArray()
    {
        int length = 1;
        Node next = top;
        while (next.child != null)
        {
            next = next.child;
            length++;
        }

        Node[] result = new Node[length];
        next = top;
        int index = 1;
        result[0] = top;
        while (next.child != null)
        {
            next = next.child;
            result[index] = next;
            index++;
        }
        
        return result;
    }
    
}
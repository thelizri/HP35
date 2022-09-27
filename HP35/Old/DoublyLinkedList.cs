namespace HP35;

public class DoublyLinkedList<T>
{
    private Node topNode;
    private Node bottomNode;
    private int length;

    public class Node
    {
        public T data;
        public Node child;
        public Node parent;
        
        public Node(T data)
        {
            this.data = data;
        }

        public Node(T data, Node child, Node parent)
        {
            this.data = data;
            this.child = child;
            this.parent = parent;
        }
        
        public Node()
        {
        }
    }

    public T getData()
    {
        return topNode.data;
    }

    public void addData(T data, int index)
    {
        if(index==0) push(data);
        
        Node next = topNode;
        int position = 0;
        while (next.child != null)
        {
            next = next.child;
            position++;
            if (position == index)
            {
                addData(data, next);
                return;
            }
        }

        next.child = new Node(data,null,next);
    }

    private void addData(T data, Node node)
    {
        Node newnode = new Node(data);
        newnode.child = node;
        newnode.parent = node.parent;
        node.parent.child = newnode;
        node.parent = newnode;
    }

    public T removeData(int index)
    {
        if(index==0) return pop();

        length--;
        Node next = topNode;
        int position = 0;
        while (next.child != null)
        {
            next = next.child;
            position++;
            if (position == index)
            {
                return remove(next);
            }
        }

        return topNode.data;
    }

    public void removeNode(Node node)
    {
        length--;
        Node child = node.child;
        Node parent = node.parent;
        parent.child = child;
        child.parent = parent;
    }

    private T remove(Node node)
    {
        length--;
        if (node.child != null)
        {
            node.parent.child = node.child;
            node.child.parent = node.parent;
            return node.data;   
        }
        else
        {
            T result = node.data;
            node.parent.child = null;
            return result;
        }
    }

    public DoublyLinkedList()
    {
        topNode = null;
        length = 0;
    }

    public void push(T data)
    {
        length++;
        if (topNode == null)
        {
            topNode = new Node(data);
        }
        else
        {
            Node temp = new Node(data, topNode, null);
            topNode.parent = temp;
            topNode = temp;
        }
    }

    public T pop()
    {
        if (topNode == null)
        {
            throw new StackOverflowException("Stack is empty");
        }
        else
        {
            length--;
            T result = topNode.data;
            topNode = topNode.child;
            if(topNode!=null) topNode.parent = null; //We can't access node.next if node is null
            return result;
        }
    }
    
    public void append(T item)
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
        Node next = topNode;
        while (next.child != null)
        {
            next = next.child;
        }

        Console.Write("\n "+next.data);
        while (next.parent != null)
        {
            next = next.parent;
            Console.Write(" "+next.data);
        }
    }

    public void print_forwards()
    {
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
        while (topNode.child != null)
        {
            topNode = topNode.child;
            result[index] = topNode;
            index++;
        }

        return result;
    }
}
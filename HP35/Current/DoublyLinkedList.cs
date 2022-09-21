namespace HP35;

public class DoublyLinkedList<T>
{
    private Node<T> node;

    private class Node<T>
    {
        public T data;
        public Node<T> previous;
        public Node<T> next;
        
        public Node(T data)
        {
            this.data = data;
        }

        public Node(T data, Node<T> previous, Node<T> next)
        {
            this.data = data;
            this.previous = previous;
            this.next = next;
        }
        
        public Node()
        {
        }
    }

    public T getData()
    {
        return node.data;
    }

    public void addData(T data, int index)
    {
        if(index==0) push(data);
        
        Node<T> next = node;
        int position = 0;
        while (next.previous != null)
        {
            next = next.previous;
            position++;
            if (position == index)
            {
                addData(data, next);
                return;
            }
        }

        next.previous = new Node<T>(data,null,next);
    }

    private void addData(T data, Node<T> node)
    {
        Node<T> newnode = new Node<T>(data, node, node.next);
        node.next.previous = newnode;
        node.next = newnode;
    }

    public T removeData(int index)
    {
        if(index==0) return pop();
        
        Node<T> next = node;
        int position = 0;
        while (next.previous != null)
        {
            next = next.previous;
            position++;
            if (position == index)
            {
                return remove(next);
            }
        }

        return node.data;
    }

    private T remove(Node<T> node)
    {
        if (node.previous != null)
        {
            node.next.previous = node.previous;
            node.previous.next = node.next;
            return node.data;   
        }
        else
        {
            T result = node.data;
            node.next.previous = null;
            return result;
        }
    }

    public DoublyLinkedList()
    {
        node = null;
    }

    public void push(T data)
    {
        if (node == null)
        {
            node = new Node<T>(data);
        }
        else
        {
            Node<T> temp = new Node<T>(data, node, null);
            node.next = temp;
            node = temp;
        }
    }

    public T pop()
    {
        if (node == null)
        {
            throw new StackOverflowException("Stack is empty");
        }
        else
        {
            T result = node.data;
            node = node.previous;
            if(node!=null) node.next = null; //We can't access node.next if node is null
            return result;
        }
    }
    
    public void append(T item)
    {
        Node<T> next = node;
        while (next.previous != null)
        {
            next = next.previous;
        }
        next.previous = new Node<T>(item, null, next);
    }

    public bool isEmpty()
    {
        if (node == null)
        {
            return true;
        }

        return false;
    }

    public void print_backwards()
    {
        Node<T> next = node;
        while (next.previous != null)
        {
            next = next.previous;
        }

        Console.Write("\n "+next.data);
        while (next.next != null)
        {
            next = next.next;
            Console.Write(" "+next.data);
        }
    }

    public void print_forwards()
    {
        Node<T> next = node;
        
        Console.Write("\n "+next.data);
        while (next.previous != null)
        {
            next = next.previous;
            Console.Write(" "+next.data);
        }
    }
}
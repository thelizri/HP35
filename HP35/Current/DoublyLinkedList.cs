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
}
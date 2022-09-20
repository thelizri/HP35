namespace HP35;

public class StackLinkedList<T>
{
    private Node<T> top;

    private class Node<T>
    {
        public T data;
        public Node<T> link;
        public Node(T data)
        {
            this.data = data;
            this.link = null;
        }
        
        public Node()
        {
        }
    }

    public T getData()
    {
        return top.data;
    }

    public StackLinkedList()
    {
        top = null;
    }

    public void push(T data)
    {
        if (top == null)
        {
            top = new Node<T>();
            top.data = data;
            top.link = null;
        }
        else
        {
            Node<T> temp = new Node<T>();
            temp.data = data;
            temp.link = top;
            top = temp;
        }
    }

    public T pop()
    {
        if (top == null)
        {
            throw new StackOverflowException("Stack is empty");
        }
        else
        {
            T result = top.data;
            top = top.link;
            return result;
        }
    }
    
    public void append(T item)
    {
        Node<T> next = top;
        while (next.link != null)
        {
            next = next.link;
        }

        next.link = new Node<T>(item);
    }

    public bool isEmpty()
    {
        if (top == null)
        {
            return true;
        }

        return false;
    }
}
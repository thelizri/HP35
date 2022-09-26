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
    public void addData(T data, int index)
    {
        if(index==0) push(data);
        
        Node<T> next = top;
        int position = 0;
        while (next.link != null)
        {
            next = next.link;
            position++;
            if (position == index-1)
            {
                addData(data, next);
                break;
            }
        }
    }
    private void addData(T data, Node<T> node)
    {
        Node<T> newnode = new Node<T>(data);
        newnode.link = node.link;
        node.link = newnode;
    }
    
    public T removeData(int index)
    {
        if(index==0) return pop();
        
        Node<T> next = top;
        int position = 0;
        while (next.link != null)
        {
            next = next.link;
            position++;
            if (position == index-1)
            {
                return remove(next);
            }
        }

        return top.data;
    }

    private T remove(Node<T> node)
    {
        node.link = node.link.link;
        return node.link.data;
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
    
    public void print_forwards()
    {
        Node<T> next = top;
        
        Console.Write("\n "+next.data);
        while (next.link != null)
        {
            next = next.link;
            Console.Write(" "+next.data);
        }
    }
}
namespace HP35;

public class Queue<T>
{
    private Node backOfQueue;
    private Node frontOfQueue;
    public class Node
    {
        public Node back;
        public T data;

        public Node(T data)
        {
            this.data = data;
        }
        
        public Node(T data, Node forward)
        {
            this.data = data;
        }
    }

    public void add(T data)
    {
        if (isEmpty())
        {
            frontOfQueue = backOfQueue = new Node(data);
        }
        else
        {
            backOfQueue.back = new Node(data, backOfQueue);
            backOfQueue = backOfQueue.back;
        }
    }

    public T remove()
    {
        if (isEmpty())
        {
            throw new Exception("Queue is empty");
        }
        else
        {
            T result = frontOfQueue.data;
            frontOfQueue = frontOfQueue.back;
            return result;
        }
    }

    public bool isEmpty()
    {
        return (frontOfQueue is null);
    }

    public void print()
    {
        Node next = frontOfQueue;
        if (next is not null)
        {
            Console.Write($"{next.data}, ");
        }

        while (next.back is not null)
        {
            next = next.back;
            Console.Write($"{next.data}, ");
        }
        Console.WriteLine();
    }
    
}
namespace HP35;

public class Queue<T>
{
    private Node backOfQueue;
    private Node frontOfQueue;
    public class Node
    {
        public Node back;
        public Node forward;
        public T data;

        public Node(T data)
        {
            this.data = data;
        }
        
        public Node(T data, Node forward)
        {
            this.data = data;
            this.forward = forward;
        }
    }

    public void add(T data)
    {
        if (frontOfQueue is null)
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
        if (frontOfQueue is null)
        {
            return default(T);
        }
        else
        {
            T result = frontOfQueue.data;
            frontOfQueue = frontOfQueue.back;
            if(frontOfQueue is not null) frontOfQueue.forward = null;
                return result;
        }
    }

    public bool isEmpty()
    {
        return (frontOfQueue is null);
    }
    
    
}
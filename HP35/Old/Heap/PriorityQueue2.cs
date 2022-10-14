namespace HP35.Current;

public class PriorityQueue2
{
    //Add should be O(n)
    //Remove should be O(1)
    
    public class Node
    {
        public Node up;
        public Node down;
        public int data;

        public Node(Node up, Node down, int data)
        {
            this.up = up;
            this.down = down;
            this.data = data;
        }
    }

    private Node topNode;

    /// <summary>
    /// O(1) time complexity
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public int remove()
    {
        if (topNode is null)
        {
            throw new Exception("Heap is empty");
        }
        else
        {
            int data = topNode.data;
            topNode = topNode.down;
            return data;
        }
    }

    /// <summary>
    /// O(n) time complexity
    /// </summary>
    /// <param name="data"></param>
    public void add(int data)
    {
        if (topNode is null)
        {
            topNode = new Node(null, null, data);
        }
        else
        {
            Node current = topNode;
            if (data < current.data)
            {
                topNode = new Node(null, current, data);
                current.up = topNode;
                return;
            }

            while (current.down is not null)
            {
                current = current.down;
                if (data < current.data)
                {
                    Node node = new Node(current.up, current, data);
                    if (current.up is not null)
                    {
                        current.up.down = node;
                    }
                    current.up = node;
                    return;
                }
            }

            current.down = new Node(current, null, data);
        }
    }
}
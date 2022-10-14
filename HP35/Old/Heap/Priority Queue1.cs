namespace HP35.Current;

public class PriorityQueue1
{
    //Add should be O(1)
    //Remove should be O(n)

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
    /// <param name="data"></param>
    public void add(int data)
    {
        if (topNode is null)
        {
            topNode = new Node(null, null, data);
        }
        else
        {
            topNode = new Node(null, topNode, data);
            topNode.down.up = topNode;
        }
    }

    /// <summary>
    /// O(n) time complexity
    /// </summary>
    /// <returns>integer</returns>
    /// <exception cref="Exception"></exception>
    public int remove()
    {
        if (topNode is null)
        {
            throw new Exception("Heap is empty");
        }
        else
        {
            Node next = topNode;
            Node min = next;
            while (next.down is not null)
            {
                next = next.down;
                if (next.data < min.data)
                {
                    min = next;
                }
            }

            if (min == topNode)
            {
                topNode = topNode.down;
                return min.data;
            }
            if (min.up is not null)
            {
                min.up.down = min.down;
            }

            if (min.down is not null)
            {
                min.down.up = min.up;
            }

            return min.data;
        }
    }
}
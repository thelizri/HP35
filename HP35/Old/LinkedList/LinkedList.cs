namespace HP35;

public class SinglyLinkedList
{
    private Node topNode;
    private Node bottomNode;
    
    public class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
        }

        public Node()
        {
        }
    }
    public SinglyLinkedList()
    {
        topNode = null;
        bottomNode = null;
    }

    public void push(int data)
    {
        if (topNode == null)
        {
            topNode = bottomNode = new Node(data);
        }
        else
        {
            bottomNode.next = new Node(data);
            bottomNode = bottomNode.next;
        }
    }

    public int pop()
    {
        if (topNode == null)
        {
            throw new StackOverflowException("Stack is empty");
        }
        else
        {
            int result = topNode.data;
            topNode = topNode.next;
            return result;
        }
    }

    public void print_forwards()
    {
        Node next = topNode;
        
        Console.Write("\n "+next.data);
        while (next.next != null)
        {
            next = next.next;
            Console.Write(" "+next.data);
        }
    }
    
    public void sort()
    {
        quicksort(topNode, bottomNode);
    }

    private void quicksort(Node left, Node right)
    {
        if (right != null && left != right && left != right.next)
        {
            Node pivotLeft = partition(left, right);
            Node pivot = pivotLeft.next;
            quicksort(left, pivotLeft);
            quicksort(pivot.next, right);
        }
    }

    private Node partition(Node left, Node right)
    {
        int pivot = right.data;
        Node i = left;
        Node previous = left;
        for (Node j = left; j != right; j = j.next)
        {
            if (j.data < pivot)
            {
                swap(i, j);
                previous = i;
                i = i.next;
            }
        }
        swap(i, right);
        return previous;
    }
    
    public void swap(Node a, Node b)
    {
        (a.data, b.data) = (b.data, a.data);
    }
}
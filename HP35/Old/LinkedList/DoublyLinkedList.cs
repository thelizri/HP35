namespace HP35;

public class DoublyLinkedList
{
    private Node topNode;
    private Node bottomNode;

    public Node TopNode => topNode;

    public Node BottomNode => bottomNode;

    public class Node
    {
        public int data;
        public Node right;
        public Node left;

        public Node(int data)
        {
            this.data = data;
        }

        public Node(int data, Node right, Node left)
        {
            this.data = data;
            this.right = right;
            this.left = left;
        }

        public Node()
        {
        }
    }

    public DoublyLinkedList()
    {
        topNode = null;
    }

    public Node find_bottom_Node()
    {
        Node next = topNode;
        while (next.right != null)
        {
            next = next.right;
        }

        bottomNode = next;
        return next;
    }

    public void push(int data)
    {
        if (topNode == null)
        {
            topNode = new Node(data);
            bottomNode = topNode;
        }
        else
        {
            topNode.left = new Node(data, topNode, null);
            topNode = topNode.left;
        }
    }

    public int pop()
    {
        if (topNode == null) throw new StackOverflowException("Stack is empty");
        var result = topNode.data;
        topNode = topNode.right;
        if (topNode != null) topNode.left = null; //We can't access node.next if node is null
        return result;
    }

    public void append(int item)
    {
        bottomNode.right = new Node(item, null, bottomNode);
        bottomNode = bottomNode.right;
    }

    public bool isEmpty()
    {
        if (topNode == null) return true;

        return false;
    }

    public void swap(Node a, Node b)
    {
        (a.data, b.data) = (b.data, a.data);
    }
    public void print_backwards()
    {
        if (isEmpty())
        {
            Console.WriteLine("\nIs empty");
            return;
        }

        var next = bottomNode;
        Console.Write("\n " + next.data);
        while (next.left != null)
        {
            next = next.left;
            Console.Write(" " + next.data);
        }
    }

    public void print_forwards()
    {
        if (isEmpty())
        {
            Console.WriteLine("\nIs empty");
            return;
        }

        Node next = topNode;
        Console.Write("\n " + next.data);
        while (next.right != null)
        {
            next = next.right;
            Console.Write(" " + next.data);
        }
    }

    public void sort()
    {
        quicksort(topNode, bottomNode);
    }

    private void quicksort(Node left, Node right)
    {
        if (right != null && left != right && left != right.right)
        {
            Node pivot = partition(left, right);
            quicksort(left, pivot.left);
            quicksort(pivot.right, right);
        }
    }

    private Node partition(Node left, Node right)
    {
        int pivot = right.data;
        Node i = left;
        for (Node j = left; j != right; j = j.right)
        {
            if (j.data < pivot)
            {
                swap(i, j);
                i = i.right;
            }
        }
        swap(i, right);
        return i;
    }
}
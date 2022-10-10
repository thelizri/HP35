namespace HP35.Current;

public class TreeHeap
{
    public class Node
    {
        public Node left;
        public Node right;
        public int data;
        public int size;

        public Node(int data)
        {
            this.data = data;
        }
    }

    private Node root;

    public void add(int data)
    {
        if (root is null)
        {
            root = new Node(data);
        }
        else
        {
            add(root, data);
        }
    }

    private void add(Node node, int data)
    {
        node.size++;
        if (data < node.data)
        {
            (data, node.data) = (node.data, data);
        }
        if (node.left is null)
        {
            node.left = new Node(data);
        }
        else if (node.right is null)
        {
            node.right = new Node(data);
        }
        else
        {
            if (node.left.size < node.right.size)
            {
                add(node.left, data);
            }
            else
            {
                add(node.right, data);
            }
        }
    }

    public int remove()
    {
        if (root is null)
            throw new Exception("Heap is empty");
        return root.data;
    }
}
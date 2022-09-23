namespace HP35;

public class Tree<T>
{
    private Node root;

    private class Node
    {
        public T data;
        public int key;
        public Node parent;
        public Node left;
        public Node right;
        
        public Node(int key, T data)
        {
            this.key = key;
            this.data = data;
        }

        public void set(Node parent, Node left, Node right)
        {
            this.parent = parent;
            this.left = left;
            this.right = right;
        }
    }

    public Tree()
    {
        root = null;
    }

    public T lookup(int key)
    {
        if (root == null) throw new KeyNotFoundException("Tree is empty");
            
        Node node = root;
        while (true)
        {
            if (key < node.key)
            {
                if (node.left == null) throw new KeyNotFoundException("Key does not exist!");
                node = node.left;
            }
            else if (key > node.key)
            {
                if (node.right == null) throw new KeyNotFoundException("Key does not exist!");
                node = node.right;
            }
            else
            {
                return node.data;
            }
        }
    }

    public void add(int key, T value)
    {
        if (root == null)
        {
            root = new Node(key, value);
        }
        
        Node node = root;
        while (true)
        {
            if (key < node.key)
            {
                if (node.left == null)
                {
                    node.left = new Node(key, value);
                    node.left.parent = node;
                    return;
                }
                node = node.left;
            }
            else if (key > node.key)
            {
                if (node.right == null)
                {
                    node.right = new Node(key, value);
                    node.right.parent = node;
                    return;
                }
                node = node.right;
            }
            else
            {
                node.data = value;
                return;
            }
        }
    }
    
}
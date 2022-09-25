using System.Collections;

namespace HP35;

public partial class Tree
{
    private Node root;
    private Node current_node;
    private Stack<Node> stack;

    private class Node
    {
        public int data;
        public int key;
        public bool accessed;
        public Node parent;
        public Node left;
        public Node right;
        
        public Node(int key, int data)
        {
            this.key = key;
            this.data = data;
            this.accessed = false;
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
        stack = new Stack<Node>();
    }

    public int lookup(int key)
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
    
    private IEnumerable<int> InOrderTraversal()
    {
        if (root == null)
            throw new Exception("Tree is empty");
        return InOrderTraversal(root);
    }

    private IEnumerable<int> InOrderTraversal(Node node)
    {
        //if (node.left != null)
        {
            foreach (var x in InOrderTraversal(node.left))
            {
                yield return x;
            }
        }
        
        yield return node.data;

        //if (node.right != null)
        {
            foreach (var x in InOrderTraversal(node.right))
            {
                yield return x;
            }
        }
    }

    public void add(int key, int value)
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

public partial class Tree : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        return InOrderTraversal().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
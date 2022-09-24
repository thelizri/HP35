using System.Collections;

namespace HP35;

public class Tree : IEnumerable<int>, IEnumerator<int>
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

    public void in_order_traversal()
    {
        if (root == null)
            return;
        in_order_traversal(root);
    }

    private void in_order_traversal(Node node)
    {
        if(node.left!=null)
            in_order_traversal(node.left);
        Console.Write($"{node.data} ");
        stack.Push(node);
        if(node.right!=null)
            in_order_traversal(node.right);
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
    
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <returns></returns>
    
    public IEnumerator<int> GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool MoveNext()
    {
        if (stack.TryPop(out current_node)) return true;

        return false;
    }

    public void Reset()
    {
        //Do nothing
    }

    public int Current
    {
        get { return current_node.data; }
    }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        //
    }
    
}
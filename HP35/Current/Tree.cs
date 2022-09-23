using System.Collections;

namespace HP35;

public class Tree : IEnumerator
{
    private Node root;
    private Node current_node;

    private class Node
    {
        public int data;
        public int key;
        public Node parent;
        public Node left;
        public Node right;
        
        public Node(int key, int data)
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

    private void init_left_node()
    {
        if (root == null) return;
        
        Node node = root;
        while (node.left != null)
        {
            node = node.left;
        }
        current_node = node;
    }

    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public object Current
    {
        get { return current_node.data; }
    }
}
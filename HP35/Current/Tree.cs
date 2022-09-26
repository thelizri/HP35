using System.Collections;

namespace HP35;

public partial class Tree
{
    private Node root;

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
        public Node(int key, int data, Node parent)
        {
            this.key = key;
            this.data = data;
            this.parent = parent;
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

    public bool print_tree_inorder()
    {
        if (root == null)
            return false;
        inorder_traversal(root);
        return true;
    }

    private void inorder_traversal(Node node)
    {
        if(node.left!=null)
            inorder_traversal(node.left);
        Console.Write($"{node.data} ");
        if(node.right!=null)
            inorder_traversal(node.right);
    }
    
    private IEnumerable<int> InOrderTraversal()
    {
        if (root == null)
            throw new Exception("Tree is empty");
        return InOrderTraversal(root);
    }

    private IEnumerable<int> InOrderTraversal(Node node)
    {
        if (node.left != null)
        {
            foreach (var x in InOrderTraversal(node.left))
            {
                yield return x;
            }
        }
        
        yield return node.data;

        if (node.right != null)
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
                    node.left = new Node(key, value, node);
                    return;
                }
                node = node.left;
            }
            else if (key > node.key)
            {
                if (node.right == null)
                {
                    node.right = new Node(key, value, node);
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
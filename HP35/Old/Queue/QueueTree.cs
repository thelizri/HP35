using System.Collections;

namespace HP35;

public partial class QueueTree
{
    private Node root;
    private DynamicQueue<Node> queue;
    private DynamicQueue<Node> iterator;

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

    public QueueTree()
    {
        root = null;
        queue = new DynamicQueue<Node>();
        iterator = new DynamicQueue<Node>();
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

    public bool printInOrder()
    {
        if (root == null)
            return false;
        InOrderTraversalPrint(root);
        return true;
    }

    public bool printLevelOrder()
    {
        if (root == null)
            return false;
        LevelOrderTraversalPrint(root);
        Console.WriteLine();
        return true;
    }

    private void LevelOrderTraversalPrint(Node node)
    {
        Console.Write($"{node.data}, ");
        if (node.left is not null)
        {
            queue.add(node.left);
        }
        if (node.right is not null)
        {
            queue.add(node.right);
        }

        if (queue.isEmpty()) return;
        LevelOrderTraversalPrint(queue.remove());
    }

    private void InOrderTraversalPrint(Node node)
    {
        if(node.left!=null)
            InOrderTraversalPrint(node.left);
        Console.Write($"{node.data} ");
        if(node.right!=null)
            InOrderTraversalPrint(node.right);
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

public partial class QueueTree : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        if (root is not null)
        {
            iterator.add(root);
        }
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void addChildNodesToQueue(Node node)
    {
        if (node is null)
            return;
        if (node.left is not null)
        {
            iterator.add(node.left);
        }
        if (node.right is not null)
        {
            iterator.add(node.right);
        }
    }
}

public partial class QueueTree : IEnumerator<int>
{

    public bool MoveNext()
    {
        if (!iterator.isEmpty())
        {
            Node node = iterator.remove();
            addChildNodesToQueue(node);
            Current = node.data;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public int Current { get; private set; }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        //Do nothing
    }
}
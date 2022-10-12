using System.Collections;

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
            this.size = 1;
        }
    }

    private Node root;
    private Queue queue;

    public TreeHeap()
    {
        queue = new Queue();
    }

    public void increment(int increment)
    {
        if (root is null)
            return;
        
        root.data += increment;
        if (root.left is not null)
        {
            if (root.left.data < root.data)
            {
                (root.data, root.left.data) = (root.left.data, root.data);
                this.increment(root.left);
            }
        }
        if (root.right is not null)
        {
            if (root.right.data < root.data)
            {
                (root.data, root.right.data) = (root.right.data, root.data);
                this.increment(root.right);
            }
        }
    }

    private void increment(Node node)
    {
        if (node.left is not null)
        {
            if (node.left.data < node.data)
            {
                (node.data, node.left.data) = (node.left.data, node.data);
                increment(node.left);
            }
        }
        if (node.right is not null)
        {
            if (node.right.data < node.data)
            {
                (node.data, node.right.data) = (node.right.data, node.data);
                increment(node.right);
            }
        }
    }

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
            if (node.left.size <= node.right.size)
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
        if (root.size == 1)
        {
            int result = root.data;
            root = null;
            return result;
        }
        else
        {
            int result = root.data;
            remove(root);
            return result;
        }
    }

    private void remove(Node node)
    {
        node.size--;
        if (node.left is null)
        {
            //Promote right branch
            promote(node, node.right);
            if (isLeaf(node.right))
            {
                node.right = null;
                return;
            }
            remove(node.right);
        }
        else if (node.right is null)
        {
            //Promote left branch
            promote(node, node.left);
            if (isLeaf(node.left))
            {
                node.left = null;
                return;
            }
            remove(node.left);
        }
        else if (node.left.data <= node.right.data)
        {
            //Promote left branch
            promote(node, node.left);
            if (isLeaf(node.left))
            {
                node.left = null;
                return;
            }
            remove(node.left);
        }
        else if (node.right.data < node.left.data)
        {
            //Promote right branch
            promote(node, node.right);
            if (isLeaf(node.right))
            {
                node.right = null;
                return;
            }
            remove(node.right);
        }
    }

    private void promote(Node node, Node promote)
    {
        node.data = promote.data;
    }

    private bool isLeaf(Node node)
    {
        if (node.left is null && node.right is null)
        {
            return true;
        }

        return false;
    }

    public void print()
    {
        if (root is null)
        {
            Console.WriteLine("Empty");
            return;
        }
        print(root);
        Console.WriteLine();
    }

    private void print(Node node)
    {
        Console.Write($"{node.data}, ");

        if (node.left is not null) queue.Enqueue(node.left);
        if (node.right is not null) queue.Enqueue(node.right);

        if (queue.Count > 0) print((Node)queue.Dequeue());
    }
    
}
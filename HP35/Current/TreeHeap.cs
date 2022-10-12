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

    public int increment(int increment)
    {
        if (root is null)
            return 0;
        
        root.data += increment;
        return this.increment(root);
    }

    private int increment(Node node)
    {
        if (isLeaf(node)) return 0;
        if (node.right is null)
        {
            if (node.left.data < node.data)
            {
                (node.data, node.left.data) = (node.left.data, node.data);
                return 1+increment(node.left);
            }
        }
        else if (node.left is null)
        {
            if (node.right.data < node.data)
            {
                (node.data, node.right.data) = (node.right.data, node.data);
                return 1+increment(node.right);
            }
        }
        else
        {
            if (node.left.data <= node.right.data)
            {
                if (node.left.data < node.data)
                {
                    (node.data, node.left.data) = (node.left.data, node.data);
                    return 1+increment(node.left);
                }
            }
            else
            {
                if (node.right.data < node.data)
                {
                    (node.data, node.right.data) = (node.right.data, node.data);
                    return 1+increment(node.right);
                }
            }
        }

        return 0;
    }

    public int add(int data)
    {
        if (root is null)
        {
            root = new Node(data);
            return 0;
        }
        else
            return add(root, data);
    }

    private int add(Node node, int data)
    {
        node.size++;
        if (data < node.data) (data, node.data) = (node.data, data);
        if (node.left is null)
        {
            node.left = new Node(data);
            return 0;
        }
        else if (node.right is null)
        {
            node.right = new Node(data);
            return 0;
        }
        else
        {
            if (node.left.size <= node.right.size)
                return 1+add(node.left, data);
            else
                return 1+add(node.right, data);
        }
    }

    public int remove()
    {
        if (root is null)
            throw new Exception("Heap is empty");
        if (root.size == 1)
        {
            var result = root.data;
            root = null;
            return result;
        }
        else
        {
            var result = root.data;
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
            swapValues(node, node.right);
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
            swapValues(node, node.left);
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
            swapValues(node, node.left);
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
            swapValues(node, node.right);
            if (isLeaf(node.right))
            {
                node.right = null;
                return;
            }

            remove(node.right);
        }
    }

    private void swapValues(Node node, Node promote)
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
using System.Text;

namespace HP35;

public static class ArrayTools
{
    public static int[] create_sorted_array(int size)
    {
        Random random = new Random();
        int[] array = new int[size];
        int next = 0;
        for (int i = 0; i < array.Length; i++)
        {
            next += random.Next(5) + 1;
            array[i] = next;
        }

        return array;
    }

    public static int[] create_unsorted_array(int size)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(10*size);
        }

        return array;
    }

    public static int[] random_sequence(int size, int max)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(max);
        }

        return array;
    }

    public static DoublyLinkedList list(int size)
    {
        DoublyLinkedList list = new DoublyLinkedList();
        for (int i = 0; i < size; i++)
        {
            list.push(i);
        }

        return list;
    }
    
    public static SinglyLinkedList slist(int size)
    {
        SinglyLinkedList list = new SinglyLinkedList();
        for (int i = 0; i < size; i++)
        {
            list.push(i);
        }
        return list;
    }

    public static void print_array<T>(T[] array)
    {
        StringBuilder stringBuilder = new StringBuilder("["+array[0].ToString());
        
        for (int i = 1; i < array.Length; i++)
        {
            stringBuilder.Append(", "+array[i].ToString());
        }

        stringBuilder.Append("]");
        Console.WriteLine(stringBuilder.ToString());
    }

    public static int[] append_array(int[] a, int[] b)
    {
        int size = a.Length + b.Length;
        int[] result = new int[size];
        int index = 0;
        for (int i = 0; i < a.Length; i++)
        {
            result[index] = a[i];
            index++;
        }
        for (int i = 0; i < b.Length; i++)
        {
            result[index] = b[i];
            index++;
        }

        return result;
    }
    
    public static Tree create_balanced_tree(int size, int[] array)
    {
        Tree result = new Tree();
        merge_tree(0, size - 1, result, array);
        return result;
    }
    
    public static Tree create_balanced_tree(int size, out int[] array)
    {
        array = create_sorted_array(size);
        Tree result = new Tree();
        merge_tree(0, size - 1, result, array);
        return result;
    }

    public static void merge_tree(int left, int right, Tree tree, int[] array)
    {
        if (left > right) return;
        
        int middle = (left + right) / 2;
        int value = array[middle];
        tree.add(value, value);
        merge_tree(left, middle-1, tree, array);
        merge_tree(middle+1, right, tree, array);
    }

    public static Tree create_random_tree(int size, out int[] array)
    {
        Random rand = new Random();
        Tree result = new Tree();
        array = new int[size];
        for (int i = 0; i < size; i++)
        {
            int x = rand.Next();
            result.add(x, x);
            array[i] = x;
        }

        return result;
    }
}
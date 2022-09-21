using System.Text;

namespace HP35;

public class ArrayTools
{
    public int[] create_sorted_array(int size)
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

    public int[] create_unsorted_array(int size)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(10*size);
        }

        return array;
    }

    public void print_array<T>(T[] array)
    {
        StringBuilder stringBuilder = new StringBuilder("["+array[0].ToString());
        
        for (int i = 1; i < array.Length; i++)
        {
            stringBuilder.Append(", "+array[i].ToString());
        }

        stringBuilder.Append("]");
        Console.WriteLine(stringBuilder.ToString());
    }

    public int[] append_array(int[] a, int[] b)
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
}
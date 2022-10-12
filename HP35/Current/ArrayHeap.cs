namespace HP35.Current;

public class ArrayHeap
{
    /*Left branch: n*2 + 1
     * Right branch: n*2 + 2
     * k=-1 at start
     */
    private int[] array;
    private int size;
    private int k;

    public ArrayHeap()
    {
        k = -1;
        size = 10;
        array = new int[size];
    }
    
    private int leftBranch(int index)
    {
        return index * 2 + 1;
    }

    private int rightBranch(int index)
    {
        return index * 2 + 2;
    }

    private int parentBranch(int index)
    {
        if (index == 0)
            return 0;
        if (index % 2 == 1)
        {
            index--;
            return index / 2;
        }
        else
        {
            index -= 2;
            return index / 2;
        }
    }

    public void add(int data)
    {
        if (k >= size - 1) return;
        k++;
        array[k] = data;
        bubble(k);
    }

    private void bubble(int position)
    {
        if (position <= 0) return;
        var newElement = array[position];
        var parentIndex = parentBranch(position);
        var parentElement = array[parentIndex];
        if (newElement < parentElement)
        {
            (array[position], array[parentIndex]) = (array[parentIndex], array[position]);
            bubble(parentIndex);
        }
    }

    public int remove()
    {
        if (k < 0) throw new Exception("Empty heap");
        int result = array[0];
        array[0] = array[k];
        array[k] = 0;
        k--;
        sink(0);
        return result;
    }

    private void sink(int position)
    {
        if (position >= k)
        {
            return;
        }
        int leftP = leftBranch(position);
        int rightP = leftP + 1;


        if (rightP<=k)
        {
            if (array[leftP] < array[rightP])
            {
                if (array[leftP] < array[position])
                {
                    (array[leftP], array[position]) = (array[position], array[leftP]);
                    sink(leftP);
                }
            }
            else
            {
                if (array[rightP] < array[position])
                {
                    (array[rightP], array[position]) = (array[position], array[rightP]);
                    sink(rightP);
                }
            }
        }
        else if (leftP <= k)
        {
            if (array[leftP] < array[position])
            {
                (array[leftP], array[position]) = (array[position], array[leftP]);
                sink(leftP);
            }
        }
    }

    public void print()
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]}, ");
        }
        Console.WriteLine();
    }
    
}
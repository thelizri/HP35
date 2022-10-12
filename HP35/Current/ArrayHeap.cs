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
        size = 16;
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
        if (k >= size - 1) doubleSize();
        k++;
        array[k] = data;
        bubble(k);
    }

    private void doubleSize()
    {
        size *= 2;
        int[] array = new int[size];
        for (int i = 0; i < this.array.Length; i++)
        {
            array[i] = this.array[i];
        }
        this.array = array;
    }

    private void bubble(int position)
    {
        if (position <= 0) return;
        var newElement = array[position];
        var parentIndex = parentBranch(position);
        var parentElement = array[parentIndex];
        if (newElement < parentElement)
        {
            (array[position], array[parentIndex]) = 
                (array[parentIndex], array[position]);
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
        if (position >= k) return;
        var leftP = leftBranch(position);
        var rightP = leftP + 1;

        if (rightP <= k) //Making sure we're not going outside of the current bounds
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
        else if (leftP <= k) //Making sure we're not going outside of the current bounds
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

    public void increment(int increment)
    {
        if (k < 0) throw new Exception("Empty heap");
        array[0] += increment;
        sink(0);
    }
    
}
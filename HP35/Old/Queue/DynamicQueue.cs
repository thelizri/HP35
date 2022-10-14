namespace HP35;

public class DynamicQueue<T>
{
    private int firstElement;
    private int lastElement;
    private T[] array;
    private int size;
    private const int MINSIZE = 10;
    private int count;
    
    public DynamicQueue()
    {
        this.firstElement = -1;
        this.lastElement = -1;
        size = 10;
        array = new T[size];
    }

    public bool isFull()
    {
        return lastElement>=(size-1);
    }

    public bool isEmpty()
    {
        return (count == 0);
    }
    
    public void add(T data)
    {
        if (isFull())
        {
            doubleSizeAndCopyAllElements();
        }
        
        lastElement++;
        array[lastElement] = data;
        count++;
    }
    
    public T remove()
    {
        if (isEmpty())
        {
            throw new Exception("Empty queue");
        }

        if (MINSIZE != 100 && count < (size / 3))
        {
            reduceSizeAndCopyAllElements();
        }
        
        firstElement++;
        T result = array[firstElement];
        array[firstElement] = default(T);
        count--;
        return result;
    }

    private void doubleSizeAndCopyAllElements()
    {
        size *= 2;
        T[] newarray = new T[size];
        int index = firstElement+1;
        for (int i = 0; i < count; i++)
        {
            newarray[i] = array[index++];
        }
        firstElement = -1;
        lastElement = firstElement + count;
        array = newarray;
    }

    private void reduceSizeAndCopyAllElements()
    {
        size /= 2;
        T[] newarray = new T[size];
        int index = firstElement+1;
        for (int i = 0; i < count; i++)
        {
            newarray[i] = array[index++];
        }

        firstElement = -1;
        lastElement = firstElement + count;
        array = newarray;
    }
    
    public void print()
    {
        if (!isEmpty())
        {
            int i = firstElement+1;
            for (int j = 0; j < count; j++)
            {
                Console.Write($"{array[i%size]}, ");
                i++;
            }
            Console.WriteLine();
        }
    }
}
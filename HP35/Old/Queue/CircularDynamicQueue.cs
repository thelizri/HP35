namespace HP35;

public class CircularDynamicQueue<T>
{
    private int firstElement;
    private int lastElement;
    private T[] array;
    private int size;
    private int count;
    private const int MINSIZE = 4;

    public CircularDynamicQueue()
    {
        this.firstElement = -1;
        this.lastElement = -1;
        this.size = MINSIZE;
        array = new T[size];
    }

    public bool isEmpty()
    {
        return (count==0);
    }

    public bool isFull()
    {
        return (count >= size);
    }
    
    public void add(T data)
    {
        if (isFull())
        {
            copyAllElementsToNewArray(true);
        }
        
        lastElement++;
        if (lastElement >= size)
        {
            lastElement = 0;
        }
        array[lastElement] = data;
        count++;
    }
    
    public T remove()
    {
        if (isEmpty())
        {
            throw new Exception("Empty queue");
        }
        
        firstElement++;
        if (firstElement >= size)
        {
            firstElement = 0;
        }

        T result = array[firstElement];
        array[firstElement] = default(T);
        count--;

        if (size > MINSIZE && count < (size / 4))
        {
            copyAllElementsToNewArray(false);
        }

        if (isEmpty())
        {
            firstElement = -1;
            lastElement = -1;
        }

        return result;
    }

    public void print()
    {
        if (!isEmpty())
        {
            int i = firstElement+1;
            for (int j = 0; j < count; j++)
            {
                Console.Write($"Value: {array[i%size]}, Index:{i%size}, ");
                i++;
            }
            Console.WriteLine();
        }
    }

    private void copyAllElementsToNewArray(bool increase)
    {
        if (increase)
        {
            size *= 2;
        }
        else
        {
            size /= 2;
        }
        
        T[] newqueue = new T[size];
        int index = 0;
        int amountOfElementsCopied = 0;
        for (int i = firstElement+1; i < array.Length; i++)
        {
            if (amountOfElementsCopied >= count) break;
            
            newqueue[index] = array[i];
            index++;
            amountOfElementsCopied++;
        }

        if (lastElement <= firstElement)
        {
            for (int i = 0; i < lastElement; i++)
            {
                if (amountOfElementsCopied >= count) break;
                newqueue[index] = array[i];
                index++;
                amountOfElementsCopied++;
            }
        }
        
        array = newqueue;
        firstElement = -1;
        lastElement = firstElement + count;
    }
}
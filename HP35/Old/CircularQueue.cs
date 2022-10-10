namespace HP35;

public class CircularQueue<T>
{
    private int firstElement;
    private int lastElement;
    private T[] array;
    private int size;
    private int count;

    public CircularQueue(int size)
    {
        this.firstElement = -1;
        this.lastElement = -1;
        this.size = size;
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
            throw new Exception("Queue is full");
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
        return result;
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
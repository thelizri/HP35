namespace HP35;

public class QueueArray<T>
{
    private int firstElement;
    private int lastElement;
    private T[] array;
    private int size;
    private bool wrap;
    private int wfirstElement;
    private int wlastElement;
 
    public QueueArray()
    {
        this.firstElement = -1;
        this.lastElement = -1;
        this.size = 100;
        array = new T[size];
    }

    public bool isEmpty()
    {
        if (wrap) return (wfirstElement == wlastElement);
        return (firstElement == lastElement);
    }

    public bool isFull()
    {
        int numberOfElements = lastElement + wlastElement - wfirstElement- firstElement;
        return numberOfElements >= size;
    }

    public void add(T data)
    {
        if (wrap)
        {
            wlastElement++;
            array[wlastElement] = data;
        }
        else if (lastElement >= (size - 1))
        {
            if (wrapAround())
            {
                wlastElement++;
                array[wlastElement] = data;
            }
        }
        else
        {
            lastElement++;
            array[lastElement] = data;
        }
    }

    private bool wrapAround()
    {
        if (isFull())
        {
            Console.WriteLine("Need to double size");
            return false;
        }
        else
        {
            wfirstElement = -1;
            wlastElement = -1;
            wrap = true;
            return true;
        }
    }

    public T remove()
    {
        T result;
        if (isEmpty())
        {
            throw new Exception("Queue is empty");
        }

        if (wrap)
        {
            if (wfirstElement == wlastElement)
            {
                wrap = false;
                firstElement++;
                result = array[firstElement];
                array[firstElement] = default(T);
                return result;
            }
            wfirstElement++;
            result = array[wfirstElement];
            array[wfirstElement] = default(T);
            
            return result;
        }
        else
        {
            firstElement++;
            result = array[firstElement];
            array[firstElement] = default(T);
            return result;
        }
    }
}
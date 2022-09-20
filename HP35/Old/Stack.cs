namespace HP35;

public class StaticStack<T>
{
    protected T[] array;
    protected readonly int MIN_SIZE;
    protected int size;
    protected int top;

    public StaticStack()
    {
        this.MIN_SIZE = 10;
        this.size = MIN_SIZE;
        this.top = -1;
        this.array = new T[size];
    }

    public void push(T item)
    {
        if (top < size - 1)
        {
            top++;
            array[top] = item;
        }
        else
        {
            Console.WriteLine("Stack Overflow");
        }
    }

    public T pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Cannot pop empty stack!");
            return default(T);
        }
        else
        {
            T item = array[top];
            array[top] = default(T);
            top--;
            return item;   
        }
    }
    
    public T peek()
    {
        if (top == -1)
        {
            Console.WriteLine("Cannot peek empty stack!");
            return default(T);
        }
        else
        {
            T item = array[top];
            return item;   
        }
    }

    public bool empty()
    {
        if (top == -1) return true;
        return false;
    }
}

public class DynamicStack<T> : StaticStack<T>
{
    public DynamicStack()
    {
    }

    public void push(T item)
    {
        if (this.top < size - 1)
        {
            top++;
            array[top] = item;
        }
        else
        {
            doubleSize();
            top++;
            array[top] = item;
        }
    }

    private void doubleSize()
    {
        size *= 2;
        T[] newArray = new T[size];
        
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }

        array = newArray;
    }
}
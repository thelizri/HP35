namespace HP35;

public class LinkedList<T>
{
    private T head;
    private LinkedList<T> tail;

    public LinkedList(T head, LinkedList<T> tail)
    {
        this.head = head;
        this.tail = tail;
    }
    
    public LinkedList(T head)
    {
        this.head = head;
        this.tail = null;
    }
    
    public LinkedList<T> getTail()
    {
        return tail;
    }

    public T getHead()
    {
        return head;
    }

    //Append item
    public void append(T item)
    {
        LinkedList<T> next = this;
        while (next.tail != null)
        {
            next = next.tail;
        }

        next.tail = new LinkedList<T>(item, null);
    }
    
    
    //Append list
    public void append(LinkedList<T> list)
    {
        LinkedList<T> next = this;
        while (next.tail != null)
        {
            next = next.tail;
        }

        next.tail = list;
    }
    
}
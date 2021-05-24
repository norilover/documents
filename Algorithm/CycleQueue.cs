using System;

/***
 * Cycle Queue implement
 */
public class CycleQueue
{
    private static void Main(string[] args)
    {
        // Test();

        Console.WriteLine("CQ class -------------------------------------------------------------------------");
        int capacity = 5;
        ICQ cq = new CQ(capacity);

        int i = capacity;

        Console.WriteLine("Enter element to cq!");
        while (--i >= 0)
        {
            Console.WriteLine(cq.enQueue(i * 10));
        }

        Console.WriteLine("Cycle Queue is full:  " + cq.isFull());

        Console.WriteLine(cq.getFront());
        Console.WriteLine(cq.getRear());

        Console.WriteLine("Remove element from cq!");
        while (!cq.isEmpty())
        {
            Console.WriteLine(cq.deQueue());
        }

        Console.WriteLine("Cycle Queue is empty:  " + cq.isEmpty());

        
        
        Console.WriteLine("CQSimple -------------------------------------------------------------------------");
        cq = new CQSimple(capacity);
        i = capacity;

        Console.WriteLine("Enter element to cq!");
        while (--i >= 0)
        {
            Console.WriteLine(cq.enQueue(i * 10));
        }

        Console.WriteLine("Cycle Queue is full:  " + cq.isFull());

        Console.WriteLine(cq.getFront());
        Console.WriteLine(cq.getRear());

        Console.WriteLine("Remove element from cq!");
        while (!cq.isEmpty())
        {
            Console.WriteLine(cq.deQueue());
        }

        Console.WriteLine("Cycle Queue is empty:  " + cq.isEmpty());
    }
}

    interface ICQ
{

    int deQueue();
    bool enQueue(int element);

    int getFront();
    int getRear();

    bool isEmpty();
    bool isFull();
}

/// <summary>
/// Cycle Queue
/// -1 stand for no element
/// usedSpace stand for the used space for array
/// </summary>
public class CQSimple : ICQ
{
    private int capacity;
    private int front, rear;
    
    private int usedSpace;
    private int[] array;
    
    public CQSimple(int capacity)
    {
        this.capacity = capacity;
        front = 0;
        rear = 0;
        usedSpace = 0;
        
        // Init array
        array = new int[this.capacity];
    }

    public int deQueue()
    {
        if (isEmpty())
            return -1;

        int removeIndex = front;
        front = (front + 1) % capacity;

        usedSpace--;

        return array[removeIndex];
    }

    public bool enQueue(int element)
    {
        if (isFull())
            return false;

        int insertIndex = rear;
        array[rear] = element;
        
        rear = (rear + 1) % capacity;

        usedSpace++;
        
        return true;
    }

    public int getFront()
    {
        return isEmpty() ? -1 : array[front];
    }

    public int getRear()
    {
        int rearIndex = ((rear - 1) + capacity) % capacity;
        return isEmpty() ? -1 : array[rearIndex];
    }

    public bool isEmpty()
    {
        // return rear == front;
        return usedSpace == 0;
    }

    public bool isFull()
    {
        // return (rear + 1) % capacity == front;
        return usedSpace == capacity;
    }
}

/// <summary>
/// Cycle Queue
/// -1 stand for no element
/// </summary>
public class CQ : ICQ
{
    private int capacity;
    private int front, rear;
    
    private int[] array;
    
    public CQ(int capacity)
    {
        this.capacity = capacity + 1;
        front = 0;
        rear = 0;
        
        // Init array
        array = new int[this.capacity];
    }

    public int deQueue()
    {
        if (isEmpty())
            return -1;

        int removeIndex = front;
        front = (front + 1) % capacity;

        return array[removeIndex];
    }

    public bool enQueue(int element)
    {
        if (isFull())
            return false;

        int insertIndex = rear;
        array[rear] = element;
        
        rear = (rear + 1) % capacity;
        
        return true;
    }

    public int getFront()
    {
        return isEmpty() ? -1 : array[front];
    }

    public int getRear()
    {
        int rearIndex = ((rear - 1) + capacity) % capacity;
        return isEmpty() ? -1 : array[rearIndex];
    }

    public bool isEmpty()
    {
        return rear == front;
    }

    public bool isFull()
    {
        return (rear + 1) % capacity == front;
    }
}
namespace Stack;

public class StackArray<T>
{
    private List<T> stack_generics;

    public StackArray()
    {
        stack_generics = new List<T>();
    }

    public int count()
    {
        return stack_generics.Count;
    }

    public T pop()
    {
        T item = stack_generics[stack_generics.Count - 1];
        stack_generics.RemoveAt(stack_generics.Count-1);
        return item;
    }

    public void push()
    {
        try
        {
            Console.WriteLine("Enter the value to be pushed");
            T element = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
            stack_generics.Add(element);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void printStack()
    {
        for (int i = 0; i < stack_generics.Count; i++)
        {
            Console.Write(stack_generics[i]);
            if (i!=stack_generics.Count-1)
                Console.Write((", "));
        }
        Console.WriteLine();
    }
}
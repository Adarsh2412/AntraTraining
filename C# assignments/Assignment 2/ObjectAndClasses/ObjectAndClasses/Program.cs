// See https://aka.ms/new-console-template for more information

public class Program
{
    static int[] GenerateNumbers()
    {
        Console.WriteLine("Enter the Array elements you want to reverse with a space between them");
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] arr = input;
        return arr;
    }

    static void printArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
            if (i != arr.Length - 1)
            {
                Console.Write(", ");
            }
        }
    }

    static void reverse(ref int[] arr)
    {
        for (int i = 0; i < arr.Length / 2; i++)
        {
            int swap = arr[i];
            arr[i] = arr[arr.Length - i - 1];
            arr[arr.Length - i - 1] = swap;
        }
    }
    
    public static void Main(String[] args)
    {
        int[] numbers = GenerateNumbers();
        Console.WriteLine("Array before reversing");
        printArray(numbers);
        reverse(ref numbers);
        printArray(numbers);
    }
}
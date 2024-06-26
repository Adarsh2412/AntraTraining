// See https://aka.ms/new-console-template for more information

void arrayCopy()
{
    int[] arr1 = new int[10];
    for (int i = 0; i < arr1.Length; i++)
    {
        arr1[i] = i*i;
    }
    Console.WriteLine("Orignal Array:");
    for (int i = 0; i < arr1.Length; i++)
    {
        Console.WriteLine(arr1[i]);
    }

    int[] arr2 = new int[arr1.Length];
    for (int i = 0; i < arr2.Length; i++)
    {
        arr2[i] = arr1[i];
    }
    Console.WriteLine("Copied Array:");
    for (int i = 0; i < arr2.Length; i++)
    {
        Console.WriteLine(arr2[i]);
    }
}

void list_of_elements()
{
    
    List<String> list_of_elements = new List<string>();
    while (true)
    {
        Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
        string input = Console.ReadLine();
        if (input.Contains("--"))
        {
            list_of_elements.Clear();
            break;
        }
        else if (input.Substring(0,1).Equals("+"))
        {
            list_of_elements.Add(input.Substring(2));
        }
        else if (input.Substring(0, 1).Equals("-"))
        {
            list_of_elements.Remove(input.Substring(2));
        }
        else
        {
            Console.WriteLine("Invalid Input");
        }
        Console.WriteLine("Current Elements are: ");
        for (int i = 0; i < list_of_elements.Count; i++)
        {
            Console.WriteLine(list_of_elements[i]);
        }
        
    }
}

static bool checkIfPrime(int num)
{
    if (num == 1)
    {
        return false;
    }
    for(int i=2;i<Math.Sqrt(num);i++)
    {
        if (num % i == 0)
            return false;
    }

    return true;
}

static int[] FindPrimeInRange(int startnum, int endnum)
{
    int[] list_of_primes = new int[endnum-startnum];
    int c = 0;
    for (int i = startnum; i <= endnum; i++)
    {
        if (checkIfPrime(i))
        {
            list_of_primes[c] = i;
            c++;
        }
    }
    return list_of_primes;
}

void array_rotation()
{
    var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
    var k = int.Parse(Console.ReadLine());

    int[] array = input;
    int n = array.Length;
    int[] sum = new int[n];

    for (int r = 1; r <= k; r++)
    {
        int[] rotated = new int[n];
        for (int i = 0; i < n; i++)
        {
            rotated[(i + r) % n] = array[i];
        }

        for (int i = 0; i < n; i++)
        {
            sum[i] += rotated[i];
        }
    }

    Console.WriteLine(string.Join(" ", sum));
}

void longest_sequence()
{
    var array = Console.ReadLine().Split().Select(int.Parse).ToArray();

    int maxLength = 1;
    int currentLength = 1;
    int number = array[0];
    int maxNumber = array[0];

    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] == array[i - 1])
        {
            currentLength++;
        }
        else
        {
            currentLength = 1;
        }

        if (currentLength > maxLength)
        {
            maxLength = currentLength;
            maxNumber = array[i];
        }
    }

    Console.WriteLine(string.Join(" ", Enumerable.Repeat(maxNumber, maxLength)));

}

void frequent_number()
{
    var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
    var grouped = array.GroupBy(x => x).OrderByDescending(g => g.Count()).ThenBy(g => Array.IndexOf(array, g.Key)).First();
    Console.WriteLine($"The number {grouped.Key} is the most frequent (occurs {grouped.Count()} times)");
}

arrayCopy();
list_of_elements();
int start, end;
Console.WriteLine("Enter start and end of range:");
start = int.Parse(Console.ReadLine());
end = int.Parse(Console.ReadLine());
int[] list_of_primes = FindPrimeInRange(start,end);
for (int i = 0; i < list_of_primes.Length; i++)
{
    if(list_of_primes[i]!=0)
        Console.WriteLine(list_of_primes[i]);
}

array_rotation();

longest_sequence();
frequent_number();


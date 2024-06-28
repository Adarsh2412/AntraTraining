public class Program
{
    static int Fibbonacci(int n,int a,int b,int i)
    {
        if (i != n)
        {
            int temp = b;
            b = a + b;
            a = temp;
            return Fibbonacci(n, a, b, i + 1);
        }
        else
        {
            return b;
        }
    }
    
    static void Main(String[] args)
    {
        int n;
        Console.WriteLine("Enter the nth number you want to see of the fib");
        n = int.Parse(Console.ReadLine());
        if (n == 1 || n == 2)
        {
            Console.WriteLine(1);
            return;
        }
        Console.WriteLine(Fibbonacci(n,0,1,1));
    }
}
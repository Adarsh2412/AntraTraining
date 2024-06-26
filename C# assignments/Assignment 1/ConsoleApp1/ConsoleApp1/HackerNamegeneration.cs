namespace ConsoleApp1;

public class HackerNameGeneration
{
    public void nameGeneration()
    {
        string color;
        string zodiac_sign;
        int favourite_number;
        Console.WriteLine("Please enter your favourite color:");
        color = Console.ReadLine();
        Console.WriteLine("Please enter your Zodiac sign:");
        zodiac_sign = Console.ReadLine();
        Console.WriteLine("Please enter your favourite number:");
        favourite_number = int.Parse(Console.ReadLine());
        
        Console.WriteLine($"Your generated hacker name is {color+zodiac_sign+favourite_number}");

    }
}
// See https://aka.ms/new-console-template for more information


void fizzbuzz(int num)
{
    for (int i = 1; i <= 100; i++)
    {
        if (i % 3 == 0 && i % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (i%3==0)
        {
            Console.WriteLine("Fizz");
        }
        else if (i%5==0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine(i);
        }
    }
}

void WriteLine(int i)
{
    Console.WriteLine(i);
}
void check_code()
{
    //The following gives an error because WriteLine is not defined. We can fix this code by crating a function/method called writeline
    //Another error is that the i is defined as a byte. The max size of a byte variable is 255. So i will overflow, which causes the lop to never end. That is because the value of i will reset to zero when it exceeds 255. We can create a warniing or create a exit condition when 255 is reached. 
    int max = 500;
    for (byte i = 0; i < max; i++)
    {
        WriteLine(i);
        if (i == 255)
        {
            Console.WriteLine("The value of i has overflowed. Breaking loop");
            break;
        }
    }
}

void guess(int guess)
{
    int correctNumber = new Random().Next(3) + 1;
    if (guess < 1 || guess > 3)
    {
        Console.WriteLine("Invalid Guess. The number should be between 1 and 3 (including 1,3)");
        return;
    }

    if (guess < correctNumber)
    {
        Console.WriteLine("You guessed low");
    }
    else if (guess > correctNumber)
    {
        Console.WriteLine("You guessed high");    
    }
    else
    {
        Console.WriteLine("You got the correct answer");
    }
        
}

void pattern(int num)
{
    int i, j, sp;
    for (i = 0; i < num; i++)
    {
        for (sp = 0; sp < num - i - 1; sp++)
        {
            Console.Write(" ");
        }
        for (j = 0; j < i + i + 1; j++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
}

void daysCalculator(int birth_day, int birth_month, int birth_year)
{
    DateTime birthday = new DateTime(birth_year, birth_month, birth_day);
    DateTime current_day = DateTime.Today;
    TimeSpan age = current_day - birthday;
    int days_old = age.Days;
    Console.WriteLine($"Number of days you have been alive are: {days_old}");
    int daysToNextAnniversary = 10000 - (days_old % 10000);
    Console.WriteLine($"next 10,000 day anniversary is: {daysToNextAnniversary}");

}

void greetings()
{
    // DateTime current = new DateTime(2024,5,25,23,25,30);
    DateTime current = DateTime.Now;
    if (current.Hour >= 6 && current.Hour <= 11)
    {
        Console.WriteLine("Good Morning");
    }

    if (current.Hour >= 12 && current.Hour <= 15)
    {
        Console.WriteLine("Good Afternoon");
    }

    if (current.Hour >= 16 && current.Hour <= 19)
    {
        Console.WriteLine("Good Evening");
    }

    if (current.Hour >= 20 && current.Hour <= 23 || current.Hour >= 0 && current.Hour <= 5)
    {
        Console.WriteLine("Good Night");
    }
}

void counter()
{
    for (int i = 1; i <= 4; i++)
    {
        for (int j = 0; j <= 24; j += i)
        {
            Console.Write(j);
            if (j!=24)
                Console.Write(", ");
        }
        Console.WriteLine();
    }
}
   
fizzbuzz(100);

check_code();

Console.WriteLine("Guess a number between 1 and 3");
guess(int.Parse(Console.ReadLine()));

pattern(5);
daysCalculator(24,12,1998);
greetings();

counter();
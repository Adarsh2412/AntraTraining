namespace ConsoleApp2;

public class CenturyConversion
{
    public void convert(int centuries)
    {
        int years = centuries * 100;
        int leapYears = years / 4 - years / 100 + years / 400;
        long days = (long)years * 365 + leapYears;
        long hours = days * 24;
        long minutes = hours * 60;
        long seconds = minutes * 60;
        long milliseconds = seconds * 1000;
        long microseconds = milliseconds * 1000;
        decimal nanoseconds = (decimal)microseconds * 1000;
        Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes" +
                          $"{seconds} seconds = {milliseconds} milliseconds {microseconds} microseconds = {nanoseconds} nanoseconds");
    }
    
}
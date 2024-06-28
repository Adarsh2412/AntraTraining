namespace ColorAndBalls;

public class Ball
{
    public double Size { get; set; }
    public Color Color { get; set; }
    public int ThrowCount { get; set; }

    public Ball(double size, Color color, int thrownCount)
    {
        Size = size;
        Color = color;
        ThrowCount = thrownCount;
    }
    
    public Ball(double size, Color color)
    {
        Size = size;
        Color = color;
        ThrowCount = 0;
    }

    public void pop()
    {
        Size = 0.0;
    }
    
    public void throw_ball()
    {
        if(Size!=0)
            ThrowCount++;
    }

    public void throw_print()
    {
        Console.WriteLine($"The ball of size {Size} and color {Color.greyscale():F2} has been thrown {ThrowCount} times.");
    }
    
    
}
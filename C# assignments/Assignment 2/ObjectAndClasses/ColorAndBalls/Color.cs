namespace ColorAndBalls;

public class Color
{
    public byte Red { get; set; }
    public byte Blue { get; set; }
    public byte Green { get; set; }
    public byte Alpha { get; set; }

    public Color(byte red,byte blue,byte green, byte alpha)
    {
        Red = red;
        Blue = blue;
        Green = green;
        Alpha = alpha;
    }

    public Color(byte red, byte blue, byte green)
    {
        Red = red;
        Blue = blue;
        Green = green;
        Alpha = 255;
    }

    public double greyscale()
    {
        return (Red + Green + Blue) / 3.0;
    }
}
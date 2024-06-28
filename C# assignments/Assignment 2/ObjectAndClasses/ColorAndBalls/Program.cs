// See https://aka.ms/new-console-template for more information

using ColorAndBalls;

public class Program
{
    static void Main(String[] args)
    {
        Ball b1 = new Ball(3.14, new Color(255, 10, 5), 0);
        Ball b2 = new Ball(10, new Color(78, 255, 40, 0), 12);
        Ball b3 = new Ball(1, new Color(100, 198, 255));
        
        b1.throw_print();
        b2.throw_print();
        b3.throw_print();
        
        b1.throw_ball();
        b2.pop();
        b3.throw_ball();
        b3.throw_ball();
        b2.throw_ball();
        
        b1.throw_print();
        b2.throw_print();
        b3.throw_print();
    }
}
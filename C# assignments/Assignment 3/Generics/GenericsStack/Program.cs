// See https://aka.ms/new-console-template for more information

using Stack;

StackArray<int> s1 = new StackArray<int>();

s1.push();
Console.WriteLine($"The count of stack is {s1.count()}");
s1.push();
s1.push();
Console.WriteLine($"{ s1.pop() } was popped from stack");

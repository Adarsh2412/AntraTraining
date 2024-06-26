// See https://aka.ms/new-console-template for more information

using ConsoleApp2;


UnderstandingTypes ut = new UnderstandingTypes();
ut.display();
CenturyConversion cc = new CenturyConversion();
Console.WriteLine("Please enter the number of centuries:");
cc.convert(int.Parse(Console.ReadLine()));


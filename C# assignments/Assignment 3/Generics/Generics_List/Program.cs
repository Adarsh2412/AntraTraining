// See https://aka.ms/new-console-template for more information

using Generics_List;

GenericsList<int> obj = new GenericsList<int>();

obj.add(12);
obj.add(1);
obj.add(2);
obj.add(3);
obj.add(4);
obj.add(5);
obj.add(6);
obj.add(7);

Console.WriteLine("Element removed "+obj.remove(3));
Console.WriteLine(obj.contains(12));
obj.insertAt(34,5);
obj.deleteAt(2);
Console.WriteLine(obj.find(2));
obj.clear();

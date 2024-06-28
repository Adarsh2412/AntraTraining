namespace Generics_List;

public class GenericsList <T>
{
    private List<T> _list;

    public GenericsList()
    {
        _list = new List<T>();
    }

    public void add(T element)
    {
        _list.Add(element);
    }

    public T remove(int index)
    {
        T element = _list[index];
        _list.RemoveAt(index);
        return element;
    }

    public bool contains(T element)
    {
        return _list.Contains(element);
    }

    public void clear()
    {
        _list.Clear();
    }

    public void insertAt(T element, int index)
    {
        _list.Insert(index,element);
    }

    public void deleteAt(int index)
    {
        _list.RemoveAt(index);
    }

    public T find(int index)
    {
        return _list[index];
    }
}
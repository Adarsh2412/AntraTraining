namespace Repository.Repositories.Interface;

public interface IRepository<T> where T:class
{
    void Add(T item);
    void remove(T item);
    void save();
    IEnumerable<T> getAll();
    T getById(int id);

}
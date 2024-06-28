using Repository.DataModel;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

public class GenericRepositoryCustomer<T>: IRepository<Customer>
{
    private List<Customer> _customers = new List<Customer>();
    public void Add(Customer item)
    {
        if (getById(item.id) != null)
            _customers.Add(item);
    }

    public void remove(Customer item)
    {   
        _customers.Remove(item);
    }

    public void save()
    {
        Console.WriteLine("These values have been saved");
        for (int i = 0; i < _customers.Count; i++)
        {
            Console.WriteLine($"Id: {_customers[i].id} Name: {_customers[i].name} Email: {_customers[i].email}");
        }
    }

    public IEnumerable<Customer> getAll()
    {
        return _customers;
    }

    public Customer getById(int id)
    {
        for (int i = 0; i<_customers.Count; i++)
        {
            if (_customers[i].id == id)
            {
                return _customers[i];
            }
        }
        return null;
    }
}
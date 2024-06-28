using Repository.DataModel;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

public class GenericRepositoryCustomer<T>: IRepository<Customer>
{
    public void Add(Customer item)
    {
        throw new NotImplementedException();
    }

    public void remove(Customer item)
    {
        throw new NotImplementedException();
    }

    public void save()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> getAll()
    {
        throw new NotImplementedException();
    }

    public Customer getById(int id)
    {
        throw new NotImplementedException();
    }
}
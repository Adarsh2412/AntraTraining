using Repository.DataModel;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

public class GenericRepositoryEmployee<T>: IRepository<Employee>
{
    private List<Employee> _employees = new List<Employee>();
    public void Add(Employee item)
    {
        if (getById(item.id) != null)
            _employees.Add(item);
    }

    public void remove(Employee item)
    {   
        _employees.Remove(item);
    }

    public void save()
    {
        Console.WriteLine("These values have been saved");
        for (int i = 0; i < _employees.Count; i++)
        {
            Console.WriteLine($"Id: {_employees[i].id} Name: {_employees[i].name} Salary: {_employees[i].salary}");
        }
    }

    public IEnumerable<Employee> getAll()
    {
        return _employees;
    }

    public Employee getById(int id)
    {
        for (int i = 0; i<_employees.Count; i++)
        {
            if (_employees[i].id == id)
            {
                return _employees[i];
            }
        }
        return null;
    }
}
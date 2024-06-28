using OOPPrinciples.Repository.Interfaces;

namespace OOPPrinciples.DataModel;

public abstract class Person: IPersonService
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal Salary { get; private set; }
    private List<string> Addresses { get; set; } = new List<string>();

    public Person(string name, DateTime dateOfBirth, decimal salary)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        Salary = salary >= 0 ? salary : throw new ArgumentOutOfRangeException(nameof(salary), "Salary cannot be negative");
    }

    public int CalculateAge()
    {
        var age = DateTime.Now.Year - DateOfBirth.Year;
        if (DateOfBirth.Date > DateTime.Now.AddYears(-age)) age--;
        return age;
    }

    public abstract decimal CalculateSalary();

    public void AddAddress(string address)
    {
        Addresses.Add(address);
    }

    public List<string> GetAddresses()
    {
        return Addresses;
    }
}
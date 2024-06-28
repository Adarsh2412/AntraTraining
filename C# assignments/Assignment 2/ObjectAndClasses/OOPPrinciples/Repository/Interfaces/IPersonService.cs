namespace OOPPrinciples.Repository.Interfaces;

public interface IPersonService
{
    public int CalculateAge();
    public decimal CalculateSalary();
    public List<string> GetAddresses();
}
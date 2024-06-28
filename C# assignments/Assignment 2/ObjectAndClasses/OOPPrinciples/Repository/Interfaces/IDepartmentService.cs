using OOPPrinciples.DataModel;

namespace OOPPrinciples.Repository.Interfaces;

public interface IDepartmentService
{
    public void AddCourse(Course course);
    public void SetBudget(decimal budget);
}
using OOPPrinciples.DataModel;

namespace OOPPrinciples.Repository.Interfaces;

public interface IInstructorService: IPersonService
{
    public void AddCourse(Course course);
    public void AssignAsHeadOfDepartment(Department department);
}
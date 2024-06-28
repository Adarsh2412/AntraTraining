using OOPPrinciples.DataModel;

namespace OOPPrinciples.Repository.Interfaces;

public interface IStudentService: IPersonService
{
    public void EnrollInCourse(Course course);
    public double CalculateGPA();
}
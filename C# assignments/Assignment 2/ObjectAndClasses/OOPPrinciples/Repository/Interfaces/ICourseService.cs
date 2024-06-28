using OOPPrinciples.DataModel;

namespace OOPPrinciples.Repository.Interfaces;

public interface ICourseService
{
    public void EnrollStudent(Student student);
    public void AssignInstructor(Instructor instructor);
}
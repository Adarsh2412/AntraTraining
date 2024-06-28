using OOPPrinciples.Repository.Interfaces;

namespace OOPPrinciples.DataModel;

public class Course: ICourseService
{
    public string Name { get; set; }
    private List<Student> EnrolledStudents { get; set; } = new List<Student>();
    public Instructor Instructor { get; private set; }

    public Course(string name)
    {
        Name = name;
    }

    public void EnrollStudent(Student student)
    {
        EnrolledStudents.Add(student);
    }

    public void AssignInstructor(Instructor instructor)
    {
        Instructor = instructor;
    }

    public List<Student> GetEnrolledStudents()
    {
        return EnrolledStudents;
    }
}
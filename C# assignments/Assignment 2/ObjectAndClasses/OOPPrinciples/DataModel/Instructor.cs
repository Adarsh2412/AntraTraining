using OOPPrinciples.Repository.Interfaces;

namespace OOPPrinciples.DataModel;

public class Instructor: Person, IInstructorService
{
    public Department Department { get; private set; }
    private List<Course> Courses { get; set; } = new List<Course>();
    public DateTime JoinDate { get; set; }
    public bool IsHeadOfDepartment { get; private set; }

    public Instructor(string name, DateTime dateOfBirth, decimal salary, DateTime joinDate)
        : base(name, dateOfBirth, salary)
    {
        JoinDate = joinDate;
    }

    public override decimal CalculateSalary()
    {
        int yearsOfExperience = DateTime.Now.Year - JoinDate.Year;
        return Salary + (yearsOfExperience * 1000); // Bonus based on years of experience
    }

    public void AddCourse(Course course)
    {
        Courses.Add(course);
        course.AssignInstructor(this);
    }

    public void AssignAsHeadOfDepartment(Department department)
    {
        Department = department;
        IsHeadOfDepartment = true;
    }
}
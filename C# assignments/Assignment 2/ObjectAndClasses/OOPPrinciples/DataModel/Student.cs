using OOPPrinciples.Repository.Interfaces;

namespace OOPPrinciples.DataModel;

public class Student : Person, IStudentService
{
    private List<Course> Courses { get; set; } = new List<Course>();
    private Dictionary<Course, char> Grades { get; set; } = new Dictionary<Course, char>();

    public Student(string name, DateTime dateOfBirth, decimal salary) 
        : base(name, dateOfBirth, salary) { }

    public override decimal CalculateSalary()
    {
        return Salary;
    }

    public void EnrollInCourse(Course course)
    {
        Courses.Add(course);
        course.EnrollStudent(this);
    }

    public void AssignGrade(Course course, char grade)
    {
        if (Courses.Contains(course))
        {
            Grades[course] = grade;
        }
    }

    public double CalculateGPA()
    {
        double totalPoints = 0;
        int totalCourses = Grades.Count;

        foreach (var grade in Grades.Values)
        {
            totalPoints += GradeToPoint(grade);
        }

        return totalCourses > 0 ? totalPoints / totalCourses : 0;
    }

    private double GradeToPoint(char grade)
    {
        return grade switch
        {
            'A' => 4.0,
            'B' => 3.0,
            'C' => 2.0,
            'D' => 1.0,
            'F' => 0.0,
            _ => 0.0,
        };
    }
}
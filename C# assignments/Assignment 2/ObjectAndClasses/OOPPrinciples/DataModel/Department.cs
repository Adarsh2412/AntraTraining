using OOPPrinciples.Repository.Interfaces;

namespace OOPPrinciples.DataModel;

public class Department : IDepartmentService
{
    public string Name { get; set; }
    public Instructor Head { get; private set; }
    public decimal Budget { get; private set; }
    private List<Course> Courses { get; set; } = new List<Course>();

    public Department(string name)
    {
        Name = name;
    }

    public void AddCourse(Course course)
    {
        Courses.Add(course);
    }

    public void SetHead(Instructor head)
    {
        Head = head;
    }
    

    public void SetBudget(decimal budget)
    {
        Budget = budget;
    }
}
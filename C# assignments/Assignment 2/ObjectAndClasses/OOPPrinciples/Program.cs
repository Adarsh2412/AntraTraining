using OOPPrinciples.DataModel;

public class Program
{
    public static void Main()
    {
        // Create Departments
        Department csDepartment = new Department("Computer Science");
        Department mathDepartment = new Department("Mathematics");

        // Create Courses
        Course oopCourse = new Course("Object-Oriented Programming");
        Course dsCourse = new Course("Data Structures");

        csDepartment.AddCourse(oopCourse);
        csDepartment.AddCourse(dsCourse);

        // Create Instructors
        Instructor johnDoe = new Instructor("John Doe", new DateTime(1980, 5, 23), 50000, new DateTime(2010, 9, 1));
        Instructor janeSmith = new Instructor("Jane Smith", new DateTime(1975, 4, 11), 60000, new DateTime(2005, 8, 15));

        johnDoe.AssignAsHeadOfDepartment(csDepartment);
        csDepartment.SetHead(johnDoe);

        johnDoe.AddCourse(oopCourse);
        janeSmith.AddCourse(dsCourse);

        // Create Students
        Student alice = new Student("Alice Johnson", new DateTime(2000, 6, 20), 0);
        Student bob = new Student("Bob Brown", new DateTime(1999, 12, 15), 0);

        // Enroll Students in Courses
        alice.EnrollInCourse(oopCourse);
        bob.EnrollInCourse(dsCourse);

        // Assign Grades
        alice.AssignGrade(oopCourse, 'A');
        bob.AssignGrade(dsCourse, 'B');

        // Calculate GPA
        Console.WriteLine($"{alice.Name}'s GPA: {alice.CalculateGPA()}");
        Console.WriteLine($"{bob.Name}'s GPA: {bob.CalculateGPA()}");

        // Calculate Salaries
        Console.WriteLine($"{johnDoe.Name}'s Salary: {johnDoe.CalculateSalary()}");
        Console.WriteLine($"{janeSmith.Name}'s Salary: {janeSmith.CalculateSalary()}");

        // List Addresses
        johnDoe.AddAddress("123 Main St");
        johnDoe.AddAddress("456 Elm St");

        Console.WriteLine($"{johnDoe.Name}'s Addresses: {string.Join(", ", johnDoe.GetAddresses())}");
    }
}
namespace CollegeManagement.Models;

public class Group
{
    private readonly List<Student> _students = new();

    public int Id { get; }
    public string Name { get; set; }
    public int Course { get; set; }
    public IReadOnlyList<Student> Students => _students.AsReadOnly();

    public Group(int id, string name, int course)
    {
        Id = id;
        Name = name;
        Course = course;
    }

    public bool AddStudent(Student student)
    {
        if (student is null || _students.Any(s => s.StudentId == student.StudentId)) return false;
        _students.Add(student);
        return true;
    }

    public bool RemoveStudent(int studentId)
    {
        var student = _students.FirstOrDefault(s => s.StudentId == studentId);
        return student is not null && _students.Remove(student);
    }
}

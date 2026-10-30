namespace CollegeManagement.Models;

public class Subject
{
    private string _name;
    private int _hours;
    private Teacher? _teacher;

    public string Name => _name;
    public int Hours => _hours;
    public Teacher? AssignedTeacher => _teacher;

    public Subject(string name, int hours)
    {
        _name = name;
        _hours = hours;
    }

    public bool AssignTeacher(Teacher? teacher)
    {
        if (teacher is null) return false;
        _teacher = teacher;
        return true;
    }
}

namespace CollegeManagement.Models;

public class GradeBook
{
    private readonly List<Grade> _grades = new();
    public IReadOnlyList<Grade> Grades => _grades.AsReadOnly();

    public bool AddGrade(Grade grade)
    {
        if (grade is null || grade.Value < 2 || grade.Value > 5) return false;
        _grades.Add(grade);
        return true;
    }

    public bool RemoveGrade(int index)
    {
        if (index < 0 || index >= _grades.Count) return false;
        _grades.RemoveAt(index);
        return true;
    }
}

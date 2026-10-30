using CollegeManagement.Models;

namespace CollegeManagement.Services;

public class StudentService
{
    public Student? FindById(IEnumerable<Student> students, int id) =>
        students.FirstOrDefault(s => s.StudentId == id);

    public bool AddStudent(ICollection<Student> students, Student student)
    {
        if (students.Any(s => s.StudentId == student.StudentId)) return false;
        students.Add(student);
        return true;
    }
}

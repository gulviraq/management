using CollegeManagement.Models;

namespace CollegeManagement.Services;

public class CollegeRepository
{
    public List<Student> Students { get; } = new();
    public List<Teacher> Teachers { get; } = new();
    public List<Group> Groups { get; } = new();
    public List<Subject> Subjects { get; } = new();
    public GradeBook GradeBook { get; } = new();
    public List<(int StudentId, DateTime Date, bool Present)> Attendance { get; } = new();

    public CollegeRepository()
    {
        var s1 = new Student("Амина", "Майлина", 17, "2ПО-325");
        var s2 = new Student("Данияр", "Сериков", 18, "2ПО-325");
        var s3 = new Student("Алина", "Касымова", 17, "1ПО-324");
        Students.AddRange(new[] { s1, s2, s3 });

        Teachers.AddRange(new[]
        {
            new Teacher(1, "Елена", "Иванова", "Программирование", 8),
            new Teacher(2, "Александр", "Петров", "Математика", 12)
        });

        var g1 = new Group(1, "2ПО-325", 2);
        g1.AddStudent(s1);
        g1.AddStudent(s2);
        var g2 = new Group(2, "1ПО-324", 1);
        g2.AddStudent(s3);
        Groups.AddRange(new[] { g1, g2 });

        var subject = new Subject("Программирование", 120);
        subject.AssignTeacher(Teachers[0]);
        Subjects.Add(subject);

        GradeBook.AddGrade(new Grade(s1.StudentId, s1.GetStudentInfo(), "Программирование", 5, DateTime.Today));
        GradeBook.AddGrade(new Grade(s2.StudentId, s2.GetStudentInfo(), "Математика", 4, DateTime.Today));
        Attendance.Add((s1.StudentId, DateTime.Today, true));
        Attendance.Add((s2.StudentId, DateTime.Today, false));
    }
}

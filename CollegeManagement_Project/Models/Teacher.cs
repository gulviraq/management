namespace CollegeManagement.Models;

public class Teacher : Person
{
    private string _subject;
    private int _experience;

    public int Id { get; }
    public string Name => FirstName;
    public string Surname => LastName;
    public string Subject
    {
        get => _subject;
        set => _subject = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Укажите предмет.") : value.Trim();
    }
    public int Experience => _experience;

    public Teacher(int id, string name, string surname, string subject, int experience, int age = 35)
        : base(name, surname, age)
    {
        Id = id;
        _subject = subject;
        _experience = experience;
    }

    public bool UpdateExperience(int years)
    {
        if (years < 0 || years > 60) return false;
        _experience = years;
        return true;
    }

    public string GetTeacherInfo()
    {
        DisplayBasicInfo();
        return $"{GetFullName()} — {Subject}, стаж {_experience} лет";
    }
}

namespace CollegeManagement.Models;

public class Student : Person
{
    private static int _nextId = 1;
    private int _age;
    private string _name;
    private string _surname;
    private string _group;

    public int StudentId { get; }
    public string Name
    {
        get => _name;
        set => _name = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Укажите имя.") : value.Trim();
    }
    public string Surname
    {
        get => _surname;
        set => _surname = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Укажите фамилию.") : value.Trim();
    }
    public int StudentAge => _age;
    public string Group
    {
        get => _group;
        set => _group = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Укажите группу.") : value.Trim();
    }

    public Student(string name, string surname, int age, string group)
        : base(name, surname, age)
    {
        _name = name;
        _surname = surname;
        _group = group;
        _age = age;
        ValidateStudentData();
        StudentId = _nextId++;
    }

    private void ValidateStudentData()
    {
        if (string.IsNullOrWhiteSpace(_name) || string.IsNullOrWhiteSpace(_surname) ||
            string.IsNullOrWhiteSpace(_group) || _age < 15 || _age > 70)
            throw new ArgumentException("Некорректные данные студента. Возраст должен быть от 15 до 70 лет.");
    }

    public bool SetAge(int age)
    {
        if (age < 15 || age > 70) return false;
        _age = age;
        Age = age;
        return true;
    }

    public string GetStudentInfo() => $"{StudentId}. {Name} {Surname}, {_age} лет, группа {Group}";
}

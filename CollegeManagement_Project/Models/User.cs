namespace CollegeManagement.Models;

public class User
{
    protected string LoginName { get; set; }
    private string Password { get; set; }

    public string Role { get; }

    public User(string login, string password, string role)
    {
        LoginName = login;
        Password = password;
        Role = role;
    }

    public bool CheckPassword(string password) => Password == password;
    public string PublicInfo() => $"{LoginName} ({Role})";
}

public sealed class Admin : User
{
    public Admin(string login, string password) : base(login, password, "Администратор") { }
}

public sealed class TeacherUser : User
{
    public TeacherUser(string login, string password) : base(login, password, "Преподаватель") { }
}

public sealed class StudentUser : User
{
    public StudentUser(string login, string password) : base(login, password, "Студент") { }
}

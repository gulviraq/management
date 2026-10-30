namespace CollegeManagement.Models;

public class UserAccount
{
    private readonly string _login;
    private readonly string _password;
    public bool IsAuthenticated { get; private set; }

    public UserAccount(string login, string password)
    {
        _login = login;
        _password = password;
    }

    public bool Login(string login, string password)
    {
        IsAuthenticated = login == _login && password == _password;
        return IsAuthenticated;
    }

    public void Logout() => IsAuthenticated = false;
    public string GetPublicInfo() => $"Пользователь: {_login}. Пароль скрыт.";
}

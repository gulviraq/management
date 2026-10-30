using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.Controllers;

public class AccountController : Controller
{
    private const string DemoLogin = "admin";
    private const string DemoPassword = "12345";

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string login, string password)
    {
        if (login == DemoLogin && password == DemoPassword)
        {
            HttpContext.Session.SetString("User", login);
            return RedirectToAction("Index", "Admin");
        }

        ViewBag.Error = "Неверный логин или пароль.";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}

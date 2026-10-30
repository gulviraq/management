using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("User") is null) return RedirectToAction("Login", "Account");
        return View();
    }
}

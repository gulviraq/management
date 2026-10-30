using Microsoft.AspNetCore.Mvc;
using CollegeManagement.Services;

namespace CollegeManagement.Controllers;

public class HomeController : Controller
{
    private readonly CollegeRepository _db;
    public HomeController(CollegeRepository db) => _db = db;

    public IActionResult Index()
    {
        ViewBag.Students = _db.Students.Count;
        ViewBag.Teachers = _db.Teachers.Count;
        ViewBag.Groups = _db.Groups.Count;
        ViewBag.Grades = _db.GradeBook.Grades.Count;
        return View();
    }

    public IActionResult Error() => View();
}

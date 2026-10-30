using Microsoft.AspNetCore.Mvc;
using CollegeManagement.Services;

namespace CollegeManagement.Controllers;

public class TeacherController : Controller
{
    private readonly CollegeRepository _db;
    public TeacherController(CollegeRepository db) => _db = db;
    public IActionResult Index() => View(_db.Teachers);
}

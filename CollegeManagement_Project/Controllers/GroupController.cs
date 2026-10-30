using Microsoft.AspNetCore.Mvc;
using CollegeManagement.Services;

namespace CollegeManagement.Controllers;

public class GroupController : Controller
{
    private readonly CollegeRepository _db;
    public GroupController(CollegeRepository db) => _db = db;
    public IActionResult Index() => View(_db.Groups);
}

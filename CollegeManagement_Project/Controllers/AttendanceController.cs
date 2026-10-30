using Microsoft.AspNetCore.Mvc;
using CollegeManagement.Services;

namespace CollegeManagement.Controllers;

public class AttendanceController : Controller
{
    private readonly CollegeRepository _db;
    public AttendanceController(CollegeRepository db) => _db = db;

    public IActionResult Index()
    {
        ViewBag.Students = _db.Students;
        ViewBag.Stats = $"Всего отметок: {_db.Attendance.Count}; присутствовали: {_db.Attendance.Count(x => x.Present)}; отсутствовали: {_db.Attendance.Count(x => !x.Present)}.";
        return View(_db.Attendance);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(int studentId, bool present)
    {
        _db.Attendance.Add((studentId, DateTime.Today, present));
        return RedirectToAction(nameof(Index));
    }
}

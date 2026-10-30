using Microsoft.AspNetCore.Mvc;
using CollegeManagement.Models;
using CollegeManagement.Services;

namespace CollegeManagement.Controllers;

public class GradeController : Controller
{
    private readonly CollegeRepository _db;
    public GradeController(CollegeRepository db) => _db = db;
    public IActionResult Index() => View(_db.GradeBook.Grades);

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(int studentId, string subject, int value)
    {
        var student = _db.Students.FirstOrDefault(s => s.StudentId == studentId);
        if (student is not null)
            _db.GradeBook.AddGrade(new Grade(studentId, $"{student.Name} {student.Surname}", subject, value, DateTime.Today));
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int index)
    {
        _db.GradeBook.RemoveGrade(index);
        return RedirectToAction(nameof(Index));
    }
}

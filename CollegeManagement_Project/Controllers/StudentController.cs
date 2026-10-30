using Microsoft.AspNetCore.Mvc;
using CollegeManagement.Models;
using CollegeManagement.Services;

namespace CollegeManagement.Controllers;

public class StudentController : Controller
{
    private readonly CollegeRepository _db;
    public StudentController(CollegeRepository db) => _db = db;

    public IActionResult Index() => View(_db.Students);

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(string name, string surname, int age, string group)
    {
        try
        {
            var student = new Student(name, surname, age, group);
            _db.Students.Add(student);
            var existing = _db.Groups.FirstOrDefault(g => g.Name.Equals(group, StringComparison.OrdinalIgnoreCase));
            if (existing is null)
            {
                existing = new Group(_db.Groups.Count + 1, group, 1);
                _db.Groups.Add(existing);
            }
            existing.AddStudent(student);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View();
        }
    }

    public IActionResult Delete(int id)
    {
        var student = _db.Students.FirstOrDefault(s => s.StudentId == id);
        if (student is not null)
        {
            _db.Students.Remove(student);
            foreach (var group in _db.Groups) group.RemoveStudent(id);
        }
        return RedirectToAction(nameof(Index));
    }
}

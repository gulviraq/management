using CollegeManagement.Models;

namespace CollegeManagement.Services;

public class AttendanceManager
{
    private readonly List<(int StudentId, DateTime Date, bool Present)> _records = new();

    public void AddAttendance(int studentId, DateTime date, bool present) =>
        _records.Add((studentId, date.Date, present));

    public bool UpdateAttendance(int studentId, DateTime date, bool present)
    {
        var index = _records.FindIndex(x => x.StudentId == studentId && x.Date == date.Date);
        if (index < 0) return false;
        _records[index] = (studentId, date.Date, present);
        return true;
    }

    public string GetStatistics()
    {
        if (_records.Count == 0) return "Записей пока нет.";
        var present = _records.Count(x => x.Present);
        return $"Всего отметок: {_records.Count}; присутствовали: {present}; отсутствовали: {_records.Count - present}.";
    }
}

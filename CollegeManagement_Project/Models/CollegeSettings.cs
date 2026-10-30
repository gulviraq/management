namespace CollegeManagement.Models;

internal class CollegeSettings
{
    internal string CollegeName { get; private set; } = "Колледж";
    internal string AcademicYear { get; private set; } = "2026–2027";

    internal void Update(string name, string year)
    {
        if (!string.IsNullOrWhiteSpace(name)) CollegeName = name;
        if (!string.IsNullOrWhiteSpace(year)) AcademicYear = year;
    }
}

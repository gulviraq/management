namespace CollegeManagement.Services;

public class ReportManager
{
    protected internal string GenerateReport(string title, IEnumerable<string> rows)
    {
        return title + Environment.NewLine + string.Join(Environment.NewLine, rows);
    }
}

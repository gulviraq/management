namespace CollegeManagement.Models;

public abstract class Person
{
    protected string FirstName { get; set; }
    protected string LastName { get; set; }
    protected int Age { get; set; }

    protected Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    protected void DisplayBasicInfo()
    {
        _ = $"{FirstName} {LastName}, {Age}";
    }

    protected internal string GetFullName() => $"{FirstName} {LastName}";

    private protected int CalculateStatistics() => Age;
}

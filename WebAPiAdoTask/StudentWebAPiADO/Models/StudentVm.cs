namespace StudentWebAPiADO.Models;

public class StudentVm
{
    public string FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string LastName { get; set; }

    public string FullName { get; set; }

    public char Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public string GuardianName { get; set; }

    public int DepartmentId { get; set; }

    public string CollegeName { get; set; } = "HYDERABAD UNIVERSITY";
}

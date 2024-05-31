using System.ComponentModel.DataAnnotations;
namespace StudentWebApiEF.Core.DTOs;

public class StudentVmForPost
{
    [Required(ErrorMessage = "Department Id is required")]
    [Range(1, 6)]
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string LastName { get; set; }

    [Required(ErrorMessage = "Full Name is required")]
    public string FullName { get; set; }

    public char Gender { get; set; }

    public string DateOfBirth { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public string GuardianName { get; set; }

    public decimal Grade { get; set; }
}

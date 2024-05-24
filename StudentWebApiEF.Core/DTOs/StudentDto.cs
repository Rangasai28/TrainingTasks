namespace StudentWebApiEF.Core.DTOs;

public class StudentDto
{
    public string FullName { get; set; }

    public string Phone { get; set; }
    public string CollegeName { get; set; }

    public string DepartmentName { get; set; }

    public decimal Grade { get; set; }

    public bool IsActive { get; set; }
}

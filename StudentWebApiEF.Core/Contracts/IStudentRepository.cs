using StudentWebApiEF.Core.DTOs;
using StudentWebApiEF.Core.Models;

namespace StudentWebApiEF.Core.Contracts;

public interface IStudentRepository
{

    Task<IEnumerable<StudentDto>> GetStudents();
    Task<StudentDto> GetStudentById(int id);
    Task<IEnumerable<StudentDto>> GetStudentByName(string firstName);
    Task<StudentDto> AddStudent(Student student);

    Task<bool> UpdateStudent(StudentVmForPut studentVmForPut, int id);

    Task<bool> HardDeleteStudent(int id);

    Task<bool> SoftDeleteStudent(int id);

    bool StudentExists(int id);
    bool DepartmentExists(int id);
}

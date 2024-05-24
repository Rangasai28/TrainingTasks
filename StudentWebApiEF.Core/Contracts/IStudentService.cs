using StudentWebApiEF.Core.DTOs;

namespace StudentWebApiEF.Core.Contracts;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetStudents();
    Task<StudentDto> GetStudentById(int id);
    Task<IEnumerable<StudentDto>> GetStudentByName(string firstName);
    Task<StudentDto> AddStudent(StudentVmForPost studentVmForPost);
    Task<bool> UpdateStudent(StudentVmForPut studentVmForPut, int id);
    Task<bool> SoftDeleteStudent(int id);
    Task<bool> HardDeleteStudent(int id);

}

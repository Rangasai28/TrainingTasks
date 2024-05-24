using StudentWebApiEF.Core.Contracts;
using StudentWebApiEF.Core.DTOs;

namespace StudentWebApiEF.Infrastructure.Services;

public class StudentService : IStudentService
{
    readonly IStudentRepository studentRepository;
    public StudentService(IStudentRepository studentRepository)
    {
        this.studentRepository = studentRepository;
    }
    public async Task<StudentDto> AddStudent(StudentVmForPost studentVmForPost)
    {
        if(studentRepository.DepartmentExists(studentVmForPost.DepartmentId))
        {
            var student = new Core.Models.Student
            {
                DepartmentId = studentVmForPost.DepartmentId,
                FirstName = studentVmForPost.FirstName,
                MiddleName = studentVmForPost.MiddleName,
                LastName = studentVmForPost.LastName,
                FullName = studentVmForPost.FullName,
                Gender = studentVmForPost.Gender,
                DateOfBirth = DateOnly.Parse(studentVmForPost.DateOfBirth),
                Address = studentVmForPost.Address,
                Phone = studentVmForPost.Phone,
                GuardianName = studentVmForPost.GuardianName,
                Grade = studentVmForPost.Grade
            };

            return await studentRepository.AddStudent(student);
        }
        else
        {
            return null;
        }
        

    }

    public async Task<StudentDto> GetStudentById(int id)
    {
        var student = await studentRepository.GetStudentById(id);
        return student;
    }

    public async Task<IEnumerable<StudentDto>> GetStudentByName(string firstName)
    {
        var student = await studentRepository.GetStudentByName(firstName);
        return student;
    }

    public async Task<IEnumerable<StudentDto>> GetStudents()
    {
        var studentDetails = await studentRepository.GetStudents();
        return studentDetails;
    }

    public async Task<bool> HardDeleteStudent(int id)
    {
        var student = await studentRepository.GetStudentById(id);
        if (student == null)
        {
            return false;
        }
        return await studentRepository.HardDeleteStudent(id);
    }

    public async Task<bool> SoftDeleteStudent(int id)
    {
        var student = await studentRepository.GetStudentById(id);
        if (student == null)
        {
            return false;
        }
        return await studentRepository.SoftDeleteStudent(id);
    }

   
    public async Task<bool> UpdateStudent(StudentVmForPut studentVmForPut, int id)
    {
        var student = await studentRepository.GetStudentById(id);
        if (student == null)
        {
            return false;
        }
        return await studentRepository.UpdateStudent(studentVmForPut, id);
    }

}
using Microsoft.EntityFrameworkCore;
using StudentWebApiEF.Core.Contracts;
using StudentWebApiEF.Core.DTOs;
using StudentWebApiEF.Core.Models;
using StudentWebApiEF.Infrastructure.Contexts;

namespace StudentWebApiEF.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    readonly StudentContext contextDb;
    public StudentRepository(StudentContext context)
    {
        contextDb = context;
    }

    public async Task<IEnumerable<StudentDto>> GetStudents()
    {
        var studentDetails = await contextDb.Students.Join(contextDb.Departments, e => e.DepartmentId, d => d.Id,
          (e, d) => new StudentDto
          {
              FullName = e.FullName,
              Phone = e.Phone,
              CollegeName = e.CollegeName,
              DepartmentName = d.DepartmentName,
              Grade = e.Grade,
              IsActive = e.IsActive
          }).ToListAsync();
        return studentDetails;
    }


    public async Task<StudentDto> GetStudentById(int id)
    {
        var student = await (from s in contextDb.Students
                             join d in contextDb.Departments
                             on s.DepartmentId equals d.Id
                             where s.Id == id
                             select new StudentDto
                             {
                                 FullName = s.FullName,
                                 Phone = s.Phone,
                                 CollegeName = s.CollegeName,
                                 DepartmentName = d.DepartmentName,
                                 Grade = s.Grade,
                                 IsActive = s.IsActive
                             }).FirstOrDefaultAsync();

        return student;
    }

    public async Task<IEnumerable<StudentDto>> GetStudentByName(string firstName)
    {
        var student = await (from s in contextDb.Students
                             join d in contextDb.Departments
                             on s.DepartmentId equals d.Id
                             where s.FirstName == firstName && s.IsActive
                             select new StudentDto
                             {
                                 FullName = s.FullName,
                                 Phone = s.Phone,
                                 CollegeName = s.CollegeName,
                                 DepartmentName = d.DepartmentName,
                                 Grade = s.Grade,
                                 IsActive = s.IsActive
                             }).ToListAsync();

        return student;
    }

    public async Task<StudentDto> AddStudent(Student student)
    {
        contextDb.Students.Add(student);
        await contextDb.SaveChangesAsync();
        var studentGet = new StudentDto
        {
            FullName = student.FullName,
            Phone = student.Phone,
            CollegeName = student.CollegeName,
            Grade = student.Grade,
            IsActive = student.IsActive,
        };
        return studentGet;
    }
   
    public async Task<bool> UpdateStudent(StudentVmForPut studentVmForPut, int id)
    {
        var student = await contextDb.Students.FindAsync(id);

        student.Address = studentVmForPut.Address;
        student.Phone = studentVmForPut.Phone;
        student.GuardianName = studentVmForPut.GuardianName;
        student.Grade = studentVmForPut.Grade;
        student.UpdatedDate = DateTime.Now;
        contextDb.Entry(student).State = EntityState.Modified;
        try
        {
            await contextDb.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }
    }


    public async Task<bool> SoftDeleteStudent(int id)
    {
        var student = await contextDb.Students.FindAsync(id);
        student.IsActive = false;
        contextDb.Entry(student).State = EntityState.Modified;
        try
        {
            await contextDb.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }
    }

    public async Task<bool> HardDeleteStudent(int id)
    {
        if (contextDb.Students == null)
        {
            return false;
        }

        var student = await contextDb.Students.FindAsync(id);
        if (student == null)
        {
            return false;
        }

        contextDb.Students.Remove(student);
        await contextDb.SaveChangesAsync();

        return true;
    }


    public bool StudentExists(int id)
    {
        return (contextDb.Students?.Any(e => e.Id == id)).GetValueOrDefault();
    }

    public bool DepartmentExists(int id)
    {
        return (contextDb.Departments?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}

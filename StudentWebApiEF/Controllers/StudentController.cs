using Microsoft.AspNetCore.Mvc;
using StudentWebApiEF.Core.Contracts;
using StudentWebApiEF.Core.DTOs;

namespace StudentWebApiEF.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("studentdetails")]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
    {
        var students = await _studentService.GetStudents();
        if (!students.Any())
        {
            return NoContent();
        }
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDto>> GetStudentById(int id)
    {

        var student = await _studentService.GetStudentById(id);
        if (student == null)
        {
            return NoContent();
        }

        return Ok(student);
    }


    [HttpGet("name")]
    public async Task<ActionResult<StudentDto>> GetStudentByNameEF(string name)
    {
        var student = await _studentService.GetStudentByName(name);
        if (!student.Any())
        {
            return NoContent();
        }
        return Ok(student);
    }



    [HttpPost]
    public async Task<ActionResult<StudentDto>> AddStudent(StudentVmForPost studentVmPost)
    {
        if (ModelState.IsValid)
        {
            var studentGet = await _studentService.AddStudent(studentVmPost);
            return Ok(studentGet);
        }
        else
        {
            return BadRequest(ModelState);
        }

    }


    [HttpPut]
    public async Task<ActionResult> UpdateStudentEF(StudentVmForPut studentVmForPut, int id)
    {
        if (await _studentService.UpdateStudent(studentVmForPut, id))
        {
            return NoContent();
        }
        return NotFound();
    }

    [HttpDelete("harddelete")]
    public async Task<ActionResult> HardDeleteStudent(int id)
    {
        if (await _studentService.HardDeleteStudent(id))
        {
            return NoContent();
        }
        return NotFound();
    }


    [HttpDelete("softdelete")]
    public async Task<ActionResult> SoftDeleteStudent(int id)
    {
        if (await _studentService.SoftDeleteStudent(id))
        {
            return NoContent();
        }
        return NotFound();
    }
}
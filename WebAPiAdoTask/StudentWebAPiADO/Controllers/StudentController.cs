using Microsoft.AspNetCore.Mvc;
using StudentWebAPiADO.Data;
using StudentWebAPiADO.Models;
using System.Data.SqlClient;

namespace StudentWebAPiADO.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly DataConnection? dataConnection;

    public StudentController(DataConnection connection)
    {
        dataConnection = connection;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentVm>>> GetStudents()
    {
        try
        {
            List<StudentDto> studentList = new List<StudentDto>();
            await dataConnection.Connection.OpenAsync();
            string sqlText = $"SELECT FULLNAME,DEPARTMENTNAME,COLLEGENAME,ISACTIVE FROM STUDENT LEFT JOIN DEPARTMENT ON STUDENT.DEPARTMENTID  = DEPARTMENT.ID";
            dataConnection.command = new SqlCommand(sqlText, dataConnection.Connection);
            dataConnection.reader = await dataConnection.command.ExecuteReaderAsync();
            while (await dataConnection.reader.ReadAsync())
            {
                var studentDto = new StudentDto
                {
                    FullName = dataConnection.reader.GetString(0),
                    DepartmentName = dataConnection.reader.GetString(1),
                    CollegeName = dataConnection.reader.GetString(2),
                    IsActive = dataConnection.reader.GetBoolean(3),
                };
                studentList.Add(studentDto);
            }
            await dataConnection.reader.CloseAsync();
            await dataConnection.Connection.CloseAsync();
            return Ok(studentList);
        }
        catch (SqlException ex)
        {
            return BadRequest(ex.Message);
        }
    }



    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDto>> GetStudentById(int id)
    {
        try
        {
            if (!CheckIdInRecords(id))
            {
                return NotFound($"Student with ID {id} not found.");
            }
            await dataConnection.Connection.OpenAsync();
            string sqlText = $"SELECT FULLNAME,DEPARTMENTNAME,COLLEGENAME,ISACTIVE FROM STUDENT LEFT JOIN DEPARTMENT ON STUDENT.DEPARTMENTID  = DEPARTMENT.ID WHERE STUDENT.ID = {id}";
            dataConnection.command = new SqlCommand(sqlText, dataConnection.Connection);
            dataConnection.reader = await dataConnection.command.ExecuteReaderAsync();
            if (await dataConnection.reader.ReadAsync())
            {
                var studentVm = new StudentDto
                {
                    FullName = dataConnection.reader.GetString(0),
                    DepartmentName = dataConnection.reader.GetString(1),
                    CollegeName = dataConnection.reader.GetString(2),
                    IsActive = dataConnection.reader.GetBoolean(3),
                };
                await dataConnection.reader.CloseAsync();
                await dataConnection.Connection.CloseAsync();
                return Ok(studentVm);
            }
            else
            {
                return BadRequest($"Record is Not found based on the Id:{id} specified");
            }
        }
        catch (SqlException ex)
        {
            return BadRequest(ex.Message);
        }
    }




    [HttpGet("firstName")]
    public async Task<ActionResult<StudentDto>> GetStudentByName(String firstName)
    {
        try
        {
            List<StudentDto> studentList = new List<StudentDto>();
            await dataConnection.Connection.OpenAsync();
            string sqlText = $"SELECT FULLNAME,DEPARTMENTNAME,COLLEGENAME,ISACTIVE FROM STUDENT LEFT JOIN DEPARTMENT ON STUDENT.DEPARTMENTID  = DEPARTMENT.ID WHERE STUDENT.FIRSTNAME = '{firstName}' AND STUDENT.ISACTIVE = 1";
            dataConnection.command = new SqlCommand(sqlText, dataConnection.Connection);
            dataConnection.reader = await dataConnection.command.ExecuteReaderAsync();
            while (await dataConnection.reader.ReadAsync())
            {
                var studentDto = new StudentDto
                {
                    FullName = dataConnection.reader.GetString(0),
                    DepartmentName = dataConnection.reader.GetString(1),
                    CollegeName = dataConnection.reader.GetString(2),
                    IsActive = dataConnection.reader.GetBoolean(3),
                };

                studentList.Add(studentDto);
            }
            await dataConnection.reader.CloseAsync();
            await dataConnection.Connection.CloseAsync();
            return Ok(studentList);
        }
        catch (SqlException)
        {
            return BadRequest($"Record is Not found based on the '{firstName}' specified");
        }
    }



    [HttpPost("/addstudent")]
    public async Task<ActionResult> AddStudent(StudentVm student)
    {
        try
        {
            string sqlText = $"INSERT INTO STUDENT(FIRSTNAME,MIDDLENAME,LASTNAME,FULLNAME,GENDER,DATEOFBIRTH,ADDRESS,PHONE,GUARDIANNAME,DEPARTMENTID,CREATEDDATE) VALUES" +
           $"('{student.FirstName}','{student.MiddleName}','{student.LastName}','{student.FullName}','{student.Gender}',{student.DateOfBirth.ToString("yyyyy-MM-dd")},'{student.Address}','{student.Phone}','{student.GuardianName}',{student.DepartmentId},GETDATE())";
            if (CheckDepartmentIdInRecords(student.DepartmentId))
            {
                await dataConnection.Connection.OpenAsync();
                dataConnection.command = new SqlCommand(sqlText, dataConnection.Connection);
                await dataConnection.command.ExecuteNonQueryAsync();
                await dataConnection.Connection.CloseAsync();
                return Ok($"Student:{student.FullName} Added Successfully");
            }
            return BadRequest("Invalid Department Id");

        }
        catch (SqlException ex)
        {
            return Ok($"Unable to Add student due to {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStudent(int id, StudentUpdateVm student)
    {
        try
        {
            if (!CheckIdInRecords(id))
            {
                return NotFound($"Student with ID {id} not found.");
            }
            await dataConnection.Connection.OpenAsync();
            string sqlText = $"UPDATE STUDENT SET ADDRESS = '{student.Address}',PHONE = '{student.Phone}',GUARDIANNAME = '{student.GuardianName}',UPDATEDATE = GETDATE() WHERE ID = {id}";
            dataConnection.command = new SqlCommand(sqlText, dataConnection.Connection);
            await dataConnection.command.ExecuteNonQueryAsync();
            await dataConnection.Connection.CloseAsync();
            return NoContent();
        }
        catch (SqlException ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpDelete("{id}")]

    public async Task<ActionResult> SoftDeleteStudent(int id)
    {
        try
        {
            if (!CheckIdInRecords(id))
            {
                return NotFound($"Student with ID {id} not found.");
            }
            await dataConnection.Connection.OpenAsync();
            string sqlText = $"UPDATE STUDENT SET ISACTIVE = 0 WHERE ID = {id}";
            dataConnection.command = new SqlCommand(sqlText, dataConnection.Connection);
            await dataConnection.command.ExecuteNonQueryAsync();
            await dataConnection.Connection.CloseAsync();
            return NoContent();
        }
        catch (SqlException ex)
        {
            return BadRequest(ex.Message);
        }
    }


    //Deleting  particular student's record from the table
    [HttpDelete("/Delete")]

    public async Task<ActionResult> HardDelete(int id)
    {
        try
        {
            if (!CheckIdInRecords(id))
            {
                return NotFound($"Student with ID {id} not found.");
            }

            await dataConnection.Connection.OpenAsync();
            string sqlText = $"DELETE FROM STUDENT WHERE ID = {id}";
            dataConnection.command = new SqlCommand(sqlText, dataConnection.Connection);
            await dataConnection.command.ExecuteNonQueryAsync();
            await dataConnection.Connection.CloseAsync();
            return NoContent();
        }
        catch (SqlException ex)
        {
            return BadRequest(ex.Message);
        }
    }


    //Non Action Method that Checks if a Record is present in Database based on ID
    private bool CheckIdInRecords(int id)
    {
        dataConnection.Connection.Open();
        string checkSql = $"SELECT COUNT(*) FROM STUDENT WHERE ID = {id}";
        dataConnection.command = new SqlCommand(checkSql, dataConnection.Connection);
        int count = Convert.ToInt32(dataConnection.command.ExecuteScalar());

        if (count == 0)
        {
            dataConnection.Connection.Close();
            return false;
        }
        dataConnection.Connection.Close();
        return true;
    }

    private bool CheckDepartmentIdInRecords(int id)
    {
        dataConnection.Connection.Open();
        string checkSql = $"SELECT COUNT(*) FROM DEPARTMENT WHERE ID = {id}";
        dataConnection.command = new SqlCommand(checkSql, dataConnection.Connection);
        int count = Convert.ToInt32(dataConnection.command.ExecuteScalar());

        if (count == 0)
        {
            dataConnection.Connection.Close();
            return false;
        }
        dataConnection.Connection.Close();
        return true;
    }
}

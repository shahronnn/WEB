namespace WebAPI.Controllers;
using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;
    public StudentController()
    {
        _studentService = new StudentService();
    }

    [HttpPost("AddStudent")]
    public string AddStudent(Student student)=> _studentService.AddStudent(student);

    [HttpGet("GetStudents")]
    public List<Student> GetStudents()=> _studentService.GetStudents();
    [HttpDelete("DeleteStudent")]
    public string DeleteStudent(int id)=> _studentService.DeleteStudent(id);
    [HttpPut("UpdateStudent")]
    public string UpdateStudent(Student student)=> _studentService.UpdateStudent(student);

}

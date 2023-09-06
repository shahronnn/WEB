using Dapper;
using Npgsql;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class StudentService
{
    private readonly DataContext _dataContext;
    public StudentService()=>_dataContext = new DataContext();
    public string AddStudent(Student student)
    {
            using var connection = _dataContext.CreateConnection();
            var sql = $"insert into students(firstname, lastname, age, phone) values('{student.FirstName}', '{student.LastName}', {student.Age}, '{student.Phone}')";
            var res = connection.Execute(sql);
            if (res == 1) return "Student added!";
            return "Error";
    }
    public string UpdateStudent(Student student)
    {
        using var connection = _dataContext.CreateConnection();
            var sql = $"update students set firstname = '{student.FirstName}', lastname = '{student.LastName}', age = {student.Age}, phone = '{student.Phone}' where id = {student.Id}'";
            var res = connection.Execute(sql);
            if (res == 1)return "Student updated!";
            return "Error";
    }
    public string DeleteStudent(int id)
    {
        using var connection = _dataContext.CreateConnection();
            var sql = $"delete students where id = {id}";
            var res = connection.Execute(sql);
            if(res == 1)return "Student deleted!";
            return "Error";
    }
    public List<Student> GetStudents()
    {
        using var connection = _dataContext.CreateConnection();
            var sql = "select * from students";
            var res = connection.Query<Student>(sql);
            return res.ToList();
    }
}

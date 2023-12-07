using Dapper;
using StudentAPI.Interfaces;
using StudentAPI.Models;
using System.Data;

namespace StudentAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _connection;
        public StudentRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public List<Student> GetStudents()
        {
            var record = _connection.Query<Student>("SELECT student_id as StudentId, student_name as StudentName, department_id as DepartmentId FROM STUDENT").ToList();
            return record;
        }
        public List<Student> GetStudentsByDepartmentId(int departmentId)
        {
            // Implement logic to retrieve students by department using Dapper
            var students = _connection.Query<Student>("SELECT student_id as StudentId, student_name as StudentName, department_id as DepartmentId FROM STUDENT WHERE department_id = @DepartmentId", new { DepartmentId = departmentId }).ToList();
            return students;
        }
    }
}

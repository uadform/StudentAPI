using Dapper;
using StudentAPI.Interfaces;
using StudentAPI.Models;
using System.Data;

namespace StudentAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _connection;
        private readonly ILogger<StudentRepository> _logger;
        public StudentRepository(IDbConnection connection, ILogger<StudentRepository> logger)
        {
            _connection = connection;
            _logger = logger;
        }
        public List<Student> GetStudents()
        {
            try
            {
                var record = _connection.Query<Student>("SELECT student_id as StudentId, student_name as StudentName, department_id as DepartmentId FROM STUDENT").ToList();
                return record;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the GetStudents method of StudentRepository.");
                throw;
            }
        }
        public List<Student> GetStudentsByDepartmentId(int departmentId)
        {
            var students = _connection.Query<Student>("SELECT student_id as StudentId, student_name as StudentName, department_id as DepartmentId FROM STUDENT WHERE department_id = @DepartmentId", new { DepartmentId = departmentId }).ToList();
            return students;
        }
    }
}

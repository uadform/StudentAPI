using Dapper;
using StudentAPI.Interfaces;
using StudentAPI.Models;
using System.Data;

namespace StudentAPI.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        public DepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Departament> GetDepartmentById(int departmentId)
        {
            var record = await _connection.QueryFirstOrDefaultAsync<Departament>("SELECT department_id as DepartmentId, department_name as DepartmentName FROM DEPARTMENT WHERE department_id = @DepartmentId", new { DepartmentId = departmentId });
            return record;
        }

        public List<Departament> GetDepartments()
        {
            var record = _connection.Query<Departament>("SELECT department_id as DepartmentId, department_name as DepartmentName FROM DEPARTMENT").ToList();
            return record;
        }
        public async Task<int> CreateDepartmentWithStudentsAndLectures(Departament department, List<Student> students, List<Lecture> lectures)
        {
            var departmentId = await _connection.ExecuteScalarAsync<int>("INSERT INTO DEPARTMENT (department_name) VALUES (@DepartmentName) RETURNING department_id", department);

            foreach (var student in students)
            {
                student.DepartmentId = departmentId;
                await _connection.ExecuteAsync("INSERT INTO STUDENT (student_name, department_id) VALUES (@StudentName, @DepartmentId)", student);
            }

            foreach (var lecture in lectures)
            {
                await _connection.ExecuteAsync("INSERT INTO DEPARTMENTLECTURE (department_id, lecture_id) VALUES (@DepartmentId, @LectureId)", new { DepartmentId = departmentId, LectureId = lecture.LectureId });
            }

            return departmentId;
        }
        public async Task<int> AddStudentsToDepartment(int departmentId, List<Student> students)
        {
            foreach (var student in students)
            {
                student.DepartmentId = departmentId;
                await _connection.ExecuteAsync("INSERT INTO STUDENT (student_name, department_id) VALUES (@StudentName, @DepartmentId)", student);
            }

            return students.Count;
        }
        public async Task<bool> TransferStudent(int studentId, int newDepartmentId)
        {
            var affectedRows = await _connection.ExecuteAsync("UPDATE STUDENT SET department_id = @NewDepartmentId WHERE student_id = @StudentId", new { NewDepartmentId = newDepartmentId, StudentId = studentId });

            return affectedRows > 0;
        }
    }
}

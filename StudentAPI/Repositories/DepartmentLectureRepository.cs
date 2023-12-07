using Dapper;
using StudentAPI.Interfaces;
using StudentAPI.Models;
using System.Data;

namespace StudentAPI.Repositories
{
    public class DepartmentLectureRepository : IDepartmentLectureRepository
    {
        private readonly IDbConnection _connection;
        public DepartmentLectureRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public List<DepartmentLecture> GetDepartmentLecture()
        {
            var record = _connection.Query<DepartmentLecture>("SELECT department_id as DepartmentId, lecture_id as LectureID FROM DEPARTMENTLECTURE").ToList();
            return record;
        }
    }
}

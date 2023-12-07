using Dapper;
using StudentAPI.Interfaces;
using StudentAPI.Models;
using System.Data;

namespace StudentAPI.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private readonly IDbConnection _connection;
        public LectureRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public List<Lecture> GetLectures()
        {
            var record = _connection.Query<Lecture>("SELECT lecture_id as LectureId, lecture_name as LectureName FROM LECTURE").ToList();
            return record;
        }
        public List<Lecture> GetLecturesByDepartmentId(int departmentId)
        {
            // Implement logic to retrieve lectures by department using Dapper
            var lectures = _connection.Query<Lecture>("SELECT LECTURE.lecture_id as LectureId, LECTURE.lecture_name as LectureName FROM LECTURE " +
                "JOIN DEPARTMENTLECTURE ON LECTURE.lecture_id = DEPARTMENTLECTURE.lecture_id " +
                "WHERE DEPARTMENTLECTURE.department_id = @DepartmentId", new { DepartmentId = departmentId }).ToList();
            return lectures;
        }
        public async Task<List<Lecture>> GetLecturesByStudentId(int studentId)
        {
            // Implement logic to retrieve lectures by student using Dapper
            var lectures = await _connection.QueryAsync<Lecture>("SELECT LECTURE.lecture_id as LectureId, LECTURE.lecture_name as LectureName " +
                "FROM LECTURE " +
                "JOIN DEPARTMENTLECTURE ON LECTURE.lecture_id = DEPARTMENTLECTURE.lecture_id " +
                "JOIN STUDENT ON DEPARTMENTLECTURE.department_id = STUDENT.department_id " +
                "WHERE STUDENT.student_id = @StudentId", new { StudentId = studentId });
            return lectures.ToList();
        }

    }
}

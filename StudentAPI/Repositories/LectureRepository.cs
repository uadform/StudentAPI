using Dapper;
using StudentAPI.Interfaces;
using StudentAPI.Models;
using System.Data;

namespace StudentAPI.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private readonly IDbConnection _connection;
        private readonly ILogger<LectureRepository> _logger;
        public LectureRepository(IDbConnection connection, ILogger<LectureRepository> logger)
        {
            _connection = connection;
            _logger = logger;
        }
        public List<Lecture> GetLectures()
        {
            var record = _connection.Query<Lecture>("SELECT lecture_id as LectureId, lecture_name as LectureName FROM LECTURE").ToList();
            return record;
        }
        public List<Lecture> GetLecturesByDepartmentId(int departmentId)
        {
            try
            {
                var lectures = _connection.Query<Lecture>("SELECT LECTURE.lecture_id as LectureId, LECTURE.lecture_name as LectureName FROM LECTURE " +
                    "JOIN DEPARTMENTLECTURE ON LECTURE.lecture_id = DEPARTMENTLECTURE.lecture_id " +
                    "WHERE DEPARTMENTLECTURE.department_id = @DepartmentId", new { DepartmentId = departmentId }).ToList();
                return lectures;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the GetLecturesByDepartmentId method.");
                throw;
            }
        }

        public async Task<List<Lecture>> GetLecturesByStudentId(int studentId)
        {
            try
            {
                var lectures = await _connection.QueryAsync<Lecture>("SELECT LECTURE.lecture_id as LectureId, LECTURE.lecture_name as LectureName " +
                    "FROM LECTURE " +
                    "JOIN DEPARTMENTLECTURE ON LECTURE.lecture_id = DEPARTMENTLECTURE.lecture_id " +
                    "JOIN STUDENT ON DEPARTMENTLECTURE.department_id = STUDENT.department_id " +
                    "WHERE STUDENT.student_id = @StudentId", new { StudentId = studentId });
                return lectures.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the GetLecturesByStudentId method.");
                throw;
            }
        }

        public async Task<int> CreateLectureAndAddToDepartment(string lectureName, int departmentId)
        {
            try
            {
                var lectureId = await _connection.ExecuteScalarAsync<int>("INSERT INTO LECTURE (lecture_name) VALUES (@LectureName) RETURNING lecture_id", new { LectureName = lectureName });

                if (lectureId > 0)
                {
                    await _connection.ExecuteAsync("INSERT INTO DEPARTMENTLECTURE (department_id, lecture_id) VALUES (@DepartmentId, @LectureId)", new { DepartmentId = departmentId, LectureId = lectureId });
                }

                return lectureId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the CreateLectureAndAddToDepartment method.");
                throw;
            }
        }


    }
}

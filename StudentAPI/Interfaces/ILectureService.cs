using StudentAPI.Models;

namespace StudentAPI.Interfaces
{
    public interface ILectureService
    {
        public List<Lecture> GetLectures();
        public List<Lecture> GetLecturesByDepartmentId(int departmentId);
        public Task<List<Lecture>> GetLecturesByStudentId(int studentId);
    }
}

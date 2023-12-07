using StudentAPI.Models;

namespace StudentAPI.Interfaces
{
    public interface ILectureRepository
    {
        public List<Lecture> GetLectures();
        public List<Lecture> GetLecturesByDepartmentId(int departmentId);
        Task<List<Lecture>> GetLecturesByStudentId(int studentId);
    }
}

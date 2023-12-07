using StudentAPI.Models;

namespace StudentAPI.Interfaces
{
    public interface IDepartmentLectureRepository
    {
        public List<DepartmentLecture> GetDepartmentLecture();
    }
}

using StudentAPI.Models;

namespace StudentAPI.Interfaces
{
    public interface IDepartmentLectureService
    {
        public List<DepartmentLecture> GetDepartmentLecture();
    }
}

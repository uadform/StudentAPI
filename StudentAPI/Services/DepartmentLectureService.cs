using StudentAPI.Interfaces;
using StudentAPI.Models;

namespace StudentAPI.Services
{
    public class DepartmentLectureService : IDepartmentLectureService
    {
        private readonly IDepartmentLectureRepository _departmentLectureRepository;
        public DepartmentLectureService(IDepartmentLectureRepository departmentLectureRepository)
        {
            _departmentLectureRepository = departmentLectureRepository;
        }
        public List<DepartmentLecture> GetDepartmentLecture()
        {
            return _departmentLectureRepository.GetDepartmentLecture().ToList();
        }
    }
}

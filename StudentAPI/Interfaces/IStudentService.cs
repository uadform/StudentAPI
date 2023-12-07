using StudentAPI.Models;

namespace StudentAPI.Interfaces
{
    public interface IStudentService
    {
        public List<Student> GetStudents();
        public List<Student> GetStudentsByDepartmentId(int departmentId);
    }
}

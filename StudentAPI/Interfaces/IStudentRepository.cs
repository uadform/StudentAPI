using StudentAPI.Models;

namespace StudentAPI.Interfaces
{
    public interface IStudentRepository
    {
        public List<Student> GetStudents();
        public List<Student> GetStudentsByDepartmentId(int departmentId);
    }
}

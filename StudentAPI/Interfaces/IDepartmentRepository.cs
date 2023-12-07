using StudentAPI.Models;

namespace StudentAPI.Interfaces
{
    public interface IDepartmentRepository
    {
        public List<Departament> GetDepartments();
        public Task<Departament> GetDepartmentById(int departmentId);
        Task<int> CreateDepartmentWithStudentsAndLectures(Departament department, List<Student> students, List<Lecture> lectures);
        Task<int> AddStudentsToDepartment(int departmentId, List<Student> students);
        Task<bool> TransferStudent(int studentId, int newDepartmentId);
    }
}

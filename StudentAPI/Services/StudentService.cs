using StudentAPI.Interfaces;
using StudentAPI.Models;

namespace StudentAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository) 
        {
            _studentRepository = studentRepository;
        }
        public List<Student> GetStudents()
        {
            return _studentRepository.GetStudents().ToList();
        }
        public List<Student> GetStudentsByDepartmentId(int departmentId)
        {
            return _studentRepository.GetStudentsByDepartmentId(departmentId).ToList();
        }
    }
}

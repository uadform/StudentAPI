using StudentAPI.Interfaces;
using StudentAPI.Models;
using StudentAPI.Repositories;

namespace StudentAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public List<Departament> GetDepartments()
        {
            return _departmentRepository.GetDepartments().ToList();
        }
        public async Task<Departament> GetDepartmentById(int departmentId)
        {
            return await _departmentRepository.GetDepartmentById(departmentId);
        }
        public async Task<int> CreateDepartmentWithStudentsAndLectures(Departament department, List<Student> students, List<Lecture> lectures)
        {
            return await _departmentRepository.CreateDepartmentWithStudentsAndLectures(department, students, lectures);
        }
        public async Task<int> AddStudentsToDepartment(int departmentId, List<Student> students)
        {
            return await _departmentRepository.AddStudentsToDepartment(departmentId, students);
        }
        public async Task<bool> TransferStudent(int studentId, int newDepartmentId)
        {
            return await _departmentRepository.TransferStudent(studentId, newDepartmentId);
        }
    }
}

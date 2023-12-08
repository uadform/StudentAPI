using StudentAPI.Interfaces;
using StudentAPI.Models;
using StudentAPI.Repositories;
using System.Data.Common;

namespace StudentAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<DepartmentService> _logger;
        public DepartmentService(IDepartmentRepository departmentRepository, ILogger<DepartmentService> logger)
        {
            _departmentRepository = departmentRepository;
            _logger = logger;
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
        public async Task<int> AddLecturesToDepartment(int departmentId, List<Lecture> lectures)
        {
            try
            {
                var addedLecturesCount = await _departmentRepository.AddLecturesToDepartment(departmentId, lectures);
                return addedLecturesCount;
            }
            catch (DbException dbEx)
            {
                _logger.LogError(dbEx, "Database error in the AddLecturesToDepartment method.");
                throw; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the AddLecturesToDepartment method.");
                throw;
            }
        }
        public async Task<bool> TransferStudent(int studentId, int newDepartmentId)
        {
            return await _departmentRepository.TransferStudent(studentId, newDepartmentId);
        }
    }
}

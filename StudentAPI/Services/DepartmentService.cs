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
    }
}

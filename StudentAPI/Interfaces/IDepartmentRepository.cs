using StudentAPI.Models;

namespace StudentAPI.Interfaces
{
    public interface IDepartmentRepository
    {
        public List<Departament> GetDepartments();
        public Task<Departament> GetDepartmentById(int departmentId);
    }
}

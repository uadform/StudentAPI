using StudentAPI.Models;

namespace StudentAPI.Interfaces
{
    public interface IDepartmentService
    {
        public List<Departament> GetDepartments();
        public Task<Departament> GetDepartmentById(int departmentId);
    }
}

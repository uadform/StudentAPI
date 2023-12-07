using Dapper;
using StudentAPI.Interfaces;
using StudentAPI.Models;
using System.Data;

namespace StudentAPI.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        public DepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Departament> GetDepartmentById(int departmentId)
        {
            // Implement logic to retrieve department by id from the database using Dapper
            var record = await _connection.QueryFirstOrDefaultAsync<Departament>("SELECT department_id as DepartmentId, department_name as DepartmentName FROM DEPARTMENT WHERE department_id = @DepartmentId", new { DepartmentId = departmentId });
            return record;
        }

        public List<Departament> GetDepartments()
        {
            var record = _connection.Query<Departament>("SELECT department_id as DepartmentId, department_name as DepartmentName FROM DEPARTMENT").ToList();
            return record;
        }
    }
}

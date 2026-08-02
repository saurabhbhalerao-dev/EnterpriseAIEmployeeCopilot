using EnterpriseAIEmployeeCopilot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee?> GetByEmailAsync(string email);

        Task<Employee?> GetByEmployeeCodeAsync(string employeeCode);

        Task<IEnumerable<Employee>> GetByDepartmentAsync(int departmentId);

        Task<IEnumerable<Employee>> GetManagersAsync();

        Task<IEnumerable<Employee>> GetAllWithDetailsAsync();

        Task<Employee?> GetByIdWithDetailsAsync(int id);
    }
}

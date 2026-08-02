using EnterpriseAIEmployeeCopilot.Application.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();

        Task<EmployeeDetailsDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateEmployeeDto dto);

        Task UpdateAsync(int id, UpdateEmployeeDto dto);

        Task DeleteAsync(int id);
    }
}

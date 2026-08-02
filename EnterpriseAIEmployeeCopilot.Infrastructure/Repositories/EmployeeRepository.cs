using EnterpriseAIEmployeeCopilot.Domain.Entities;
using EnterpriseAIEmployeeCopilot.Domain.Interfaces.Repositories;
using EnterpriseAIEmployeeCopilot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.Repositories
{
    public class EmployeeRepository
        : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _context.Employees
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .Include(x => x.Role)
                .Include(x => x.Manager)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Employee?> GetByEmployeeCodeAsync(string employeeCode)
        {
            return await _context.Employees
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .Include(x => x.Role)
                .Include(x => x.Manager)
                .FirstOrDefaultAsync(x => x.EmployeeCode == employeeCode);
        }

        public async Task<IEnumerable<Employee>> GetByDepartmentAsync(int departmentId)
        {
            return await _context.Employees
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .Include(x => x.Role)
                .Where(x => x.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetManagersAsync()
        {
            return await _context.Employees
                .Where(x => x.TeamMembers.Any())
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllWithDetailsAsync()
        {
            return await _context.Employees
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .Include(x => x.Role)
                .Include(x => x.Manager)
                .ToListAsync();
        }

        public async Task<Employee?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Employees
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .Include(x => x.Role)
                .Include(x => x.Manager)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
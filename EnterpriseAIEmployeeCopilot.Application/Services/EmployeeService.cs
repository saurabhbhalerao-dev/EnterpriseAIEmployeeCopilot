using AutoMapper;
using EnterpriseAIEmployeeCopilot.Application.DTOs.Employee;
using EnterpriseAIEmployeeCopilot.Application.Exceptions;
using EnterpriseAIEmployeeCopilot.Application.Interfaces.Services;
using EnterpriseAIEmployeeCopilot.Domain.Entities;
using EnterpriseAIEmployeeCopilot.Domain.Interfaces;

namespace EnterpriseAIEmployeeCopilot.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork  = unitOfWork;
            _mapper = mapper;
        
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();

            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDetailsDto?> GetByIdAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);

            if (employee == null)
                return null;

            return _mapper.Map<EmployeeDetailsDto>(employee);
        }

        public async Task<int> CreateAsync(CreateEmployeeDto dto)
        {
            if (await _unitOfWork.Employees.ExistsAsync(x => x.Email == dto.Email))
                throw new BadRequestException("Email already exists.");

            if (await _unitOfWork.Employees.ExistsAsync(x => x.EmployeeCode == dto.EmployeeCode))
                throw new BadRequestException("Employee Code already exists.");

            var employee = _mapper.Map<Employee>(dto);

            // Temporary until Identity/JWT is implemented
            employee.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await _unitOfWork.Employees.AddAsync(employee);

            await _unitOfWork.SaveChangesAsync();

            return employee.Id;
        }

        public async Task UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);

            if (employee == null)
               
                throw new NotFoundException("Employee not found.");

            _mapper.Map(dto, employee);

            _unitOfWork.Employees.Update(employee);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);

            if (employee == null)
                throw new Exception("Employee not found.");

            _unitOfWork.Employees.Delete(employee);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

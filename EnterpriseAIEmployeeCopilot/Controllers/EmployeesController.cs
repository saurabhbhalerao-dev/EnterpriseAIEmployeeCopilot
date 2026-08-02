using EnterpriseAIEmployeeCopilot.Application.DTOs.Employee;
using EnterpriseAIEmployeeCopilot.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAIEmployeeCopilot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();

            return Ok(employees);
        }

        // GET: api/employees/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeDetailsDto>> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            return Ok(employee);
        }

        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateEmployeeDto dto)
        {
            var id = await _employeeService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id },
                id);
        }

        // PUT: api/employees/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateEmployeeDto dto)
        {
            await _employeeService.UpdateAsync(id, dto);

            return NoContent();
        }

        // DELETE: api/employees/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);

            return NoContent();
        }
    }
}

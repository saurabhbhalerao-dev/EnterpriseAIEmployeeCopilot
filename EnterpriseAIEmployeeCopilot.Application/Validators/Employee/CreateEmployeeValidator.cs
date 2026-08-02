using EnterpriseAIEmployeeCopilot.Application.DTOs.Employee;
using FluentValidation;

namespace EnterpriseAIEmployeeCopilot.Application.Validators.Employee
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeValidator() 
        {
            RuleFor(x => x.EmployeeCode)
                 .NotEmpty()
                 .MaximumLength(20);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(150);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0);

            RuleFor(x => x.DesignationId)
                .GreaterThan(0);

            RuleFor(x => x.RoleId)
                .GreaterThan(0);

            RuleFor(x => x.DateOfJoining)
                .NotEmpty();
        }
    }
}

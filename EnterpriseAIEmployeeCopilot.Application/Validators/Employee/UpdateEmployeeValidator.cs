using EnterpriseAIEmployeeCopilot.Application.DTOs.Employee;
using FluentValidation;

namespace EnterpriseAIEmployeeCopilot.Application.Validators.Employee
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeDto>
    {
        public UpdateEmployeeValidator()
        {
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

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0);

            RuleFor(x => x.DesignationId)
                .GreaterThan(0);

            RuleFor(x => x.RoleId)
                .GreaterThan(0);
        }
    }
}
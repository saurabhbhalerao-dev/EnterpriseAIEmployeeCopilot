using EnterpriseAIEmployeeCopilot.Application.Interfaces.Services;
using EnterpriseAIEmployeeCopilot.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;

namespace EnterpriseAIEmployeeCopilot.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Services
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}

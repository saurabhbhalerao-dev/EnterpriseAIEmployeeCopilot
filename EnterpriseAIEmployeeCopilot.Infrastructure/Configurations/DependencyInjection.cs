using EnterpriseAIEmployeeCopilot.Application.Interfaces.Services;
using EnterpriseAIEmployeeCopilot.Domain.Interfaces;
using EnterpriseAIEmployeeCopilot.Infrastructure.Data;
using EnterpriseAIEmployeeCopilot.Infrastructure.Repositories;
using EnterpriseAIEmployeeCopilot.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtSettings>(
                configuration.GetSection(JwtSettings.SectionName));

            // Repository & Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // JWT Service
            services.AddScoped<IJwtTokenService, JwtTokenService>();

            return services;
        }
    }
}
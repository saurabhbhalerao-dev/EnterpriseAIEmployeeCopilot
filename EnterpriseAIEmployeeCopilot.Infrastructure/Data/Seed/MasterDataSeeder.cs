using EnterpriseAIEmployeeCopilot.Domain.Entities;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.Data.Seed;

public static class MasterDataSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (!context.Departments.Any())
        {
            context.Departments.AddRange(
                new Department
                {
                    Name = "Information Technology",
                    Description = "IT Department",
                    IsActive = true
                },
                new Department
                {
                    Name = "Human Resources",
                    Description = "HR Department",
                    IsActive = true
                },
                new Department
                {
                    Name = "Finance",
                    Description = "Finance Department",
                    IsActive = true
                });
        }

        if (!context.Designations.Any())
        {
            context.Designations.AddRange(
                new Designation
                {
                    Name = "Software Engineer",
                    Description = "Software Engineer",
                    IsActive = true
                },
                new Designation
                {
                    Name = "Senior Software Engineer",
                    Description = "Senior Software Engineer",
                    IsActive = true
                },
                new Designation
                {
                    Name = "Manager",
                    Description = "Project Manager",
                    IsActive = true
                });
        }

        if (!context.Roles.Any())
        {
            context.Roles.AddRange(
                new Role
                {
                    Name = "Admin",
                    Description = "System Administrator"
                },
                new Role
                {
                    Name = "Manager",
                    Description = "Manager"
                },
                new Role
                {
                    Name = "Employee",
                    Description = "Employee"
                });
        }

        await context.SaveChangesAsync();
    }
}
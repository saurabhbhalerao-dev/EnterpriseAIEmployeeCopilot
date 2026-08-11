using EnterpriseAIEmployeeCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.Data.Seed
{
    public static class MasterDataSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            Console.WriteLine("========== MASTER DATA SEEDING STARTED ==========");

            // -------------------------
            // Departments
            // -------------------------
            if (!await context.Departments.AnyAsync())
            {
                Console.WriteLine("Seeding Departments...");

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

            // -------------------------
            // Designations
            // -------------------------
            if (!await context.Designations.AnyAsync())
            {
                Console.WriteLine("Seeding Designations...");

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

            // -------------------------
            // Roles
            // -------------------------
            if (!await context.Roles.AnyAsync())
            {
                Console.WriteLine("Seeding Roles...");

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

            // -------------------------
            // Default Admin Employee
            // -------------------------

            var adminEmployee = await context.Employees
                .FirstOrDefaultAsync(x => x.Email == "admin@copilot.com");

            if (adminEmployee == null)
            {
                Console.WriteLine("Seeding Admin Employee...");

                var adminRole = await context.Roles
                    .FirstAsync(x => x.Name == "Admin");

                var department = await context.Departments
                    .FirstAsync(x => x.Name == "Information Technology");

                var designation = await context.Designations
                    .FirstAsync(x => x.Name == "Software Engineer");

                context.Employees.Add(new Employee
                {
                    EmployeeCode = "EMP001",
                    FirstName = "System",
                    LastName = "Administrator",
                    Email = "admin@copilot.com",

                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),

                    DepartmentId = department.Id,
                    DesignationId = designation.Id,
                    RoleId = adminRole.Id,
                    DateOfJoining = DateTime.UtcNow,
                    IsActive = true
                });

                Console.WriteLine("Admin Employee Created.");
            }
            else if (adminEmployee.PasswordHash == "Admin@123")
            {
                // One-time correction for the previously seeded plain-text password
                adminEmployee.PasswordHash =
                    BCrypt.Net.BCrypt.HashPassword("Admin@123");

                Console.WriteLine("Existing Admin password converted to BCrypt hash.");
            }

            await context.SaveChangesAsync();

            Console.WriteLine("========== MASTER DATA SEEDED SUCCESSFULLY ==========");

            // Save all master data
            await context.SaveChangesAsync();

            Console.WriteLine("========== MASTER DATA SEEDED SUCCESSFULLY ==========");
        }
    }
}
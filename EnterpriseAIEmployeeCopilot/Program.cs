using EnterpriseAIEmployeeCopilot.API.Middleware;
using EnterpriseAIEmployeeCopilot.Application;
using EnterpriseAIEmployeeCopilot.Infrastructure.Configurations;
using EnterpriseAIEmployeeCopilot.Infrastructure.Data;
using EnterpriseAIEmployeeCopilot.Infrastructure.Data.Seed;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Services

// Controllers
builder.Services.AddControllers();

// JWT Configuration
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection(JwtSettings.SectionName));

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration
            .GetSection(JwtSettings.SectionName)
            .Get<JwtSettings>();

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings!.Issuer,
            ValidAudience = jwtSettings.Audience,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Key))
        };
    });

// Application Layer
builder.Services.AddApplication();

// Infrastructure Layer
builder.Services.AddInfrastructure(builder.Configuration);

#endregion

var app = builder.Build();

#region Database Migration & Seed

using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        await context.Database.MigrateAsync();

        await MasterDataSeeder.SeedAsync(context);

        Console.WriteLine("========================================");
        Console.WriteLine("Database Migration Completed.");
        Console.WriteLine("Master Data Seed Completed.");
        Console.WriteLine("========================================");
    }
    catch (Exception ex)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("DATABASE INITIALIZATION FAILED");
        Console.WriteLine(ex);
        Console.WriteLine("========================================");

        throw;
    }
}

#endregion

#region Middleware

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();
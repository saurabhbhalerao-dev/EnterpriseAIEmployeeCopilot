using EnterpriseAIEmployeeCopilot.API.Middleware;
using EnterpriseAIEmployeeCopilot.Application;
using EnterpriseAIEmployeeCopilot.Infrastructure.Configurations;
using EnterpriseAIEmployeeCopilot.Infrastructure.Data;
using EnterpriseAIEmployeeCopilot.Infrastructure.Data.Seed;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Services

// Add Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application Layer
builder.Services.AddApplication();

// Infrastructure Layer
builder.Services.AddInfrastructure(builder.Configuration);

#endregion

var app = builder.Build();

#region Seed Master Data

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        // Ensure database exists
        await context.Database.MigrateAsync();

        // Seed Master Data
        await MasterDataSeeder.SeedAsync(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database Seeding Error: {ex.Message}");
    }
}

#endregion

#region Middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();
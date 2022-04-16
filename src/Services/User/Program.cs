using System.Reflection;
using User.Application.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Seedwork.DomainObjects;
using User.Application.Queries;
using User.Domain;
using User.Infra;
using User.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IRequestHandler<CreateUserCommand, CreateUserCommandResponse>, CreateUserCommandHandler>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserQueries, UserQueries>();

builder.Services.AddDbContext<Context>(options =>
{   
    var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new ArgumentException("CONNECTION_STRING não foi definida para Api User");                
    // var connectionString = @"Host=localhost;Port=5050;Database=postgres;UID=postgres;PWD=postgres";

    options.UseNpgsql(connectionString, 
                     sqlServerDbContextOptionsBuilder => sqlServerDbContextOptionsBuilder.EnableRetryOnFailure());    
    options.EnableSensitiveDataLogging();
});

var app = builder.Build();

try
{
    using var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope();
    var context = serviceScope.ServiceProvider.GetRequiredService<Context>();
    context.Database.Migrate();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

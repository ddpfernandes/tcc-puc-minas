using System.Reflection;
using Customer.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Seedwork.DomainObjects;
using Customer.Application.Commands;
using Customer.Domain;
using Customer.Application.Queries;
using Customer.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>, CreateCustomerCommandHandler>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerQueries, CustomerQueries>();

builder.Services.AddDbContext<Context>(options =>
{   
    var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new ArgumentException("CONNECTION_STRING não foi definida para Api Customer");                
    // var connectionString = @"Host=localhost;Port=5051;Database=postgres;UID=postgres;PWD=postgres";

    options.UseNpgsql(connectionString, 
                     sqlServerDbContextOptionsBuilder => sqlServerDbContextOptionsBuilder.EnableRetryOnFailure());    
    options.EnableSensitiveDataLogging();
});

var app = builder.Build();

using var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope();
var context = serviceScope.ServiceProvider.GetRequiredService<Context>();
context.Database.Migrate();

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

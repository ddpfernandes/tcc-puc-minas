using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Seedwork.DomainObjects;
using Supplier.Application.Commands;
using Supplier.Application.Queries;
using Supplier.Domain;
using Supplier.Infra;
using Supplier.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IRequestHandler<CreateSupplierCommand, CreateSupplierCommandResponse>, CreateSupplierCommandHandler>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierQueries, SupplierQueries>();

builder.Services.AddDbContext<Context>(options =>
{   
    var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new ArgumentException("CONNECTION_STRING não foi definida para Api Supplier");                
    // var connectionString = @"Host=localhost;Port=5052;Database=postgres;UID=postgres;PWD=postgres";

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

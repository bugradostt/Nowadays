using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Nowadays.Business.Implementations;
using Nowadays.Business.Interfaces;
using Nowadays.DataAccess.Contexts;
using Nowadays.DataAccess.Dtos.Mapper;
using Nowadays.DataAccess.Implementations;
using Nowadays.DataAccess.Interfaces;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MapperDto>();
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IIssueService, IssueService>();
builder.Services.AddScoped<IIssueRepository, IssueRepository>();

var app = builder.Build();

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

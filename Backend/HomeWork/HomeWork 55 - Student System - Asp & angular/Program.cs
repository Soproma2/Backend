using HomeWork_55___Student_System___Asp___angular.Data;
using HomeWork_55___Student_System___Asp___angular.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(o=>o.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Students_Angular;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30"));

builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddCors(options
    => options.AddDefaultPolicy(policy
    => policy.AllowAnyOrigin()
             .AllowAnyHeader()
             .AllowAnyMethod()
    ));

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

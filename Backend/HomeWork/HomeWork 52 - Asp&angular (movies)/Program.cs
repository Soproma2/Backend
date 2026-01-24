using HomeWork_52___Asp_angular__movies_.Data;
using HomeWork_52___Asp_angular__movies_.Services.Movies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IMoviesService, MovieServices>();

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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

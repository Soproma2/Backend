using HomeWork_53___Social_System.Data;
using HomeWork_53___Social_System.Services.AuthServices;
using HomeWork_53___Social_System.Services.CommentServices;
using HomeWork_53___Social_System.Services.LikeServices;
using HomeWork_53___Social_System.Services.PostServices;
using HomeWork_53___Social_System.Services.UserServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(o=>o.UseSqlServer(@""));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<ICommentService,  CommentService>();
builder.Services.AddScoped<IAuthService,  AuthService>();


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

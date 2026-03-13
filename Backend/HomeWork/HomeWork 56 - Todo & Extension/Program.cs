using HomeWork_56___Todo___Extension.Data;
using HomeWork_56___Todo___Extension.Extension;
using HomeWork_56___Todo___Extension.Services.Auth;
using HomeWork_56___Todo___Extension.Services.ToDo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();


var app = builder.Build();

app.UseApplication();

app.Run();

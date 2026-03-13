using HomeWork_56___Todo___Extension.Data;
using HomeWork_56___Todo___Extension.Services.Auth;
using HomeWork_56___Todo___Extension.Services.ToDo;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_56___Todo___Extension.Extension
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddControllers();
            services.AddAuth();

            services.AddDefaultCors();
            services.AddDatabase();
            services.AddControllerServices();


            return services;
        }

        private static IServiceCollection AddControllerServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITodoService, TodoService>();


            return services;
        }

        private static IServiceCollection AddDefaultCors(this IServiceCollection services)
        {
            services.AddCors(o =>
            o.AddDefaultPolicy(p =>
            p.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            ));

            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services)
        {

            services.AddDbContext<DataContext>(o => o.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TODO;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30"));



            return services;
        }
    }
}

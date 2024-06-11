using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.Middlewares;

namespace WebAPI.Servicios
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<GlobalExceptionHandlingMiddleware>();
            services.AddCors(options =>
            {
                options.AddPolicy("NewPolicy", app =>
                {
                    app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            
            

            return services;
        }
    }
}

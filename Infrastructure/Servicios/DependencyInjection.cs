using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Datos;
using Domain.Primitivos;
using Domain.Usuarios;
using Infractructure.Persistencia;
using Infractructure.Persistencia.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infractructure.Servicios
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Database")));

            services.AddScoped<IApplicationDbContext>(sp => 
                sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork>(sp => 
                sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            return services;
        }
    }
}

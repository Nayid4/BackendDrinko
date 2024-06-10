using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Datos;
using Domain.CarritoDeCompras;
using Domain.Categoria;
using Domain.Direcciones;
using Domain.Pedidos;
using Domain.Primitivos;
using Domain.Productos;
using Domain.Usuarios;
using Infrastructure.Persistencia;
using Infrastructure.Persistencia.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Servicios
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
            services.AddScoped<IRepositorioProducto, RepositorioProducto>();
            services.AddScoped<IRepositorioPedido, RepositorioPedido>();
            services.AddScoped<IRepositorioDireccion, RepositorioDireccion>();
            services.AddScoped<IRepositorioCarritoDeCompras, RepositorioDeCarritoDeCompras>();
            services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
            services.AddScoped<IRepositorioProductoCarrito, RepositorioProductoCarrito>();

            return services;
        }
    }
}

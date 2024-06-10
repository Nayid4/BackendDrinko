using Domain.CarritoDeCompras;
using Domain.Categoria;
using Domain.Direcciones;
using Domain.Pedidos;
using Domain.Productos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Datos
{
    public interface IApplicationDbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<CarritoDeCompras> CarritosDeCompras { get; set; }
        public DbSet<ProductoCarrito> ProductoCarritos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ProductoPedido> ProductosPedido { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

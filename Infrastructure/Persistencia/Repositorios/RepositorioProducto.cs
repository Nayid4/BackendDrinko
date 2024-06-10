using Domain.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Repositorios
{
    public class RepositorioProducto : IRepositorioProducto
    {
        private readonly ApplicationDbContext _context;

        public RepositorioProducto(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Actualizar(Producto producto)
        {
            throw new NotImplementedException();
        }

        public async void Crear(Producto producto) => _context.Productos.Add(producto);

        public void Eliminar(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<Producto?> ListarPorId(ProductoId id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerificarExistencia(ProductoId id)
        {
            throw new NotImplementedException();
        }
    }
}

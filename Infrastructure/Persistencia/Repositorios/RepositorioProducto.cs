using Microsoft.EntityFrameworkCore;
using Domain.Productos;
using System;
using System.Collections.Generic;
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

        public void Crear(Producto producto) => _context.Productos.Add(producto);

        public void Eliminar(Producto producto) => _context.Productos.Remove(producto);

        public void Actualizar(Producto producto) => _context.Productos.Update(producto);

        public async Task<bool> VerificarExistencia(ProductoId id) => await _context.Productos.AnyAsync(p => p.Id == id);

        public async Task<Producto?> ListarPorId(ProductoId id) => await _context.Productos.SingleOrDefaultAsync(p => p.Id == id);

        public async Task<List<Producto>> ListarTodos() => await _context.Productos.ToListAsync();
    }
}

using Domain.CarritoDeCompras;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Repositorios
{
    public class RepositorioProductoCarrito : IRepositorioProductoCarrito
    {
        private readonly ApplicationDbContext _context;

        public RepositorioProductoCarrito(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Crear(ProductoCarrito producto) => _context.ProductoCarritos.Add(producto);

        public void Eliminar(ProductoCarrito producto) => _context.ProductoCarritos.Remove(producto);

        public void Actualizar(ProductoCarrito producto) => _context.ProductoCarritos.Update(producto);

        public async Task<bool> VerificarExistencia(ProductoCarritoId id) => await _context.ProductoCarritos.AnyAsync(p => p.Id == id);

        public async Task<ProductoCarrito?> ListarPorId(ProductoCarritoId id) => await _context.ProductoCarritos.SingleOrDefaultAsync(p => p.Id == id);

        public async Task<List<ProductoCarrito>> ListarTodos() => await _context.ProductoCarritos.ToListAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using Domain.CarritoDeCompras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Usuarios;

namespace Infrastructure.Persistencia.Repositorios
{
    public class RepositorioDeCarritoDeCompras : IRepositorioCarritoDeCompras
    {
        private readonly ApplicationDbContext _context;

        public RepositorioDeCarritoDeCompras(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Crear(CarritoDeCompra carritoDeCompras) => _context.CarritosDeCompras.Add(carritoDeCompras);

        public void Eliminar(CarritoDeCompra carritoDeCompras) => _context.CarritosDeCompras.Remove(carritoDeCompras);

        public void Actualizar(CarritoDeCompra carritoDeCompras) => _context.CarritosDeCompras.Update(carritoDeCompras);

        public async Task<bool> VerificarExistencia(CarritoDeComprasId id) => await _context.CarritosDeCompras.AnyAsync(c => c.Id == id);

        public async Task<CarritoDeCompra?> ListarPorId(CarritoDeComprasId id) => await _context.CarritosDeCompras
            .Include(c => c.ProductoCarritos)
            .SingleOrDefaultAsync(c => c.Id == id);

        public async Task<CarritoDeCompra?> ListarPorIdDeUsuario(UsuarioId id) => await _context.CarritosDeCompras
            .Include(c => c.ProductoCarritos)
            .SingleOrDefaultAsync(c => c.UsuarioId == id);

        public async Task<List<CarritoDeCompra>> ListarTodos() => await _context.CarritosDeCompras
            .Include(c => c.ProductoCarritos)
            .ToListAsync();

    }
}

using Microsoft.EntityFrameworkCore;
using Domain.CarritoDeCompras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Repositorios
{
    public class RepositorioDeCarritoDeCompras : IRepositorioCarritoDeCompras
    {
        private readonly ApplicationDbContext _context;

        public RepositorioDeCarritoDeCompras(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Crear(CarritoDeCompras carritoDeCompras) => _context.CarritosDeCompras.Add(carritoDeCompras);

        public void Eliminar(CarritoDeCompras carritoDeCompras) => _context.CarritosDeCompras.Remove(carritoDeCompras);

        public void Actualizar(CarritoDeCompras carritoDeCompras) => _context.CarritosDeCompras.Update(carritoDeCompras);

        public async Task<bool> VerificarExistencia(CarritoDeComprasId id) => await _context.CarritosDeCompras.AnyAsync(c => c.Id == id);

        public async Task<CarritoDeCompras?> ListarPorId(CarritoDeComprasId id) => await _context.CarritosDeCompras
            .Include(c => c.ProductoCarritos)
            .SingleOrDefaultAsync(c => c.Id == id);

        public async Task<List<CarritoDeCompras>> ListarTodos() => await _context.CarritosDeCompras
            .Include(c => c.ProductoCarritos)
            .ToListAsync();

    }
}

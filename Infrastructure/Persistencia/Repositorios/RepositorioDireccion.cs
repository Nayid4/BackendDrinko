using Microsoft.EntityFrameworkCore;
using Domain.Direcciones;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Repositorios
{
    public class RepositorioDireccion : IRepositorioDireccion
    {
        private readonly ApplicationDbContext _context;

        public RepositorioDireccion(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Crear(Direccion direccion) => _context.Direcciones.Add(direccion);

        public void Eliminar(Direccion direccion) => _context.Direcciones.Remove(direccion);

        public void Actualizar(Direccion direccion) => _context.Direcciones.Update(direccion);

        public async Task<bool> VerificarExistencia(DireccionId id) => await _context.Direcciones.AnyAsync(d => d.Id == id);

        public async Task<Direccion?> ListarPorId(DireccionId id) => await _context.Direcciones.SingleOrDefaultAsync(d => d.Id == id);

        public async Task<List<Direccion>> ListarTodos() => await _context.Direcciones.ToListAsync();
    }
}

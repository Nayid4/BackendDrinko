using Microsoft.EntityFrameworkCore;
using Domain.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Repositorios
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        private readonly ApplicationDbContext _context;

        public RepositorioCategoria(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Crear(Categoria categoria) => _context.Categorias.Add(categoria);

        public void Eliminar(Categoria categoria) => _context.Categorias.Remove(categoria);

        public void Actualizar(Categoria categoria) => _context.Categorias.Update(categoria);

        public async Task<bool> VerificarExistencia(CategoriaId id) => await _context.Categorias.AnyAsync(c => c.Id == id);

        public async Task<Categoria?> ListarPorId(CategoriaId id) => await _context.Categorias.SingleOrDefaultAsync(c => c.Id == id);

        public async Task<List<Categoria>> ListarTodos() => await _context.Categorias.ToListAsync();
    }
}

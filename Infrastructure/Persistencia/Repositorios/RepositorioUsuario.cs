using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly ApplicationDbContext _context;

        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Crear(Usuario usuario) => _context.Usuarios.Add(usuario);

        public void Eliminar(Usuario usuario) => _context.Usuarios.Remove(usuario);

        public void Actualizar(Usuario usuario) => _context.Usuarios.Update(usuario);

        public async Task<bool> VerificarExistencia(UsuarioId id) => await _context.Usuarios.AnyAsync(usuario => usuario.Id == id);

        public async Task<Usuario?> ListarPorId(UsuarioId id) => await _context.Usuarios.SingleOrDefaultAsync(usuario => usuario.Id == id);

        public async Task<List<Usuario>> ListarTodos() => await _context.Usuarios.ToListAsync();

    }
}

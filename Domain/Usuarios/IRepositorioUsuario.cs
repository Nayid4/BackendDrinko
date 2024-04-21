using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Usuarios
{
    public interface IRepositorioUsuario
    {
        Task<List<Usuario>> ListarTodos();
        Task<Usuario?> ListarPorId(UsuarioId id);
        Task<bool> VerificarExistencia(UsuarioId id);
        void Crear(Usuario usuario);
        void Actualizar(Usuario usuario);
        void Eliminar(Usuario usuario);
    }
}

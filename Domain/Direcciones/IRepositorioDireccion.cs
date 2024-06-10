using Domain.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Direcciones
{
    public interface IRepositorioDireccion
    {
        Task<List<Direccion>> ListarTodos();
        Task<Direccion?> ListarPorId(DireccionId id);
        Task<bool> VerificarExistencia(DireccionId id);
        void Crear(Direccion direccion);
        void Actualizar(Direccion direccion);
        void Eliminar(Direccion direccion);
    }
}

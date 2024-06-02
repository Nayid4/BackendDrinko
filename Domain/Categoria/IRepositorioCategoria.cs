using Domain.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categoria
{
    public interface IRepositorioCategoria
    {
        Task<List<Categoria>> ListarTodos();
        Task<Categoria?> ListarPorId(CategoriaId id);
        Task<bool> VerificarExistencia(CategoriaId id);
        void Crear(Categoria categoria);
        void Actualizar(Categoria categoria);
        void Eliminar(Categoria categoria);
    }
}

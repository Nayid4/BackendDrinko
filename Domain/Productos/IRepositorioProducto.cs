using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Productos
{
    public interface IRepositorioProducto
    {
        Task<List<Producto>> ListarTodos();
        Task<Producto?> ListarPorId(ProductoId id);
        Task<bool> VerificarExistencia(ProductoId id);
        void Crear(Producto producto);
        void Actualizar(Producto producto);
        void Eliminar(Producto producto);
    }
}

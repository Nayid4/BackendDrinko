using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CarritoDeCompras
{
    public interface IRepositorioProductoCarrito
    {
        Task<List<ProductoCarrito>> ListarTodos();
        Task<ProductoCarrito?> ListarPorId(ProductoCarrito id);
        Task<bool> VerificarExistencia(ProductoCarrito id);
        void Crear(ProductoCarrito producto);
        void Actualizar(ProductoCarrito producto);
        void Eliminar(ProductoCarrito producto);
    }
}

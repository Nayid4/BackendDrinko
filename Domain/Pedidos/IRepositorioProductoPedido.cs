using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pedidos
{
    public interface IRepositorioProductoPedido
    {
        Task<List<ProductoPedido>> ListarTodos();
        Task<ProductoPedido?> ListarPorId(ProductoPedido id);
        Task<bool> VerificarExistencia(ProductoPedido id);
        void Crear(ProductoPedido ProductoPedido);
        void Actualizar(ProductoPedido ProductoPedido);
        void Eliminar(ProductoPedido ProductoPedido);
    }
}

using Domain.Categoria;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CarritoDeCompras
{
    public interface IRepositorioCarritoDeCompras
    {
        Task<List<CarritoDeCompra>> ListarTodos();
        Task<CarritoDeCompra?> ListarPorId(CarritoDeComprasId id);
        Task<CarritoDeCompra?> ListarPorIdDeUsuario(UsuarioId id);
        Task<bool> VerificarExistencia(CarritoDeComprasId id);
        void Crear(CarritoDeCompra carritoDeCompras);
        void Actualizar(CarritoDeCompra carritoDeCompras);
        void Eliminar(CarritoDeCompra carritoDeCompras);
    }
}

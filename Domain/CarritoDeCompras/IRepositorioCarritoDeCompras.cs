using Domain.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CarritoDeCompras
{
    public interface IRepositorioCarritoDeCompras
    {
        Task<List<CarritoDeCompras>> ListarTodos();
        Task<CarritoDeCompras?> ListarPorId(CarritoDeComprasId id);
        Task<bool> VerificarExistencia(CarritoDeComprasId id);
        void Crear(CarritoDeCompras carritoDeCompras);
        void Actualizar(CarritoDeCompras carritoDeCompras);
        void Eliminar(CarritoDeCompras carritoDeCompras);
    }
}

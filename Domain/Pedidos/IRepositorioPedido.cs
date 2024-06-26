﻿using Domain.CarritoDeCompras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pedidos
{
    public interface IRepositorioPedido
    {
        Task<List<Pedido>> ListarTodos();
        Task<Pedido?> ListarPorId(PedidoId id);
        Task<bool> VerificarExistencia(PedidoId id);
        void Crear(Pedido Pedido);
        void Actualizar(Pedido Pedido);
        void Eliminar(Pedido Pedido);
    }
}

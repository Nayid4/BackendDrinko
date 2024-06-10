using Microsoft.EntityFrameworkCore;
using Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Repositorios
{
    public class RepositorioPedido : IRepositorioPedido
    {
        private readonly ApplicationDbContext _context;

        public RepositorioPedido(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Crear(Pedido pedido) => _context.Pedidos.Add(pedido);

        public void Eliminar(Pedido pedido) => _context.Pedidos.Remove(pedido);

        public void Actualizar(Pedido pedido) => _context.Pedidos.Update(pedido);

        public async Task<bool> VerificarExistencia(PedidoId id) => await _context.Pedidos.AnyAsync(p => p.Id == id);

        public async Task<Pedido?> ListarPorId(PedidoId id) => await _context.Pedidos.Include(p => p.ProductosPedido).SingleOrDefaultAsync(p => p.Id == id);

        public async Task<List<Pedido>> ListarTodos() => await _context.Pedidos.Include(p => p.ProductosPedido).ToListAsync();
    }
}

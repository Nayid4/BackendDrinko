using Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Repositorios
{
    public class RepositorioProductoPedido : IRepositorioProductoPedido
    {
        private readonly ApplicationDbContext _context;

        public RepositorioProductoPedido(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Crear(ProductoPedido productoPedido) => _context.ProductosPedido.Add(productoPedido);

        public void Eliminar(ProductoPedido productoPedido) => _context.ProductosPedido.Remove(productoPedido);

        public void Actualizar(ProductoPedido productoPedido) => _context.ProductosPedido.Update(productoPedido);

        public async Task<bool> VerificarExistencia(ProductoPedidoId id) => await _context.ProductosPedido.AnyAsync(pp => pp.Id == id);

        public async Task<ProductoPedido?> ListarPorId(ProductoPedidoId id) => await _context.ProductosPedido.SingleOrDefaultAsync(pp => pp.Id == id);

        public async Task<List<ProductoPedido>> ListarTodos() => await _context.ProductosPedido.ToListAsync();

        
    }
}

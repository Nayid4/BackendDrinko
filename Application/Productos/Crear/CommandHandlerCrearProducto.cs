using Domain.Direcciones;
using Domain.ObjetosDeValor;
using Domain.Primitivos;
using Domain.Usuarios;
using Domain.Direcciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Productos;
using Domain.Categoria;

namespace Application.Productos.Crear
{
    internal sealed class CommandHandlerCrearProducto : IRequestHandler<CommandCrearProducto, Unit>
    {
        private readonly IRepositorioProducto _repositorioProducto;
        private readonly IUnitOfWork _unitOfWork;

        public CommandHandlerCrearProducto(IRepositorioProducto repositorioProducto, IUnitOfWork unitOfWork)
        {
            _repositorioProducto = repositorioProducto ?? throw new ArgumentNullException(nameof(repositorioProducto));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(CommandCrearProducto command, CancellationToken cancellationToken)
        {
            
            if (string.IsNullOrEmpty(command.Nombre) || string.IsNullOrEmpty(command.Descripcion))
            {
                Error.Validation("Prdocuto", "Algunos campos estan vacios");
            }

            var producto = new Producto(
                new ProductoId(Guid.NewGuid()),
                command.Nombre,
                new CategoriaId(Guid.Parse(command.IdCategoria)),
                command.Imagen,
                command.Descripcion,
                command.Mililitros,
                command.GradosDeAlcohol,
                command.calificacion,
                command.Precio
            ); 

            _repositorioProducto.Crear(producto);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

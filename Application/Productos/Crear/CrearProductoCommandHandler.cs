﻿using Domain.Categoria;
using Domain.Primitivos;
using Domain.Productos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Productos.Crear
{
    internal sealed class CrearProductoCommandHandler : IRequestHandler<CrearProductoCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioProducto _repositorioProducto;
        private readonly IRepositorioCategoria _repositorioCategoria;
        private readonly IUnitOfWork _unitOfWork;

        public CrearProductoCommandHandler(IRepositorioProducto repositorioProducto, IRepositorioCategoria repositorioCategoria, IUnitOfWork unitOfWork)
        {
            _repositorioProducto = repositorioProducto ?? throw new ArgumentNullException(nameof(repositorioProducto));
            _repositorioCategoria = repositorioCategoria ?? throw new ArgumentNullException(nameof(repositorioCategoria));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CrearProductoCommand request, CancellationToken cancellationToken)
        {

            if (!await _repositorioCategoria.VerificarExistencia(new CategoriaId(request.CategoriaId)))
            {
                return Error.NotFound("Categoria.NoEncontrada", "No se encontró la categoría.");
            }

            var producto = new Producto(
                new ProductoId(Guid.NewGuid()),
                request.Nombre,
                new CategoriaId(request.CategoriaId),
                request.Imagen,
                request.Descripcion,
                request.Mililitros,
                request.GradosDeAlcohol,
                request.Calificacion,
                request.Precio
            );

            _repositorioProducto.Crear(producto);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

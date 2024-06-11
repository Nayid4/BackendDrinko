using MediatR;
using ErrorOr;
using System;

namespace Application.Productos.Actualizar
{
    public record ActualizarProductoCommand(
        Guid Id,
        string Nombre,
        Guid CategoriaId,
        string Imagen,
        string Descripcion,
        int Mililitros,
        float GradosDeAlcohol,
        float Calificacion,
        decimal Precio
    ) : IRequest<ErrorOr<Unit>>;
}

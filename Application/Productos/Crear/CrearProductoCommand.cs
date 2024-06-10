using Domain.Primitivos;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Productos.Crear
{
    public record CrearProductoCommand(
        string Nombre,
        Guid CategoriaId,
        string Imagen,
        string Descripcion,
        int Mililitros,
        float GradosDeAlcohol,
        float Calificacion,
        decimal Precio) : IRequest<ErrorOr<Unit>>;
}

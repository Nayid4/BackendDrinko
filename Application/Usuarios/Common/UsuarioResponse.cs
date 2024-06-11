using Domain.Direcciones;
using Domain.Usuarios;
using System;
using System.Collections.Generic;

namespace Application.Usuarios.Common
{
    public record UsuarioResponse(
        Guid Id,
        string Nombre,
        string Apellido,
        string Correo,
        string clave,
        string NumeroDeTelefono,
        RolUsuario Rol, // Agregar el campo Rol
        IReadOnlyList<DireccionResponse> Direcciones);

    public record DireccionResponse(
        Guid Id,
        string Linea1,
        string Linea2,
        string Ciudad,
        string Departamento,
        int CodigoPostal);

    public record DireccionCommand(
        string Linea1,
        string Linea2,
        string Ciudad,
        string Departamento,
        int CodigoPostal);
}

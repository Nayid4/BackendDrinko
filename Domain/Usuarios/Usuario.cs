using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Usuarios
{
    public sealed class Usuario
    {
        public UsuarioId Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string Apellido { get; private set; } = string.Empty;
        public string Correo { get; private set; } = string.Empty;
        public NumeroDeTelefono NumeroDeTelefono { get; private set; }
        public Direccion Direccion { get; private set; }

        public Usuario() { }

        public Usuario(UsuarioId id, string nombre, string apellido, string correo, NumeroDeTelefono numeroDeTelefono, Direccion direccion)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            NumeroDeTelefono = numeroDeTelefono;
            Direccion = direccion;
        }
    }
}

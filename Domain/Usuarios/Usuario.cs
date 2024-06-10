using Domain.CarritoDeCompras;
using Domain.Direcciones;
using Domain.Primitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Usuarios
{
    public sealed class Usuario : AggregateRoot
    {
        private readonly HashSet<Direccion> _direcciones = new();

        public UsuarioId Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string Apellido { get; private set; } = string.Empty;
        public string Correo { get; private set; } = string.Empty;
        public NumeroDeTelefono NumeroDeTelefono { get; private set; }
        public IReadOnlyList<Direccion> Direcciones => _direcciones.ToList();

        
        public Usuario() { }

        public Usuario(UsuarioId id, string nombre, string apellido, string correo, NumeroDeTelefono numeroDeTelefono, HashSet<Direccion> direcciones)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            NumeroDeTelefono = numeroDeTelefono;
            _direcciones = direcciones;
        }

        public static Usuario ActualizarUsuario(Guid id, string nombre, string apellido, string correo, NumeroDeTelefono numeroDeTelefono, HashSet<Direccion> direcciones)
        {
            return new Usuario(new UsuarioId(id), nombre, apellido, correo, numeroDeTelefono, direcciones);
        }

        public void AgregarDireccion(Direccion direccion)
        {
            if(direccion is null)
            {
                throw new ArgumentNullException(nameof(direccion));
            }

            _direcciones.Add(direccion);
        }

        public bool EliminarDireccion(DireccionId direccionId)
        {
            var direccion = _direcciones.FirstOrDefault(d => d.Id == direccionId);

            if (direccion is null)
            {
                return false;
            }

            return _direcciones.Remove(direccion);
        }

        public bool ActualizarDireccion(Direccion direccionActualizada)
        {
            if (direccionActualizada is null)
            {
                throw new ArgumentNullException(nameof(direccionActualizada));
            }

            var direccionExistente = _direcciones.FirstOrDefault(d => d.Id == direccionActualizada.Id);

            if (direccionExistente is null)
            {
                return false;
            }

            _direcciones.Remove(direccionExistente);
            _direcciones.Add(direccionActualizada);

            return true;
        }

    }
}

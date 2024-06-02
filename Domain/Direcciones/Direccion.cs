using Domain.Usuarios;

namespace Domain.Direcciones
{
    public partial record Direccion
    {
        public DireccionId Id { get; private set; }
        public UsuarioId UsuarioId { get; private set; }
        public string Linea1 { get; private set; }
        public string Linea2 { get; private set; }
        public string Ciudad { get; private set; }
        public string Estado { get; private set; }
        public string CodigoPostal { get; private set; }

        public Direccion(DireccionId id, UsuarioId usuarioId, string linea1, string linea2, string ciudad, string estado, string codigoPostal)
        {
            Id = id;
            UsuarioId = usuarioId;
            Linea1 = linea1;
            Linea2 = linea2;
            Ciudad = ciudad;
            Estado = estado;
            CodigoPostal = codigoPostal;
        }

        public static Direccion? Crear(UsuarioId usuarioId, string linea1, string linea2, string ciudad, string estado, string codigoPostal)
        {
            if (string.IsNullOrEmpty(linea1) ||
                string.IsNullOrEmpty(linea2) || string.IsNullOrEmpty(ciudad) ||
                string.IsNullOrEmpty(estado) || string.IsNullOrEmpty(codigoPostal))
            {
                return null;
            }

            return new Direccion(new DireccionId(Guid.NewGuid()), usuarioId, linea1, linea2, ciudad, estado, codigoPostal);
        }

    }
}



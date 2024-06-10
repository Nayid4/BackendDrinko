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
        public string Departamento { get; private set; }
        public int CodigoPostal { get; private set; }

        public Direccion(DireccionId id, UsuarioId usuarioId, string linea1, string linea2, string ciudad, string departamento, int codigoPostal)
        {
            Id = id;
            UsuarioId = usuarioId;
            Linea1 = linea1;
            Linea2 = linea2;
            Ciudad = ciudad;
            Departamento = departamento;
            CodigoPostal = codigoPostal;
        }

        public static Direccion? Crear(UsuarioId usuarioId, string linea1, string linea2, string ciudad, string departamento, int codigoPostal)
        {
            if (string.IsNullOrEmpty(linea1) ||
                string.IsNullOrEmpty(linea2) || string.IsNullOrEmpty(ciudad) ||
                string.IsNullOrEmpty(departamento))
            {
                return null;
            }

            return new Direccion(new DireccionId(Guid.NewGuid()), usuarioId, linea1, linea2, ciudad, departamento, codigoPostal);
        }

    }
}



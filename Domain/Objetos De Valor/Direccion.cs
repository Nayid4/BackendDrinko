namespace Namespace.ValueObjects;

public partial record Direccion
{
    
    public string Pais { get; init; }
    public string Linea1 { get; init; }
    public string Linea2 { get; init; }
    public string Ciudad { get; init; }
    public string Estado { get; init; }
    public string CodigoPostal { get; init; }

    public Direccion(string pais, string linea1, string linea2, string ciudad, string estado, string codigoPostal)
    {
        Pais = pais;
        Linea1 = linea1;
        Linea2 = linea2;
        Ciudad = ciudad;
        Estado = estado;
        CodigoPostal = codigoPostal;
    }

    public static Direccion? Crear(string pais, string linea1, string linea2, string ciudad, string estado, string codigoPostal)
    {
        if(string.IsNullOrEmpty(pais) || string.IsNullOrEmpty(linea1) ||
            string.IsNullOrEmpty(linea2) || string.IsNullOrEmpty(ciudad) ||
            string.IsNullOrEmpty(estado) || string.IsNullOrEmpty(codigoPostal))
        {
            return null;
        }

        return new Direccion(pais, linea1, linea2, ciudad, estado, codigoPostal);
    }

}

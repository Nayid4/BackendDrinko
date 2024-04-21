
namespace Domain.ObjetosDeValor
{
    public partial record NumeroDeTelefono
    {
        private const int tamano = 10;
        private const string filtro = @"^(?:-*\d-*){10}$";
        private NumeroDeTelefono(string valor) => Valor = valor;

        public static NumeroDeTelefono? Crear(string valor)
        {
            if (string.IsNullOrEmpty(valor) /*|| !PhoneNumberRegex().IsMatch(valor)*/ || valor.Length != tamano)
            {
                return null;
            }
            return new NumeroDeTelefono(valor);
        }

        public string Valor { get; init; }

        /*[GeneratedRegex(filtro)]
        private static partial Regex PhoneNumberRegex();*/
    }
}



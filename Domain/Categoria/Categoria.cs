using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Categoria
{
    public sealed class Categoria
    {
        public CategoriaId Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;

        public Categoria()
        {
        }

        public Categoria(CategoriaId id, string nombre)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Nombre = !string.IsNullOrEmpty(nombre) ? nombre : throw new ArgumentNullException(nameof(nombre));
        }
    }
}

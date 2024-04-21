using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Datos
{
    public interface IApplicationDbContext
    {
        DbSet<Usuario> Usuarios { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

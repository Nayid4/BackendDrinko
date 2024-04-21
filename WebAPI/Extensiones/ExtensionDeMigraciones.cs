using Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Extensiones
{
    public static class ExtensionDeMigraciones
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }
    }
}

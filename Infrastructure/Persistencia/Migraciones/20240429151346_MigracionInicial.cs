using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NumeroDeTelefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Direccion_Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion_Linea1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion_Linea2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Direccion_Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion_Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion_CodigoPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Correo",
                table: "Usuarios",
                column: "Correo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackClub.Migrations
{
    /// <inheritdoc />
    public partial class inicioBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "deportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hora = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deportes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "deportistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApellidoNombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeporteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deportistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deportistas_deportes_DeporteId",
                        column: x => x.DeporteId,
                        principalTable: "deportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "profesores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeporteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profesores_deportes_DeporteId",
                        column: x => x.DeporteId,
                        principalTable: "deportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cuotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EstadoPago = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeportistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cuotas_deportistas_DeportistaId",
                        column: x => x.DeportistaId,
                        principalTable: "deportistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "deportes",
                columns: new[] { "Id", "Descripcion", "Hora", "Nombre" },
                values: new object[,]
                {
                    { 1, "Deporte de equipo", new TimeSpan(0, 18, 0, 0, 0), "Fútbol" },
                    { 2, "Deporte de equipo", new TimeSpan(0, 19, 0, 0, 0), "Basquetbol" },
                    { 3, "Deporte individual", new TimeSpan(0, 17, 0, 0, 0), "Natación" }
                });

            migrationBuilder.InsertData(
                table: "deportistas",
                columns: new[] { "Id", "ApellidoNombre", "DeporteId", "Direccion", "Eliminado", "Email", "Telefono" },
                values: new object[,]
                {
                    { 1, "Carlos López", 1, "Calle Falsa 123", false, "carlos@example.com", "321654987" },
                    { 2, "María Fernández", 2, "Avenida Siempre Viva 742", false, "maria@example.com", "654987321" },
                    { 3, "Pedro Sánchez", 3, "Boulevard de los Sueños Rotos", false, "pedro@example.com", "789321654" }
                });

            migrationBuilder.InsertData(
                table: "profesores",
                columns: new[] { "Id", "Apellido", "DeporteId", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Molina", 1, "Marcelo", "123456789" },
                    { 2, "Giunta", 2, "Renzo", "987654321" },
                    { 3, "Valiente", 3, "Camila", "456123789" }
                });

            migrationBuilder.InsertData(
                table: "cuotas",
                columns: new[] { "Id", "DeportistaId", "EstadoPago", "FechaPago", "Monto" },
                values: new object[,]
                {
                    { 1, 1, "pagado", new DateTime(2024, 9, 15, 9, 1, 44, 897, DateTimeKind.Local).AddTicks(8064), 50.00m },
                    { 2, 2, "pendiente", new DateTime(2024, 8, 15, 9, 1, 44, 897, DateTimeKind.Local).AddTicks(8083), 50.00m },
                    { 3, 3, "pagado", new DateTime(2024, 9, 15, 9, 1, 44, 897, DateTimeKind.Local).AddTicks(8085), 50.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cuotas_DeportistaId",
                table: "cuotas",
                column: "DeportistaId");

            migrationBuilder.CreateIndex(
                name: "IX_deportistas_DeporteId",
                table: "deportistas",
                column: "DeporteId");

            migrationBuilder.CreateIndex(
                name: "IX_profesores_DeporteId",
                table: "profesores",
                column: "DeporteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cuotas");

            migrationBuilder.DropTable(
                name: "profesores");

            migrationBuilder.DropTable(
                name: "deportistas");

            migrationBuilder.DropTable(
                name: "deportes");
        }
    }
}

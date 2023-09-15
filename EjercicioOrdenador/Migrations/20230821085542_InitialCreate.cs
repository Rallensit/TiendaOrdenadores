using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EjercicioOrdenador.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Calor = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Cores = table.Column<int>(type: "int", nullable: false),
                    Megas = table.Column<long>(type: "bigint", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    OrdenadorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componentes_Ordenadores_OrdenadorId",
                        column: x => x.OrdenadorId,
                        principalTable: "Ordenadores",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Componentes",
                columns: new[] { "Id", "Calor", "Cores", "Description", "Megas", "OrdenadorId", "Precio", "Serie", "Tipo" },
                values: new object[,]
                {
                    { 2, 12, 10, "Procesador Intel i7", 0L, null, 138.0, "789-XCD", 0 },
                    { 3, 22, 11, "Procesador Intel i7", 0L, null, 138.0, "789-XCT", 0 },
                    { 5, 15, 0, "Banco de Memoria SDRAM", 1024L, null, 125.0, "879FH-L", 1 },
                    { 8, 29, 0, "DiscoDuro SanDisk", 1024000L, null, 90.0, "789-XX-2", 2 },
                    { 10, 30, 10, "Procesador Ryzen AMD", 0L, null, 78.0, "797-X", 0 },
                    { 11, 30, 29, "Procesador Ryzen AMD", 0L, null, 178.0, "797-X2", 0 },
                    { 13, 35, 0, "Disco Mecánico Patatin", 250L, null, 37.0, "788-fg", 2 },
                    { 14, 35, 0, "Disco Mecánico Patatin", 250L, null, 67.0, "788-fg-2", 2 },
                    { 15, 35, 0, "Disco Mecánico Patatin", 250L, null, 97.0, "788-fg-3", 2 },
                    { 16, 10, 0, "Disco Externo Sam", 9216000L, null, 134.0, "1789-XCS", 2 },
                    { 17, 12, 0, "Disco Externo Sam", 10240000L, null, 138.0, "1789-XCD", 2 },
                    { 18, 22, 0, "Disco Externo Sam", 11264000L, null, 140.0, "1789-XCT", 2 }
                });

            migrationBuilder.InsertData(
                table: "Ordenadores",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Ordenador Maria" },
                    { 2, "Ordenador Andres" }
                });

            migrationBuilder.InsertData(
                table: "Componentes",
                columns: new[] { "Id", "Calor", "Cores", "Description", "Megas", "OrdenadorId", "Precio", "Serie", "Tipo" },
                values: new object[,]
                {
                    { 1, 10, 9, "Procesador Intel i7", 0L, 1, 134.0, "789-XCS", 0 },
                    { 4, 10, 0, "Banco de Memoria SDRAM", 512L, 1, 100.0, "879FH", 1 },
                    { 6, 24, 0, "Banco de Memoria SDRAM", 2048L, 2, 150.0, "879FH-T", 1 },
                    { 7, 10, 0, "DiscoDuro SanDisk", 512000L, 1, 50.0, "789-XX", 2 },
                    { 9, 39, 0, "DiscoDuro SanDisk", 2048000L, 2, 128.0, "789-XX-3", 2 },
                    { 12, 60, 34, "Procesador Ryzen AMD", 0L, 2, 278.0, "797-X3", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_OrdenadorId",
                table: "Componentes",
                column: "OrdenadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Componentes");

            migrationBuilder.DropTable(
                name: "Ordenadores");
        }
    }
}

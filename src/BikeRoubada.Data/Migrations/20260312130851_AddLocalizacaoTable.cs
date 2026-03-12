using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace BikeRoubada.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalizacaoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localizacao",
                table: "Roubos");

            migrationBuilder.AddColumn<Guid>(
                name: "IdLocalizacao",
                table: "Roubos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "Localizacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Rua = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Coordenadas = table.Column<Point>(type: "point", nullable: false),
                    RouboId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localizacao_Roubos_RouboId",
                        column: x => x.RouboId,
                        principalTable: "Roubos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Roubos_IdLocalizacao",
                table: "Roubos",
                column: "IdLocalizacao");

            migrationBuilder.CreateIndex(
                name: "IX_Localizacao_RouboId",
                table: "Localizacao",
                column: "RouboId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roubos_Localizacao_IdLocalizacao",
                table: "Roubos",
                column: "IdLocalizacao",
                principalTable: "Localizacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roubos_Localizacao_IdLocalizacao",
                table: "Roubos");

            migrationBuilder.DropTable(
                name: "Localizacao");

            migrationBuilder.DropIndex(
                name: "IX_Roubos_IdLocalizacao",
                table: "Roubos");

            migrationBuilder.DropColumn(
                name: "IdLocalizacao",
                table: "Roubos");

            migrationBuilder.AddColumn<Point>(
                name: "Localizacao",
                table: "Roubos",
                type: "point",
                nullable: false);
        }
    }
}

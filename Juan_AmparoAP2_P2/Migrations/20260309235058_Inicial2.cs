using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Juan_AmparoAP2_P2.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    BalancePuntos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.EstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "TiposPuntos",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorPuntos = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPuntos", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "AsignacionesPuntos",
                columns: table => new
                {
                    IdAsignacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    TotalPuntos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionesPuntos", x => x.IdAsignacion);
                    table.ForeignKey(
                        name: "FK_AsignacionesPuntos_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsignacionesPuntosDetalle",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAsignacion = table.Column<int>(type: "int", nullable: false),
                    TipoPuntoId = table.Column<int>(type: "int", nullable: false),
                    CantidadPuntos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionesPuntosDetalle", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_AsignacionesPuntosDetalle_AsignacionesPuntos_IdAsignacion",
                        column: x => x.IdAsignacion,
                        principalTable: "AsignacionesPuntos",
                        principalColumn: "IdAsignacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estudiantes",
                columns: new[] { "EstudianteId", "BalancePuntos", "Edad", "Email", "Nombres" },
                values: new object[,]
                {
                    { 1, 0, 20, "ana@universidad.edu", "Ana Martinez" },
                    { 2, 0, 22, "carlos@universidad.edu", "Carlos Perez" },
                    { 3, 0, 21, "laura@universidad.edu", "Laura Rodriguez" }
                });

            migrationBuilder.InsertData(
                table: "TiposPuntos",
                columns: new[] { "TipoId", "Activo", "Color", "Descripcion", "Icono", "Nombre", "ValorPuntos" },
                values: new object[,]
                {
                    { 1, true, "primary", "Participacion en clase", "bi-hand-thumbs-up", "Participacion", 5 },
                    { 2, true, "success", "Entrega de tarea", "bi-journal-check", "Tarea Entregada", 10 },
                    { 3, true, "warning", "Entrega de proyecto", "bi-lightbulb", "Proyecto", 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesPuntos_EstudianteId",
                table: "AsignacionesPuntos",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesPuntosDetalle_IdAsignacion",
                table: "AsignacionesPuntosDetalle",
                column: "IdAsignacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignacionesPuntosDetalle");

            migrationBuilder.DropTable(
                name: "TiposPuntos");

            migrationBuilder.DropTable(
                name: "AsignacionesPuntos");

            migrationBuilder.DropTable(
                name: "Estudiantes");
        }
    }
}

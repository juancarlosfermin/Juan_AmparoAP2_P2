using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Juan_AmparoAP2_P2.Migrations
{
    /// <inheritdoc />
    public partial class Inicial23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Estudiantes",
                keyColumn: "EstudianteId",
                keyValue: 1,
                column: "Email",
                value: "ana@yomail.com");

            migrationBuilder.UpdateData(
                table: "Estudiantes",
                keyColumn: "EstudianteId",
                keyValue: 2,
                column: "Email",
                value: "carlos@yopmail.com");

            migrationBuilder.UpdateData(
                table: "Estudiantes",
                keyColumn: "EstudianteId",
                keyValue: 3,
                column: "Email",
                value: "laura@yopmail.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Estudiantes",
                keyColumn: "EstudianteId",
                keyValue: 1,
                column: "Email",
                value: "ana@universidad.edu");

            migrationBuilder.UpdateData(
                table: "Estudiantes",
                keyColumn: "EstudianteId",
                keyValue: 2,
                column: "Email",
                value: "carlos@universidad.edu");

            migrationBuilder.UpdateData(
                table: "Estudiantes",
                keyColumn: "EstudianteId",
                keyValue: 3,
                column: "Email",
                value: "laura@universidad.edu");
        }
    }
}

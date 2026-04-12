using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutoriasGratuitas.Migrations
{
    /// <inheritdoc />
    public partial class CorrigiendoNombreDeTutores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tutorres",
                table: "Tutorres");

            migrationBuilder.RenameTable(
                name: "Tutorres",
                newName: "Tutores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tutores",
                table: "Tutores",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tutores",
                table: "Tutores");

            migrationBuilder.RenameTable(
                name: "Tutores",
                newName: "Tutorres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tutorres",
                table: "Tutorres",
                column: "Id");
        }
    }
}

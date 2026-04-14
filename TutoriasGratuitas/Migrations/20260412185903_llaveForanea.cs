using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutoriasGratuitas.Migrations
{
    /// <inheritdoc />
    public partial class llaveForanea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MateriaId",
                table: "Tutores",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tutores_MateriaId",
                table: "Tutores",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tutores_Materias_MateriaId",
                table: "Tutores",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tutores_Materias_MateriaId",
                table: "Tutores");

            migrationBuilder.DropIndex(
                name: "IX_Tutores_MateriaId",
                table: "Tutores");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "Tutores");
        }
    }
}

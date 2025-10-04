using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PONCE_PARCIAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class CatalogoCursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matriculas_CursoId_UsuarioId",
                table: "Matriculas");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Curso_Creditos",
                table: "Cursos");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Curso_Horario",
                table: "Cursos");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_CursoId",
                table: "Matriculas",
                column: "CursoId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Creditos_Pos",
                table: "Cursos",
                sql: "Creditos > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Horario_Valido",
                table: "Cursos",
                sql: "HorarioInicio < HorarioFin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matriculas_CursoId",
                table: "Matriculas");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Creditos_Pos",
                table: "Cursos");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Horario_Valido",
                table: "Cursos");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_CursoId_UsuarioId",
                table: "Matriculas",
                columns: new[] { "CursoId", "UsuarioId" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Curso_Creditos",
                table: "Cursos",
                sql: "Creditos > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Curso_Horario",
                table: "Cursos",
                sql: "HorarioInicio < HorarioFin");
        }
    }
}

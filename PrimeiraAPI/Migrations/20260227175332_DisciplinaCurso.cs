using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeiraAPI.Migrations
{
    /// <inheritdoc />
    public partial class DisciplinaCurso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    DisciplinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargaHoraria = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.DisciplinaId);
                });

            migrationBuilder.CreateTable(
                name: "CursoDisciplina",
                columns: table => new
                {
                    CursosCursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisciplinasDisciplinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoDisciplina", x => new { x.CursosCursoId, x.DisciplinasDisciplinaId });
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Cursos_CursosCursoId",
                        column: x => x.CursosCursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Disciplina_DisciplinasDisciplinaId",
                        column: x => x.DisciplinasDisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "DisciplinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaCursos",
                columns: table => new
                {
                    DisciplinaCursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisciplinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaCursos", x => x.DisciplinaCursoId);
                    table.ForeignKey(
                        name: "FK_DisciplinaCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaCursos_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "DisciplinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoDisciplina_DisciplinasDisciplinaId",
                table: "CursoDisciplina",
                column: "DisciplinasDisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaCursos_CursoId",
                table: "DisciplinaCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaCursos_DisciplinaId",
                table: "DisciplinaCursos",
                column: "DisciplinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoDisciplina");

            migrationBuilder.DropTable(
                name: "DisciplinaCursos");

            migrationBuilder.DropTable(
                name: "Disciplina");
        }
    }
}

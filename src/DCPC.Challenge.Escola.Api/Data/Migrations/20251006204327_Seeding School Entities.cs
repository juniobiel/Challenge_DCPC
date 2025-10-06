using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DCPC.Challenge.Escola.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingSchoolEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataNascimento", "Email", "Nome" },
                values: new object[,]
                {
                    { new Guid("11111111-2222-3333-4444-555555555501"), true, new DateOnly(2007, 1, 15), "joao.silva@email.com", "João Silva" },
                    { new Guid("11111111-2222-3333-4444-555555555502"), true, new DateOnly(2006, 6, 20), "maria.oliveira@email.com", "Maria Oliveira" },
                    { new Guid("11111111-2222-3333-4444-555555555503"), true, new DateOnly(2005, 11, 5), "lia.santos@email.com", "Lia Santos" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "CargaHoraria", "Nome" },
                values: new object[,]
                {
                    { new Guid("7b4a9d1e-0f4a-4f4e-9b13-0b5f3b7d2a02"), 60, "Matemática Básica" },
                    { new Guid("f2f9f3b3-8f55-4f1f-9f7b-2f2b3f9a1a01"), 80, ".NET Fundamentals" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Email", "Nome" },
                values: new object[,]
                {
                    { new Guid("0f1e2d3c-4b5a-6978-9a0b-1c2d3e4f5a04"), "roberto.lima@escola.com", "Roberto Lima" },
                    { new Guid("a1c2d3e4-f5a6-47b8-9c0d-1e2f3a4b5c03"), "ana.souza@escola.com", "Ana Souza" }
                });

            migrationBuilder.InsertData(
                table: "Turmas",
                columns: new[] { "Id", "AnoLetivo", "CursoId", "Nome", "ProfessorId", "Semestre" },
                values: new object[,]
                {
                    { new Guid("22222222-3333-4444-5555-666666666601"), 2025, new Guid("f2f9f3b3-8f55-4f1f-9f7b-2f2b3f9a1a01"), "Prog Manhã 2025", new Guid("a1c2d3e4-f5a6-47b8-9c0d-1e2f3a4b5c03"), 1 },
                    { new Guid("22222222-3333-4444-5555-666666666602"), 2025, new Guid("7b4a9d1e-0f4a-4f4e-9b13-0b5f3b7d2a02"), "Math Tarde 2025", new Guid("0f1e2d3c-4b5a-6978-9a0b-1c2d3e4f5a04"), 1 },
                    { new Guid("22222222-3333-4444-5555-666666666603"), 2025, new Guid("f2f9f3b3-8f55-4f1f-9f7b-2f2b3f9a1a01"), "Prog Noite 2025", new Guid("0f1e2d3c-4b5a-6978-9a0b-1c2d3e4f5a04"), 2 }
                });

            migrationBuilder.InsertData(
                table: "Matriculas",
                columns: new[] { "Id", "AlunoId", "DataMatricula", "Status", "TurmaId" },
                values: new object[,]
                {
                    { new Guid("33333333-4444-5555-6666-777777777701"), new Guid("11111111-2222-3333-4444-555555555501"), new DateOnly(2025, 2, 10), 1, new Guid("22222222-3333-4444-5555-666666666601") },
                    { new Guid("33333333-4444-5555-6666-777777777702"), new Guid("11111111-2222-3333-4444-555555555502"), new DateOnly(2025, 2, 12), 1, new Guid("22222222-3333-4444-5555-666666666601") },
                    { new Guid("33333333-4444-5555-6666-777777777703"), new Guid("11111111-2222-3333-4444-555555555502"), new DateOnly(2025, 2, 15), 1, new Guid("22222222-3333-4444-5555-666666666602") },
                    { new Guid("33333333-4444-5555-6666-777777777704"), new Guid("11111111-2222-3333-4444-555555555503"), new DateOnly(2025, 2, 18), 1, new Guid("22222222-3333-4444-5555-666666666602") }
                });

            migrationBuilder.InsertData(
                table: "Notas",
                columns: new[] { "Id", "Avaliacao", "Data", "MatriculaId", "Valor" },
                values: new object[,]
                {
                    { new Guid("44444444-5555-6666-7777-888888888801"), "Prova 1", new DateOnly(2025, 3, 10), new Guid("33333333-4444-5555-6666-777777777701"), 8.5m },
                    { new Guid("44444444-5555-6666-7777-888888888802"), "Prova 2", new DateOnly(2025, 4, 5), new Guid("33333333-4444-5555-6666-777777777701"), 7.0m },
                    { new Guid("44444444-5555-6666-7777-888888888803"), "Prova 1", new DateOnly(2025, 3, 10), new Guid("33333333-4444-5555-6666-777777777702"), 9.2m },
                    { new Guid("44444444-5555-6666-7777-888888888804"), "Trabalho 1", new DateOnly(2025, 3, 25), new Guid("33333333-4444-5555-6666-777777777703"), 10.0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Matriculas",
                keyColumn: "Id",
                keyValue: new Guid("33333333-4444-5555-6666-777777777704"));

            migrationBuilder.DeleteData(
                table: "Notas",
                keyColumn: "Id",
                keyValue: new Guid("44444444-5555-6666-7777-888888888801"));

            migrationBuilder.DeleteData(
                table: "Notas",
                keyColumn: "Id",
                keyValue: new Guid("44444444-5555-6666-7777-888888888802"));

            migrationBuilder.DeleteData(
                table: "Notas",
                keyColumn: "Id",
                keyValue: new Guid("44444444-5555-6666-7777-888888888803"));

            migrationBuilder.DeleteData(
                table: "Notas",
                keyColumn: "Id",
                keyValue: new Guid("44444444-5555-6666-7777-888888888804"));

            migrationBuilder.DeleteData(
                table: "Turmas",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-4444-5555-666666666603"));

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: new Guid("11111111-2222-3333-4444-555555555503"));

            migrationBuilder.DeleteData(
                table: "Matriculas",
                keyColumn: "Id",
                keyValue: new Guid("33333333-4444-5555-6666-777777777701"));

            migrationBuilder.DeleteData(
                table: "Matriculas",
                keyColumn: "Id",
                keyValue: new Guid("33333333-4444-5555-6666-777777777702"));

            migrationBuilder.DeleteData(
                table: "Matriculas",
                keyColumn: "Id",
                keyValue: new Guid("33333333-4444-5555-6666-777777777703"));

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: new Guid("11111111-2222-3333-4444-555555555501"));

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: new Guid("11111111-2222-3333-4444-555555555502"));

            migrationBuilder.DeleteData(
                table: "Turmas",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-4444-5555-666666666601"));

            migrationBuilder.DeleteData(
                table: "Turmas",
                keyColumn: "Id",
                keyValue: new Guid("22222222-3333-4444-5555-666666666602"));

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "Id",
                keyValue: new Guid("7b4a9d1e-0f4a-4f4e-9b13-0b5f3b7d2a02"));

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "Id",
                keyValue: new Guid("f2f9f3b3-8f55-4f1f-9f7b-2f2b3f9a1a01"));

            migrationBuilder.DeleteData(
                table: "Professores",
                keyColumn: "Id",
                keyValue: new Guid("0f1e2d3c-4b5a-6978-9a0b-1c2d3e4f5a04"));

            migrationBuilder.DeleteData(
                table: "Professores",
                keyColumn: "Id",
                keyValue: new Guid("a1c2d3e4-f5a6-47b8-9c0d-1e2f3a4b5c03"));
        }
    }
}

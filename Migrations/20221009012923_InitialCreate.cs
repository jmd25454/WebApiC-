using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Internamentos",
                columns: table => new
                {
                    InternamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Competencia = table.Column<string>(type: "TEXT", nullable: true),
                    DataInt = table.Column<string>(type: "TEXT", nullable: true),
                    DataAlta = table.Column<string>(type: "TEXT", nullable: true),
                    Leito = table.Column<string>(type: "TEXT", nullable: true),
                    CID = table.Column<string>(type: "TEXT", nullable: true),
                    Carater_Atendimento = table.Column<string>(type: "TEXT", nullable: true),
                    Motivo_Encerramento = table.Column<string>(type: "TEXT", nullable: true),
                    PacienteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internamentos", x => x.InternamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    DataNasc = table.Column<string>(type: "TEXT", nullable: true),
                    Sexo = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteId);
                });

            migrationBuilder.CreateTable(
                name: "Procedimentos",
                columns: table => new
                {
                    ProcedimentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Medico = table.Column<string>(type: "TEXT", nullable: true),
                    MedicoCBO = table.Column<string>(type: "TEXT", nullable: true),
                    Codigo_Procedimento = table.Column<string>(type: "TEXT", nullable: true),
                    DescProcedimento = table.Column<string>(type: "TEXT", nullable: true),
                    QtdProcedimento = table.Column<int>(type: "INTEGER", nullable: false),
                    PacienteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimentos", x => x.ProcedimentoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Internamentos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Procedimentos");
        }
    }
}

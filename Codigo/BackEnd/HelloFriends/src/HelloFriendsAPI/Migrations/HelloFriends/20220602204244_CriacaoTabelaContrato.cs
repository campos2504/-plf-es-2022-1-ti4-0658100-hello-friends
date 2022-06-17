using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    public partial class CriacaoTabelaContrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeResponsavel = table.Column<string>(nullable: true),
                    Nacionalidade = table.Column<string>(nullable: true),
                    EstadoCivil = table.Column<string>(nullable: true),
                    Profissao = table.Column<string>(nullable: true),
                    Ci = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    NomeAluno = table.Column<string>(nullable: true),
                    DiaAula = table.Column<string>(nullable: true),
                    Horario = table.Column<string>(nullable: true),
                    CargaHorariaSemanal = table.Column<string>(nullable: true),
                    ValorMensalidade = table.Column<double>(nullable: false),
                    ValorExtensoMensalidade = table.Column<string>(nullable: true),
                    DataInicioContrato = table.Column<DateTime>(nullable: false),
                    DataFinalContrato = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrato");
        }
    }
}

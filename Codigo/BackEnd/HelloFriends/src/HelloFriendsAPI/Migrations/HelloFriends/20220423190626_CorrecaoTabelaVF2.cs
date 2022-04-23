using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    public partial class CorrecaoTabelaVF2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespotasVF");

            migrationBuilder.CreateTable(
                name: "RespostasVF",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Resultado = table.Column<double>(nullable: false),
                    AlunoId = table.Column<long>(nullable: false),
                    MId = table.Column<long>(nullable: false),
                    CompletaFraseID = table.Column<Guid>(nullable: false),
                    VerdadeiroFalsoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostasVF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespostasVF_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespostasVF_VerdadeiroFalso_VerdadeiroFalsoId",
                        column: x => x.VerdadeiroFalsoId,
                        principalTable: "VerdadeiroFalso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RespostasVF_AlunoId",
                table: "RespostasVF",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasVF_VerdadeiroFalsoId",
                table: "RespostasVF",
                column: "VerdadeiroFalsoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespostasVF");

            migrationBuilder.CreateTable(
                name: "RespotasVF",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlunoId = table.Column<long>(nullable: false),
                    CompletaFraseID = table.Column<Guid>(nullable: false),
                    MId = table.Column<long>(nullable: false),
                    Resultado = table.Column<double>(nullable: false),
                    VerdadeiroFalsoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespotasVF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespotasVF_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespotasVF_VerdadeiroFalso_VerdadeiroFalsoId",
                        column: x => x.VerdadeiroFalsoId,
                        principalTable: "VerdadeiroFalso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RespotasVF_AlunoId",
                table: "RespotasVF",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespotasVF_VerdadeiroFalsoId",
                table: "RespotasVF",
                column: "VerdadeiroFalsoId");
        }
    }
}

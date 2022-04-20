using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    public partial class TabelaRespostaCompletaFrase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RespostasCompleFrase",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Resposta = table.Column<bool>(nullable: false),
                    AlunoId = table.Column<long>(nullable: false),
                    CompletaFraseID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostasCompleFrase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespostasCompleFrase_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespostasCompleFrase_CompletaFrase_CompletaFraseID",
                        column: x => x.CompletaFraseID,
                        principalTable: "CompletaFrase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RespostasCompleFrase_AlunoId",
                table: "RespostasCompleFrase",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasCompleFrase_CompletaFraseID",
                table: "RespostasCompleFrase",
                column: "CompletaFraseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespostasCompleFrase");
        }
    }
}

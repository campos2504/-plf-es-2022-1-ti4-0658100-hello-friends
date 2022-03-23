using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    public partial class AddAtividadeCompletaFrase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompletaFrase",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Imagem = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    ModuloId = table.Column<long>(nullable: false),
                    Enunciado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletaFrase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletaFrase_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PalavraChave",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    AtividadeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalavraChave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PalavraChave_CompletaFrase_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "CompletaFrase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletaFrase_ModuloId",
                table: "CompletaFrase",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_PalavraChave_AtividadeId",
                table: "PalavraChave",
                column: "AtividadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalavraChave");

            migrationBuilder.DropTable(
                name: "CompletaFrase");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    public partial class ExclusaoTabelaPalavraChave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalavraChave");

            migrationBuilder.AddColumn<string>(
                name: "PalavrasChave",
                table: "CompletaFrase",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PalavrasChave",
                table: "CompletaFrase");

            migrationBuilder.CreateTable(
                name: "PalavraChave",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AtividadeId = table.Column<Guid>(nullable: true),
                    Texto = table.Column<string>(nullable: true)
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
                name: "IX_PalavraChave_AtividadeId",
                table: "PalavraChave",
                column: "AtividadeId");
        }
    }
}

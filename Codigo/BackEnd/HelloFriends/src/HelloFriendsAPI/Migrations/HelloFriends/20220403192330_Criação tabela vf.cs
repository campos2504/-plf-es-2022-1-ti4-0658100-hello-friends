using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    public partial class Criaçãotabelavf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VerdadeiroFalso",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Imagem = table.Column<string>(nullable: true),
                    ModuloId = table.Column<long>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Texto = table.Column<string>(nullable: true),
                    Video = table.Column<string>(nullable: true),
                    Pergunta = table.Column<string>(nullable: true),
                    AlternativaCerta = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerdadeiroFalso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerdadeiroFalso_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VerdadeiroFalso_ModuloId",
                table: "VerdadeiroFalso",
                column: "ModuloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerdadeiroFalso");
        }
    }
}

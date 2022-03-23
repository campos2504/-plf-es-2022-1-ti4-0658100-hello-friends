using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    public partial class AdicaoAtividadeOpcaoCerta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OpcaoCerta",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Imagem = table.Column<string>(nullable: true),
                    ModuloId = table.Column<long>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    Video = table.Column<string>(nullable: true),
                    Pergunta = table.Column<string>(nullable: true),
                    AlternativaA = table.Column<string>(nullable: true),
                    AlternativaB = table.Column<string>(nullable: true),
                    AlternativaC = table.Column<string>(nullable: true),
                    AlternativaD = table.Column<string>(nullable: true),
                    AlternativaCerta = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcaoCerta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcaoCerta_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpcaoCerta_ModuloId",
                table: "OpcaoCerta",
                column: "ModuloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpcaoCerta");
        }
    }
}

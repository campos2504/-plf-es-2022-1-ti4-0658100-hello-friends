using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    public partial class CriacaoTabelaMedalha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medalha",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlunoId = table.Column<long>(nullable: false),
                    ModuloId = table.Column<long>(nullable: false),
                    TipoMedalha = table.Column<string>(nullable: true),
                    ModuloConcluido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medalha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medalha_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medalha_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medalha_AlunoId",
                table: "Medalha",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medalha_ModuloId",
                table: "Medalha",
                column: "ModuloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medalha");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    public partial class CorrecaoColunaPalavraChave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PalavrasChave",
                table: "CompletaFrase",
                newName: "PalavrasChaves");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PalavrasChaves",
                table: "CompletaFrase",
                newName: "PalavrasChave");
        }
    }
}

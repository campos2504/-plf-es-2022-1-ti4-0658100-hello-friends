using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    public partial class CorrecaoTabelaRespostaCFrase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resposta",
                table: "RespostasCompleFrase");

            migrationBuilder.AddColumn<long>(
                name: "MId",
                table: "RespostasCompleFrase",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MId",
                table: "RespostasCompleFrase");

            migrationBuilder.AddColumn<string>(
                name: "Resposta",
                table: "RespostasCompleFrase",
                nullable: true);
        }
    }
}

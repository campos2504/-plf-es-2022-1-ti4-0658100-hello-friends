using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    public partial class CorrecaoTabelaResposta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Resposta",
                table: "RespostasCompleFrase",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<double>(
                name: "Resultado",
                table: "RespostasCompleFrase",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resultado",
                table: "RespostasCompleFrase");

            migrationBuilder.AlterColumn<bool>(
                name: "Resposta",
                table: "RespostasCompleFrase",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

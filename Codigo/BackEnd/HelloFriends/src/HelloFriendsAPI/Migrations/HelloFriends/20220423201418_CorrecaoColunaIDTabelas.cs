using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    public partial class CorrecaoColunaIDTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostasCompletaTexto_CompletaTexto_CompletaTextoId",
                table: "RespostasCompletaTexto");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostasOpcaoCerta_OpcaoCerta_OpcaoCertaId",
                table: "RespostasOpcaoCerta");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostasVF_VerdadeiroFalso_VerdadeiroFalsoId",
                table: "RespostasVF");

            migrationBuilder.DropColumn(
                name: "CompletaFraseID",
                table: "RespostasVF");

            migrationBuilder.DropColumn(
                name: "CompletaFraseID",
                table: "RespostasOpcaoCerta");

            migrationBuilder.DropColumn(
                name: "CompletaFraseID",
                table: "RespostasCompletaTexto");

            migrationBuilder.RenameColumn(
                name: "VerdadeiroFalsoId",
                table: "RespostasVF",
                newName: "VerdadeiroFalsoID");

            migrationBuilder.RenameIndex(
                name: "IX_RespostasVF_VerdadeiroFalsoId",
                table: "RespostasVF",
                newName: "IX_RespostasVF_VerdadeiroFalsoID");

            migrationBuilder.RenameColumn(
                name: "OpcaoCertaId",
                table: "RespostasOpcaoCerta",
                newName: "OpcaoCertaID");

            migrationBuilder.RenameIndex(
                name: "IX_RespostasOpcaoCerta_OpcaoCertaId",
                table: "RespostasOpcaoCerta",
                newName: "IX_RespostasOpcaoCerta_OpcaoCertaID");

            migrationBuilder.RenameColumn(
                name: "CompletaTextoId",
                table: "RespostasCompletaTexto",
                newName: "CompletaTextoID");

            migrationBuilder.RenameIndex(
                name: "IX_RespostasCompletaTexto_CompletaTextoId",
                table: "RespostasCompletaTexto",
                newName: "IX_RespostasCompletaTexto_CompletaTextoID");

            migrationBuilder.AlterColumn<Guid>(
                name: "VerdadeiroFalsoID",
                table: "RespostasVF",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OpcaoCertaID",
                table: "RespostasOpcaoCerta",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CompletaTextoID",
                table: "RespostasCompletaTexto",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasCompletaTexto_CompletaTexto_CompletaTextoID",
                table: "RespostasCompletaTexto",
                column: "CompletaTextoID",
                principalTable: "CompletaTexto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasOpcaoCerta_OpcaoCerta_OpcaoCertaID",
                table: "RespostasOpcaoCerta",
                column: "OpcaoCertaID",
                principalTable: "OpcaoCerta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasVF_VerdadeiroFalso_VerdadeiroFalsoID",
                table: "RespostasVF",
                column: "VerdadeiroFalsoID",
                principalTable: "VerdadeiroFalso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostasCompletaTexto_CompletaTexto_CompletaTextoID",
                table: "RespostasCompletaTexto");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostasOpcaoCerta_OpcaoCerta_OpcaoCertaID",
                table: "RespostasOpcaoCerta");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostasVF_VerdadeiroFalso_VerdadeiroFalsoID",
                table: "RespostasVF");

            migrationBuilder.RenameColumn(
                name: "VerdadeiroFalsoID",
                table: "RespostasVF",
                newName: "VerdadeiroFalsoId");

            migrationBuilder.RenameIndex(
                name: "IX_RespostasVF_VerdadeiroFalsoID",
                table: "RespostasVF",
                newName: "IX_RespostasVF_VerdadeiroFalsoId");

            migrationBuilder.RenameColumn(
                name: "OpcaoCertaID",
                table: "RespostasOpcaoCerta",
                newName: "OpcaoCertaId");

            migrationBuilder.RenameIndex(
                name: "IX_RespostasOpcaoCerta_OpcaoCertaID",
                table: "RespostasOpcaoCerta",
                newName: "IX_RespostasOpcaoCerta_OpcaoCertaId");

            migrationBuilder.RenameColumn(
                name: "CompletaTextoID",
                table: "RespostasCompletaTexto",
                newName: "CompletaTextoId");

            migrationBuilder.RenameIndex(
                name: "IX_RespostasCompletaTexto_CompletaTextoID",
                table: "RespostasCompletaTexto",
                newName: "IX_RespostasCompletaTexto_CompletaTextoId");

            migrationBuilder.AlterColumn<Guid>(
                name: "VerdadeiroFalsoId",
                table: "RespostasVF",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "CompletaFraseID",
                table: "RespostasVF",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "OpcaoCertaId",
                table: "RespostasOpcaoCerta",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "CompletaFraseID",
                table: "RespostasOpcaoCerta",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CompletaTextoId",
                table: "RespostasCompletaTexto",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "CompletaFraseID",
                table: "RespostasCompletaTexto",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasCompletaTexto_CompletaTexto_CompletaTextoId",
                table: "RespostasCompletaTexto",
                column: "CompletaTextoId",
                principalTable: "CompletaTexto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasOpcaoCerta_OpcaoCerta_OpcaoCertaId",
                table: "RespostasOpcaoCerta",
                column: "OpcaoCertaId",
                principalTable: "OpcaoCerta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasVF_VerdadeiroFalso_VerdadeiroFalsoId",
                table: "RespostasVF",
                column: "VerdadeiroFalsoId",
                principalTable: "VerdadeiroFalso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

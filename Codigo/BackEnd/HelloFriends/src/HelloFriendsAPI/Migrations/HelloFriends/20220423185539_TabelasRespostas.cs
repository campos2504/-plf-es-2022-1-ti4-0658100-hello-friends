using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    public partial class TabelasRespostas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RespostasCompletaTexto",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Resultado = table.Column<double>(nullable: false),
                    AlunoId = table.Column<long>(nullable: false),
                    MId = table.Column<long>(nullable: false),
                    CompletaFraseID = table.Column<Guid>(nullable: false),
                    CompletaTextoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostasCompletaTexto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespostasCompletaTexto_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespostasCompletaTexto_CompletaTexto_CompletaTextoId",
                        column: x => x.CompletaTextoId,
                        principalTable: "CompletaTexto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RespostasOpcaoCerta",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Resultado = table.Column<double>(nullable: false),
                    AlunoId = table.Column<long>(nullable: false),
                    MId = table.Column<long>(nullable: false),
                    CompletaFraseID = table.Column<Guid>(nullable: false),
                    OpcaoCertaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostasOpcaoCerta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespostasOpcaoCerta_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespostasOpcaoCerta_OpcaoCerta_OpcaoCertaId",
                        column: x => x.OpcaoCertaId,
                        principalTable: "OpcaoCerta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RespotasVF",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Resultado = table.Column<double>(nullable: false),
                    AlunoId = table.Column<long>(nullable: false),
                    MId = table.Column<long>(nullable: false),
                    CompletaFraseID = table.Column<Guid>(nullable: false),
                    VerdadeiroFalsoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespotasVF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespotasVF_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespotasVF_VerdadeiroFalso_VerdadeiroFalsoId",
                        column: x => x.VerdadeiroFalsoId,
                        principalTable: "VerdadeiroFalso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RespostasCompletaTexto_AlunoId",
                table: "RespostasCompletaTexto",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasCompletaTexto_CompletaTextoId",
                table: "RespostasCompletaTexto",
                column: "CompletaTextoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasOpcaoCerta_AlunoId",
                table: "RespostasOpcaoCerta",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasOpcaoCerta_OpcaoCertaId",
                table: "RespostasOpcaoCerta",
                column: "OpcaoCertaId");

            migrationBuilder.CreateIndex(
                name: "IX_RespotasVF_AlunoId",
                table: "RespotasVF",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespotasVF_VerdadeiroFalsoId",
                table: "RespotasVF",
                column: "VerdadeiroFalsoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespostasCompletaTexto");

            migrationBuilder.DropTable(
                name: "RespostasOpcaoCerta");

            migrationBuilder.DropTable(
                name: "RespotasVF");
        }
    }
}

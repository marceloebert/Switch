using Microsoft.EntityFrameworkCore.Migrations;

namespace Switch.Infra.Data.Migrations
{
    public partial class atualizaca_usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcurandoPorId",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusRelacionamentoId",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ProcurandoPorId",
                table: "Usuarios",
                column: "ProcurandoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_StatusRelacionamentoId",
                table: "Usuarios",
                column: "StatusRelacionamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_ProcurandoPor_ProcurandoPorId",
                table: "Usuarios",
                column: "ProcurandoPorId",
                principalTable: "ProcurandoPor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_StatusRelacionamento_StatusRelacionamentoId",
                table: "Usuarios",
                column: "StatusRelacionamentoId",
                principalTable: "StatusRelacionamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_ProcurandoPor_ProcurandoPorId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_StatusRelacionamento_StatusRelacionamentoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ProcurandoPorId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_StatusRelacionamentoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ProcurandoPorId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "StatusRelacionamentoId",
                table: "Usuarios");
        }
    }
}

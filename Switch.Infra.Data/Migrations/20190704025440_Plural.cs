using Microsoft.EntityFrameworkCore.Migrations;

namespace Switch.Infra.Data.Migrations
{
    public partial class Plural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postagens_Grupo_GrupoId",
                table: "Postagens");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGrupo_Grupo_GrupoId",
                table: "UsuarioGrupo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grupo",
                table: "Grupo");

            migrationBuilder.RenameTable(
                name: "Grupo",
                newName: "Grupoo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grupoo",
                table: "Grupoo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Postagens_Grupoo_GrupoId",
                table: "Postagens",
                column: "GrupoId",
                principalTable: "Grupoo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGrupo_Grupoo_GrupoId",
                table: "UsuarioGrupo",
                column: "GrupoId",
                principalTable: "Grupoo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postagens_Grupoo_GrupoId",
                table: "Postagens");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGrupo_Grupoo_GrupoId",
                table: "UsuarioGrupo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grupoo",
                table: "Grupoo");

            migrationBuilder.RenameTable(
                name: "Grupoo",
                newName: "Grupo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grupo",
                table: "Grupo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Postagens_Grupo_GrupoId",
                table: "Postagens",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGrupo_Grupo_GrupoId",
                table: "UsuarioGrupo",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

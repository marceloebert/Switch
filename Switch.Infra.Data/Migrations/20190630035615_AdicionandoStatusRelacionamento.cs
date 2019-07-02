using Microsoft.EntityFrameworkCore.Migrations;

namespace Switch.Infra.Data.Migrations
{
    public partial class AdicionandoStatusRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Postagens",
                table: "Postagens");

            migrationBuilder.RenameTable(
                name: "Postagens",
                newName: "Postagem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Postagem",
                table: "Postagem",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Postagem",
                table: "Postagem");

            migrationBuilder.RenameTable(
                name: "Postagem",
                newName: "Postagens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Postagens",
                table: "Postagens",
                column: "Id");
        }
    }
}

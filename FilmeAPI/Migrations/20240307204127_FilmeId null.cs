using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeAPI.Migrations
{
    public partial class FilmeIdnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Sessao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Sessao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

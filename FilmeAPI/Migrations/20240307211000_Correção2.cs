using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeAPI.Migrations
{
    public partial class Correção2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Cinema_FilmeId",
                table: "Sessao");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Filme_FilmeId1",
                table: "Sessao");

            migrationBuilder.DropIndex(
                name: "IX_Sessao_FilmeId1",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "FilmeId1",
                table: "Sessao");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_CinemaId",
                table: "Sessao",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Cinema_CinemaId",
                table: "Sessao",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Cinema_CinemaId",
                table: "Sessao");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao");

            migrationBuilder.DropIndex(
                name: "IX_Sessao_CinemaId",
                table: "Sessao");

            migrationBuilder.AddColumn<int>(
                name: "FilmeId1",
                table: "Sessao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_FilmeId1",
                table: "Sessao",
                column: "FilmeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Cinema_FilmeId",
                table: "Sessao",
                column: "FilmeId",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Filme_FilmeId1",
                table: "Sessao",
                column: "FilmeId1",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

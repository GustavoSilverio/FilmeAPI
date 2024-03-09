using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeAPI.Migrations
{
    public partial class DeleteRestict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinema_Endereco_IdEndereco",
                table: "Cinema");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinema_Endereco_IdEndereco",
                table: "Cinema",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinema_Endereco_IdEndereco",
                table: "Cinema");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinema_Endereco_IdEndereco",
                table: "Cinema",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

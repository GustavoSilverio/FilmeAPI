using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeAPI.Migrations
{
    public partial class CinemaEFilme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Cinema_CinemaId",
                table: "Sessao");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao");

            migrationBuilder.DropIndex(
                name: "IX_Sessao_CinemaId",
                table: "Sessao");

            migrationBuilder.DropIndex(
                name: "IX_Sessao_FilmeId",
                table: "Sessao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sessao",
                newName: "FilmeId1");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Sessao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Sessao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId1",
                table: "Sessao",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao",
                columns: new[] { "FilmeId", "CinemaId" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Cinema_FilmeId",
                table: "Sessao");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Filme_FilmeId1",
                table: "Sessao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao");

            migrationBuilder.DropIndex(
                name: "IX_Sessao_FilmeId1",
                table: "Sessao");

            migrationBuilder.RenameColumn(
                name: "FilmeId1",
                table: "Sessao",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Sessao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Sessao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Sessao",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_CinemaId",
                table: "Sessao",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_FilmeId",
                table: "Sessao",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Cinema_CinemaId",
                table: "Sessao",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id");
        }
    }
}

﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeAPI.Migrations
{
    public partial class SessaoeCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "Sessao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_CinemaId",
                table: "Sessao",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Cinema_CinemaId",
                table: "Sessao",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Cinema_CinemaId",
                table: "Sessao");

            migrationBuilder.DropIndex(
                name: "IX_Sessao_CinemaId",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Sessao");
        }
    }
}

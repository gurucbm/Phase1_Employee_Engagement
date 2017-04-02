using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyBuddhaSite.Migrations
{
    public partial class M7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SelectedTeamId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SelectedTeamId",
                table: "AspNetUsers",
                column: "SelectedTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Team_SelectedTeamId",
                table: "AspNetUsers",
                column: "SelectedTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Team_SelectedTeamId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SelectedTeamId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SelectedTeamId",
                table: "AspNetUsers");
        }
    }
}

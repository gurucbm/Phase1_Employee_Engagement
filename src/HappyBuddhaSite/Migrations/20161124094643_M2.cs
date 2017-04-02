using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyBuddhaSite.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.Id);
                });

            migrationBuilder.AddColumn<Guid>(
                name: "CurrentSprintId",
                table: "Team",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_CurrentSprintId",
                table: "Team",
                column: "CurrentSprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Sprint_CurrentSprintId",
                table: "Team",
                column: "CurrentSprintId",
                principalTable: "Sprint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Sprint_CurrentSprintId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_CurrentSprintId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "CurrentSprintId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "Sprint");
        }
    }
}

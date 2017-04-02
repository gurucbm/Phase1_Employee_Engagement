using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyBuddhaSite.Migrations
{
    public partial class M8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "SelfReviewSummary",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SelfReviewSummary_TeamId",
                table: "SelfReviewSummary",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelfReviewSummary_Team_TeamId",
                table: "SelfReviewSummary",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelfReviewSummary_Team_TeamId",
                table: "SelfReviewSummary");

            migrationBuilder.DropIndex(
                name: "IX_SelfReviewSummary_TeamId",
                table: "SelfReviewSummary");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "SelfReviewSummary");
        }
    }
}

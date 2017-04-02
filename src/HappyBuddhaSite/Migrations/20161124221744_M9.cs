using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyBuddhaSite.Migrations
{
    public partial class M9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SelfReviewId",
                table: "SelfReviewSummary",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SelfReviewSummary_SelfReviewId",
                table: "SelfReviewSummary",
                column: "SelfReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelfReviewSummary_SelfReview_SelfReviewId",
                table: "SelfReviewSummary",
                column: "SelfReviewId",
                principalTable: "SelfReview",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelfReviewSummary_SelfReview_SelfReviewId",
                table: "SelfReviewSummary");

            migrationBuilder.DropIndex(
                name: "IX_SelfReviewSummary_SelfReviewId",
                table: "SelfReviewSummary");

            migrationBuilder.DropColumn(
                name: "SelfReviewId",
                table: "SelfReviewSummary");
        }
    }
}

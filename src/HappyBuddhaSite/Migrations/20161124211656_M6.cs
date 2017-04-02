using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyBuddhaSite.Migrations
{
    public partial class M6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SelfReviewSummary",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyRate = table.Column<short>(nullable: false),
                    OveralRate = table.Column<short>(nullable: false),
                    SelfRate = table.Column<short>(nullable: false),
                    SprintId = table.Column<Guid>(nullable: true),
                    TeamRate = table.Column<short>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelfReviewSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelfReviewSummary_Sprint_SprintId",
                        column: x => x.SprintId,
                        principalTable: "Sprint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelfReviewSummary_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelfReviewSummary_SprintId",
                table: "SelfReviewSummary",
                column: "SprintId");

            migrationBuilder.CreateIndex(
                name: "IX_SelfReviewSummary_UserId",
                table: "SelfReviewSummary",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelfReviewSummary");
        }
    }
}

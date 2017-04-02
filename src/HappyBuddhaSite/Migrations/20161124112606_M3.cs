using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyBuddhaSite.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SelfReview",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyRate = table.Column<short>(nullable: false),
                    CompanyRateRemarks = table.Column<string>(nullable: true),
                    CompanySuggestions = table.Column<string>(nullable: true),
                    CurrentSprintId = table.Column<Guid>(nullable: true),
                    SelfInvestmentRate = table.Column<short>(nullable: false),
                    SelfInvestmentRateRemarks = table.Column<string>(nullable: true),
                    TasksRate = table.Column<short>(nullable: false),
                    TasksRateRemarks = table.Column<string>(nullable: true),
                    TeamRate = table.Column<short>(nullable: false),
                    TeamRateRemarks = table.Column<string>(nullable: true),
                    TeamSuggestions = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    WorkRate = table.Column<short>(nullable: false),
                    WorkRateRemarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelfReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelfReview_Sprint_CurrentSprintId",
                        column: x => x.CurrentSprintId,
                        principalTable: "Sprint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelfReview_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamReview",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AssistsRate = table.Column<short>(nullable: false),
                    CurrentSprintId = table.Column<Guid>(nullable: true),
                    EffortRate = table.Column<short>(nullable: false),
                    InnovationRate = table.Column<short>(nullable: false),
                    MemberId = table.Column<Guid>(nullable: true),
                    MissesRate = table.Column<short>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Points = table.Column<short>(nullable: false),
                    QualityRate = table.Column<short>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamReview_Sprint_CurrentSprintId",
                        column: x => x.CurrentSprintId,
                        principalTable: "Sprint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamReview_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamReview_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTeam",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTeam_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelfReview_CurrentSprintId",
                table: "SelfReview",
                column: "CurrentSprintId");

            migrationBuilder.CreateIndex(
                name: "IX_SelfReview_UserId",
                table: "SelfReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamReview_CurrentSprintId",
                table: "TeamReview",
                column: "CurrentSprintId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamReview_MemberId",
                table: "TeamReview",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamReview_UserId",
                table: "TeamReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeam_TeamId",
                table: "UserTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeam_UserId",
                table: "UserTeam",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelfReview");

            migrationBuilder.DropTable(
                name: "TeamReview");

            migrationBuilder.DropTable(
                name: "UserTeam");
        }
    }
}

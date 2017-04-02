﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyBuddhaSite.Migrations
{
    public partial class M11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Team_SelectedTeamId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SelectedTeamId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

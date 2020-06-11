using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTaskForScience.Migrations
{
    public partial class Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserInformation_UserInformationUserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserInformationUserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserInformationUserId",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserInformation_Id",
                table: "User",
                column: "Id",
                principalTable: "UserInformation",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserInformation_Id",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "UserInformationUserId",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserInformationUserId",
                table: "User",
                column: "UserInformationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserInformation_UserInformationUserId",
                table: "User",
                column: "UserInformationUserId",
                principalTable: "UserInformation",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

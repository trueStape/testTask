using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTaskForScience.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInformation",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Addres = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformation", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserInformation_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserInformationUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserInformation_UserInformationUserId",
                        column: x => x.UserInformationUserId,
                        principalTable: "UserInformation",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserInformationUserId",
                table: "User",
                column: "UserInformationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInformation_DepartmentId",
                table: "UserInformation",
                column: "DepartmentId");
        }

    }
}

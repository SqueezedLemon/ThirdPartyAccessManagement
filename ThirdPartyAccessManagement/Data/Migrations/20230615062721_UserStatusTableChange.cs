using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirdPartyAccessManagement.Data.Migrations
{
    public partial class UserStatusTableChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThirdPartyUserStatus_AspNetUsers_CreatedById",
                table: "ThirdPartyUserStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_ThirdPartyUserStatus_ThirdPartyUser_ThirdPartyUserId",
                table: "ThirdPartyUserStatus");

            migrationBuilder.DropIndex(
                name: "IX_ThirdPartyUserStatus_CreatedById",
                table: "ThirdPartyUserStatus");

            migrationBuilder.DropIndex(
                name: "IX_ThirdPartyUserStatus_ThirdPartyUserId",
                table: "ThirdPartyUserStatus");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ThirdPartyUserStatus");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ThirdPartyUserStatus");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "ThirdPartyUserStatus");

            migrationBuilder.DropColumn(
                name: "ThirdPartyUserId",
                table: "ThirdPartyUserStatus");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ThirdPartyUserStatus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThirdPartyUserStatusId",
                table: "ThirdPartyUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyUser_ThirdPartyUserStatusId",
                table: "ThirdPartyUser",
                column: "ThirdPartyUserStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdPartyUser_ThirdPartyUserStatus_ThirdPartyUserStatusId",
                table: "ThirdPartyUser",
                column: "ThirdPartyUserStatusId",
                principalTable: "ThirdPartyUserStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThirdPartyUser_ThirdPartyUserStatus_ThirdPartyUserStatusId",
                table: "ThirdPartyUser");

            migrationBuilder.DropIndex(
                name: "IX_ThirdPartyUser_ThirdPartyUserStatusId",
                table: "ThirdPartyUser");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ThirdPartyUserStatus");

            migrationBuilder.DropColumn(
                name: "ThirdPartyUserStatusId",
                table: "ThirdPartyUser");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ThirdPartyUserStatus",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ThirdPartyUserStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "ThirdPartyUserStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ThirdPartyUserId",
                table: "ThirdPartyUserStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyUserStatus_CreatedById",
                table: "ThirdPartyUserStatus",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyUserStatus_ThirdPartyUserId",
                table: "ThirdPartyUserStatus",
                column: "ThirdPartyUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdPartyUserStatus_AspNetUsers_CreatedById",
                table: "ThirdPartyUserStatus",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdPartyUserStatus_ThirdPartyUser_ThirdPartyUserId",
                table: "ThirdPartyUserStatus",
                column: "ThirdPartyUserId",
                principalTable: "ThirdPartyUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

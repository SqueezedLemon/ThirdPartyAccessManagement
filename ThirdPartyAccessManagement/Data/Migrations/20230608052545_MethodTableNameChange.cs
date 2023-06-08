using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirdPartyAccessManagement.Data.Migrations
{
    public partial class MethodTableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MethodName_AspNetUsers_CreatedById",
                table: "MethodName");

            migrationBuilder.DropForeignKey(
                name: "FK_MethodName_Page_PageId",
                table: "MethodName");

            migrationBuilder.DropForeignKey(
                name: "FK_ThirdParyAccess_MethodName_MethodId",
                table: "ThirdParyAccess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MethodName",
                table: "MethodName");

            migrationBuilder.RenameTable(
                name: "MethodName",
                newName: "Method");

            migrationBuilder.RenameIndex(
                name: "IX_MethodName_PageId",
                table: "Method",
                newName: "IX_Method_PageId");

            migrationBuilder.RenameIndex(
                name: "IX_MethodName_CreatedById",
                table: "Method",
                newName: "IX_Method_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Method",
                table: "Method",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Method_AspNetUsers_CreatedById",
                table: "Method",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Method_Page_PageId",
                table: "Method",
                column: "PageId",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdParyAccess_Method_MethodId",
                table: "ThirdParyAccess",
                column: "MethodId",
                principalTable: "Method",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Method_AspNetUsers_CreatedById",
                table: "Method");

            migrationBuilder.DropForeignKey(
                name: "FK_Method_Page_PageId",
                table: "Method");

            migrationBuilder.DropForeignKey(
                name: "FK_ThirdParyAccess_Method_MethodId",
                table: "ThirdParyAccess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Method",
                table: "Method");

            migrationBuilder.RenameTable(
                name: "Method",
                newName: "MethodName");

            migrationBuilder.RenameIndex(
                name: "IX_Method_PageId",
                table: "MethodName",
                newName: "IX_MethodName_PageId");

            migrationBuilder.RenameIndex(
                name: "IX_Method_CreatedById",
                table: "MethodName",
                newName: "IX_MethodName_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MethodName",
                table: "MethodName",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MethodName_AspNetUsers_CreatedById",
                table: "MethodName",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MethodName_Page_PageId",
                table: "MethodName",
                column: "PageId",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdParyAccess_MethodName_MethodId",
                table: "ThirdParyAccess",
                column: "MethodId",
                principalTable: "MethodName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

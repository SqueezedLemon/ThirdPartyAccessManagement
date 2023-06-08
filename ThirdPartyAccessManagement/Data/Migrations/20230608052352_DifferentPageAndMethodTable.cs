using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirdPartyAccessManagement.Data.Migrations
{
    public partial class DifferentPageAndMethodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThirdParyAccess_ApiEndpoint_ApiEndpointId",
                table: "ThirdParyAccess");

            migrationBuilder.DropTable(
                name: "ApiEndpoint");

            migrationBuilder.RenameColumn(
                name: "ApiEndpointId",
                table: "ThirdParyAccess",
                newName: "MethodId");

            migrationBuilder.RenameIndex(
                name: "IX_ThirdParyAccess_ApiEndpointId",
                table: "ThirdParyAccess",
                newName: "IX_ThirdParyAccess_MethodId");

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Page_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MethodName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MethodName_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MethodName_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MethodName_CreatedById",
                table: "MethodName",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MethodName_PageId",
                table: "MethodName",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_CreatedById",
                table: "Page",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdParyAccess_MethodName_MethodId",
                table: "ThirdParyAccess",
                column: "MethodId",
                principalTable: "MethodName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThirdParyAccess_MethodName_MethodId",
                table: "ThirdParyAccess");

            migrationBuilder.DropTable(
                name: "MethodName");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.RenameColumn(
                name: "MethodId",
                table: "ThirdParyAccess",
                newName: "ApiEndpointId");

            migrationBuilder.RenameIndex(
                name: "IX_ThirdParyAccess_MethodId",
                table: "ThirdParyAccess",
                newName: "IX_ThirdParyAccess_ApiEndpointId");

            migrationBuilder.CreateTable(
                name: "ApiEndpoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiEndpoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiEndpoint_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiEndpoint_CreatedById",
                table: "ApiEndpoint",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdParyAccess_ApiEndpoint_ApiEndpointId",
                table: "ThirdParyAccess",
                column: "ApiEndpointId",
                principalTable: "ApiEndpoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

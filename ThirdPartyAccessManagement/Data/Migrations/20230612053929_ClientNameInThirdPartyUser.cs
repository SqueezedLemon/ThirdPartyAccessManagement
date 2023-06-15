using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirdPartyAccessManagement.Data.Migrations
{
    public partial class ClientNameInThirdPartyUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "ThirdPartyUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "ThirdPartyUser");
        }
    }
}

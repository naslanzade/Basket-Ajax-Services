using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Molla.Migrations
{
    public partial class AddColomunToProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "New",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Top",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "New",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Top",
                table: "Products");
        }
    }
}

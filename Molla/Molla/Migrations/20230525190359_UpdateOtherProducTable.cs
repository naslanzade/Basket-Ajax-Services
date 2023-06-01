using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Molla.Migrations
{
    public partial class UpdateOtherProducTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "OtherProducts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "OtherProducts");
        }
    }
}

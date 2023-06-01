using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Molla.Migrations
{
    public partial class updateBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitleSecond",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleSecond",
                table: "Blogs");
        }
    }
}

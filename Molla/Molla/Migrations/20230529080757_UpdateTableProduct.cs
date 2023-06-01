using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Molla.Migrations
{
    public partial class UpdateTableProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_RatingCategories_RatingCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "RatingCategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_RatingCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RatingCategoryId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingCategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RatingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_RatingCategoryId",
                table: "Products",
                column: "RatingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_RatingCategories_RatingCategoryId",
                table: "Products",
                column: "RatingCategoryId",
                principalTable: "RatingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Molla.Migrations
{
    public partial class UpdateTableProductDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ElectronicCategories_ElectronicCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ElectronicCategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_ElectronicCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ElectrinicCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ElectronicCategoryId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElectrinicCategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ElectronicCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ElectronicCategories",
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
                    table.PrimaryKey("PK_ElectronicCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ElectronicCategoryId",
                table: "Products",
                column: "ElectronicCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ElectronicCategories_ElectronicCategoryId",
                table: "Products",
                column: "ElectronicCategoryId",
                principalTable: "ElectronicCategories",
                principalColumn: "Id");
        }
    }
}

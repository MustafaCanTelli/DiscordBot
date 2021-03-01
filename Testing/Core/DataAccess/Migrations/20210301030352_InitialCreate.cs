using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MasterID = table.Column<int>(nullable: true),
                    DiscordID = table.Column<decimal>(nullable: false),
                    ServerID = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    Descriptoin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MasterID = table.Column<int>(nullable: true),
                    DiscordID = table.Column<decimal>(nullable: false),
                    ServerID = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(type: "Money", nullable: false),
                    UnitsInStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductAndCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MasterID = table.Column<int>(nullable: true),
                    DiscordID = table.Column<decimal>(nullable: false),
                    ServerID = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAndCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductAndCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAndCategories_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAndCategories_CategoryID",
                table: "ProductAndCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAndCategories_ProductID",
                table: "ProductAndCategories",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAndCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

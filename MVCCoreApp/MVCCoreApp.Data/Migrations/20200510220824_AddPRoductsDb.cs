using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCCoreApp.Data.Migrations
{
    public partial class AddPRoductsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Category = table.Column<string>(maxLength: 50, nullable: false),
                    Manufacturer = table.Column<string>(maxLength: 50, nullable: false),
                    Supplier = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace u21497682_HW01_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Product_Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_ID", "Product_Description", "Product_Name", "Product_Price" },
                values: new object[,]
                {
                    { 1, "High-performance running shoes designed with breathable mesh and a cushioned sole for maximum comfort and support. Features a sleek design and durable rubber outsole for traction on various surfaces.", "Running Shoes", 89.99m },
                    { 2, "Sleek leather boots with elastic side panels for easy wear. Features a comfortable insole and durable rubber outsole, ideal for everyday wear.", "Boots", 89m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

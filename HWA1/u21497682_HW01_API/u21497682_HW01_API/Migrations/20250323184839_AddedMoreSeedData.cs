using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace u21497682_HW01_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_ID", "Product_Description", "Product_Name", "Product_Price" },
                values: new object[,]
                {
                    { 3, "A classic baseball cap with an adjustable strap and embroidered logo. Made of breathable cotton, perfect for casual wear and outdoor activities.", "Baseball Cap", 19.99m },
                    { 4, "Flowing, floor-length maxi dress made from lightweight fabric. Features an adjustable strap design and a flattering A-line silhouette.", "Maxi Dress", 59.99m },
                    { 5, "A pair of slim-fit chinos made from lightweight cotton with a bit of stretch. Features a clean, modern look suitable for both work and weekend wear.", "Slim Fit Chinos", 44.95m },
                    { 6, "Cozy hoodie with a bold graphic print on the front. Made of soft cotton, perfect for lounging or casual outings.", "Hoodie", 49.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 6);
        }
    }
}

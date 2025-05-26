using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P02_SalesDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreaditCardNumber", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "1111222233334444", "wael.mohamed@example.com", "Ali Abdullah" },
                    { 2, "5555666677778888", "mohamed.wael@example.com", "Fatima Saeed" },
                    { 3, "9999000011112222", "wael_mohamed@example.com", "Omar Khaled" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Laptop Pro", 1200.00m, 100f },
                    { 2, "Mechanical Keyboard", 80.50m, 250f },
                    { 3, "Gaming Mouse", 45.00m, 300f },
                    { 4, "USB-C Hub", 30.00m, 150f }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Name" },
                values: new object[,]
                {
                    { 1, "Cairo" },
                    { 2, "Giza" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "CustomerId", "Date", "ProductId", "StoreId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 2, new DateTime(2025, 5, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, 1, new DateTime(2025, 5, 21, 15, 15, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 4, 3, new DateTime(2025, 5, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 2);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QkartWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class datapopulationforsellertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c25ef392-45c5-4cae-865f-16ce8f9795b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ebed91bc-19d2-401f-843a-0491d21b8770"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Catagory", "Cost", "CreatedDate", "Image", "Name", "Rating", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6cb5a37c-c82d-49f3-b753-f2fe1bce4853"), "Mobile", 8500, new DateTime(2023, 1, 26, 13, 59, 38, 792, DateTimeKind.Local).AddTicks(2503), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 1, 26, 13, 59, 38, 792, DateTimeKind.Local).AddTicks(2503) },
                    { new Guid("8b8ccb0f-7a9c-4bde-88f4-a2e13c699f5d"), "Mobile", 12500, new DateTime(2023, 1, 26, 13, 59, 38, 792, DateTimeKind.Local).AddTicks(2489), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 1, 26, 13, 59, 38, 792, DateTimeKind.Local).AddTicks(2500) }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "City", "CreatedDate", "FullAddress", "SellerName", "SpecialDetails" },
                values: new object[,]
                {
                    { 1, "Coimbatore", new DateTime(2023, 1, 26, 8, 29, 38, 792, DateTimeKind.Utc).AddTicks(2587), "Coimbatore", "InsakHomes", "" },
                    { 2, "Coimbatore", new DateTime(2023, 1, 26, 8, 29, 38, 792, DateTimeKind.Utc).AddTicks(2590), "Coimbatore", "DreamCorp", "" }
                });

            migrationBuilder.InsertData(
                table: "LinkProductSellers",
                columns: new[] { "Id", "ProductId", "SellerId", "SellerPrice", "SpecialDetails" },
                values: new object[,]
                {
                    { 1, new Guid("70c9af8e-da97-4c51-68d1-08dafeca85a2"), 1, 0, null },
                    { 2, new Guid("70c9af8e-da97-4c51-68d1-08dafeca85a2"), 2, 0, null },
                    { 3, new Guid("b44859e1-c104-4450-bf9b-2008a6858187"), 1, 0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LinkProductSellers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LinkProductSellers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LinkProductSellers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6cb5a37c-c82d-49f3-b753-f2fe1bce4853"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8b8ccb0f-7a9c-4bde-88f4-a2e13c699f5d"));

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Catagory", "Cost", "CreatedDate", "Image", "Name", "Rating", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("c25ef392-45c5-4cae-865f-16ce8f9795b7"), "Mobile", 8500, new DateTime(2023, 1, 26, 10, 38, 0, 411, DateTimeKind.Local).AddTicks(6480), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 1, 26, 10, 38, 0, 411, DateTimeKind.Local).AddTicks(6480) },
                    { new Guid("ebed91bc-19d2-401f-843a-0491d21b8770"), "Mobile", 12500, new DateTime(2023, 1, 26, 10, 38, 0, 411, DateTimeKind.Local).AddTicks(6469), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 1, 26, 10, 38, 0, 411, DateTimeKind.Local).AddTicks(6478) }
                });
        }
    }
}

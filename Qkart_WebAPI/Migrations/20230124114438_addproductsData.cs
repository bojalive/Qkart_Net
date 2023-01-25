using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QkartWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addproductsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Catagory", "Cost", "CreatedDate", "Image", "Name", "Rating", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("c4539963-561a-49ec-821a-005dbe4da45d"), "Mobile", 12500, new DateTime(2023, 1, 24, 17, 14, 38, 665, DateTimeKind.Local).AddTicks(3217), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 1, 24, 17, 14, 38, 665, DateTimeKind.Local).AddTicks(3229) },
                    { new Guid("f98f5001-ffa0-4fda-a37f-5c0d0ce36bce"), "Mobile", 8500, new DateTime(2023, 1, 24, 17, 14, 38, 665, DateTimeKind.Local).AddTicks(3232), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 1, 24, 17, 14, 38, 665, DateTimeKind.Local).AddTicks(3232) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c4539963-561a-49ec-821a-005dbe4da45d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f98f5001-ffa0-4fda-a37f-5c0d0ce36bce"));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QkartWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class keyid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c4539963-561a-49ec-821a-005dbe4da45d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f98f5001-ffa0-4fda-a37f-5c0d0ce36bce"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Catagory", "Cost", "CreatedDate", "Image", "Name", "Rating", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4280b6a7-1c6c-40a3-aef3-18c363b851b0"), "Mobile", 8500, new DateTime(2023, 1, 25, 14, 12, 29, 194, DateTimeKind.Local).AddTicks(1585), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 1, 25, 14, 12, 29, 194, DateTimeKind.Local).AddTicks(1586) },
                    { new Guid("65c3164b-afe4-4839-b654-ae9071982656"), "Mobile", 12500, new DateTime(2023, 1, 25, 14, 12, 29, 194, DateTimeKind.Local).AddTicks(1569), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 1, 25, 14, 12, 29, 194, DateTimeKind.Local).AddTicks(1582) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4280b6a7-1c6c-40a3-aef3-18c363b851b0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("65c3164b-afe4-4839-b654-ae9071982656"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Catagory", "Cost", "CreatedDate", "Image", "Name", "Rating", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("c4539963-561a-49ec-821a-005dbe4da45d"), "Mobile", 12500, new DateTime(2023, 1, 24, 17, 14, 38, 665, DateTimeKind.Local).AddTicks(3217), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 1, 24, 17, 14, 38, 665, DateTimeKind.Local).AddTicks(3229) },
                    { new Guid("f98f5001-ffa0-4fda-a37f-5c0d0ce36bce"), "Mobile", 8500, new DateTime(2023, 1, 24, 17, 14, 38, 665, DateTimeKind.Local).AddTicks(3232), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 1, 24, 17, 14, 38, 665, DateTimeKind.Local).AddTicks(3232) }
                });
        }
    }
}

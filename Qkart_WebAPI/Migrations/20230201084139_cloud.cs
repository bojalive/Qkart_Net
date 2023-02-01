using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QkartWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class cloud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("387807a0-f2fa-430e-8fb6-c1670190ae82"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f8b13820-5abc-469b-8b62-3e055292fe37"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Catagory", "Cost", "CreatedDate", "Image", "Name", "Rating", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6d3336f5-18c3-4f25-95b7-c5d8a0728296"), "Mobile", 12500, new DateTime(2023, 2, 1, 14, 11, 38, 883, DateTimeKind.Local).AddTicks(2115), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 2, 1, 14, 11, 38, 883, DateTimeKind.Local).AddTicks(2125) },
                    { new Guid("dfb328a5-ffc1-47b2-8e6c-10ab64065f82"), "Mobile", 8500, new DateTime(2023, 2, 1, 14, 11, 38, 883, DateTimeKind.Local).AddTicks(2127), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 2, 1, 14, 11, 38, 883, DateTimeKind.Local).AddTicks(2127) }
                });

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 8, 41, 38, 883, DateTimeKind.Utc).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 8, 41, 38, 883, DateTimeKind.Utc).AddTicks(2225));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6d3336f5-18c3-4f25-95b7-c5d8a0728296"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dfb328a5-ffc1-47b2-8e6c-10ab64065f82"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Catagory", "Cost", "CreatedDate", "Image", "Name", "Rating", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("387807a0-f2fa-430e-8fb6-c1670190ae82"), "Mobile", 12500, new DateTime(2023, 2, 1, 13, 50, 46, 498, DateTimeKind.Local).AddTicks(8441), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 2, 1, 13, 50, 46, 498, DateTimeKind.Local).AddTicks(8458) },
                    { new Guid("f8b13820-5abc-469b-8b62-3e055292fe37"), "Mobile", 8500, new DateTime(2023, 2, 1, 13, 50, 46, 498, DateTimeKind.Local).AddTicks(8460), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 2, 1, 13, 50, 46, 498, DateTimeKind.Local).AddTicks(8460) }
                });

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 8, 20, 46, 498, DateTimeKind.Utc).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 8, 20, 46, 498, DateTimeKind.Utc).AddTicks(8536));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QkartWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class identitychange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c70741f-a6cb-4189-9200-7a9264a6a0d7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b09f79a2-6411-460a-ad3c-659b75721d24"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Catagory", "Cost", "CreatedDate", "Image", "Name", "Rating", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("fd0601b1-0bb4-4184-a8c1-d5c91a066726"), "Mobile", 8500, new DateTime(2023, 2, 1, 10, 25, 8, 989, DateTimeKind.Local).AddTicks(7966), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 2, 1, 10, 25, 8, 989, DateTimeKind.Local).AddTicks(7966) },
                    { new Guid("ff88adfd-e20b-463c-8868-9ccf90a6c49f"), "Mobile", 12500, new DateTime(2023, 2, 1, 10, 25, 8, 989, DateTimeKind.Local).AddTicks(7950), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 2, 1, 10, 25, 8, 989, DateTimeKind.Local).AddTicks(7964) }
                });

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 4, 55, 8, 989, DateTimeKind.Utc).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 4, 55, 8, 989, DateTimeKind.Utc).AddTicks(8075));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fd0601b1-0bb4-4184-a8c1-d5c91a066726"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ff88adfd-e20b-463c-8868-9ccf90a6c49f"));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Catagory", "Cost", "CreatedDate", "Image", "Name", "Rating", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("9c70741f-a6cb-4189-9200-7a9264a6a0d7"), "Mobile", 12500, new DateTime(2023, 2, 1, 10, 23, 6, 304, DateTimeKind.Local).AddTicks(4750), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 2, 1, 10, 23, 6, 304, DateTimeKind.Local).AddTicks(4762) },
                    { new Guid("b09f79a2-6411-460a-ad3c-659b75721d24"), "Mobile", 8500, new DateTime(2023, 2, 1, 10, 23, 6, 304, DateTimeKind.Local).AddTicks(4764), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 2, 1, 10, 23, 6, 304, DateTimeKind.Local).AddTicks(4764) }
                });

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 4, 53, 6, 304, DateTimeKind.Utc).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 4, 53, 6, 304, DateTimeKind.Utc).AddTicks(4839));
        }
    }
}

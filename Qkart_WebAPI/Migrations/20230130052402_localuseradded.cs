using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QkartWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class localuseradded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6cb5a37c-c82d-49f3-b753-f2fe1bce4853"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8b8ccb0f-7a9c-4bde-88f4-a2e13c699f5d"));

            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Catagory", "Cost", "CreatedDate", "Image", "Name", "Rating", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("25369fa7-0810-4d87-beed-3fbb3e2162a9"), "Mobile", 8500, new DateTime(2023, 1, 30, 10, 54, 2, 95, DateTimeKind.Local).AddTicks(8191), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 1, 30, 10, 54, 2, 95, DateTimeKind.Local).AddTicks(8191) },
                    { new Guid("af0d7144-43a5-460a-b14b-7dfdec0e681b"), "Mobile", 12500, new DateTime(2023, 1, 30, 10, 54, 2, 95, DateTimeKind.Local).AddTicks(8176), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 1, 30, 10, 54, 2, 95, DateTimeKind.Local).AddTicks(8189) }
                });

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 30, 5, 24, 2, 95, DateTimeKind.Utc).AddTicks(8333));

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 30, 5, 24, 2, 95, DateTimeKind.Utc).AddTicks(8337));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("25369fa7-0810-4d87-beed-3fbb3e2162a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("af0d7144-43a5-460a-b14b-7dfdec0e681b"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Catagory", "Cost", "CreatedDate", "Image", "Name", "Rating", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6cb5a37c-c82d-49f3-b753-f2fe1bce4853"), "Mobile", 8500, new DateTime(2023, 1, 26, 13, 59, 38, 792, DateTimeKind.Local).AddTicks(2503), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 1, 26, 13, 59, 38, 792, DateTimeKind.Local).AddTicks(2503) },
                    { new Guid("8b8ccb0f-7a9c-4bde-88f4-a2e13c699f5d"), "Mobile", 12500, new DateTime(2023, 1, 26, 13, 59, 38, 792, DateTimeKind.Local).AddTicks(2489), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 1, 26, 13, 59, 38, 792, DateTimeKind.Local).AddTicks(2500) }
                });

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 26, 8, 29, 38, 792, DateTimeKind.Utc).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 26, 8, 29, 38, 792, DateTimeKind.Utc).AddTicks(2590));
        }
    }
}

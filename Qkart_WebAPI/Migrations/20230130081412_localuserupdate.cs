using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QkartWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class localuserupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("25369fa7-0810-4d87-beed-3fbb3e2162a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("af0d7144-43a5-460a-b14b-7dfdec0e681b"));

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "LocalUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "LocalUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "LocalUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LocalUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Catagory", "Cost", "CreatedDate", "Image", "Name", "Rating", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("147e9c08-d57b-43f2-88ce-937507201720"), "Mobile", 12500, new DateTime(2023, 1, 30, 13, 44, 12, 107, DateTimeKind.Local).AddTicks(8897), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 1, 30, 13, 44, 12, 107, DateTimeKind.Local).AddTicks(8907) },
                    { new Guid("e8932946-a19e-4543-955d-2b04919c3641"), "Mobile", 8500, new DateTime(2023, 1, 30, 13, 44, 12, 107, DateTimeKind.Local).AddTicks(8909), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 1, 30, 13, 44, 12, 107, DateTimeKind.Local).AddTicks(8910) }
                });

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 30, 8, 14, 12, 107, DateTimeKind.Utc).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 30, 8, 14, 12, 107, DateTimeKind.Utc).AddTicks(9003));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("147e9c08-d57b-43f2-88ce-937507201720"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8932946-a19e-4543-955d-2b04919c3641"));

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "LocalUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "LocalUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "LocalUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "LocalUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}

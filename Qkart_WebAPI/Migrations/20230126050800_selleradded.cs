using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QkartWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class selleradded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4280b6a7-1c6c-40a3-aef3-18c363b851b0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("65c3164b-afe4-4839-b654-ae9071982656"));

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkProductSellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    SellerPrice = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkProductSellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkProductSellers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkProductSellers_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Catagory", "Cost", "CreatedDate", "Image", "Name", "Rating", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("c25ef392-45c5-4cae-865f-16ce8f9795b7"), "Mobile", 8500, new DateTime(2023, 1, 26, 10, 38, 0, 411, DateTimeKind.Local).AddTicks(6480), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 1, 26, 10, 38, 0, 411, DateTimeKind.Local).AddTicks(6480) },
                    { new Guid("ebed91bc-19d2-401f-843a-0491d21b8770"), "Mobile", 12500, new DateTime(2023, 1, 26, 10, 38, 0, 411, DateTimeKind.Local).AddTicks(6469), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 1, 26, 10, 38, 0, 411, DateTimeKind.Local).AddTicks(6478) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkProductSellers_ProductId",
                table: "LinkProductSellers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkProductSellers_SellerId",
                table: "LinkProductSellers",
                column: "SellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkProductSellers");

            migrationBuilder.DropTable(
                name: "Sellers");

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
                    { new Guid("4280b6a7-1c6c-40a3-aef3-18c363b851b0"), "Mobile", 8500, new DateTime(2023, 1, 25, 14, 12, 29, 194, DateTimeKind.Local).AddTicks(1585), null, "MI Some Mobile", 4.0999999999999996, new DateTime(2023, 1, 25, 14, 12, 29, 194, DateTimeKind.Local).AddTicks(1586) },
                    { new Guid("65c3164b-afe4-4839-b654-ae9071982656"), "Mobile", 12500, new DateTime(2023, 1, 25, 14, 12, 29, 194, DateTimeKind.Local).AddTicks(1569), null, "Asus ZenPhone M2 Mobile Phone", 4.0, new DateTime(2023, 1, 25, 14, 12, 29, 194, DateTimeKind.Local).AddTicks(1582) }
                });
        }
    }
}

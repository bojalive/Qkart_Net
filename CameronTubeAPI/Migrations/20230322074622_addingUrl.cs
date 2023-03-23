using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CameronTubeAPI.Migrations
{
    /// <inheritdoc />
    public partial class addingUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("25b46045-116b-4253-9908-7de403bef5c6"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("85e692bc-cabb-4752-b256-b7a1b498ebdd"));

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedAt",
                value: new DateTime(2023, 3, 22, 7, 46, 22, 147, DateTimeKind.Utc).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedAt",
                value: new DateTime(2023, 3, 22, 7, 46, 22, 147, DateTimeKind.Utc).AddTicks(1121));

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CategoryId", "ChannelTitle", "Etag", "Kind", "Url" },
                values: new object[,]
                {
                    { new Guid("70d0f1dd-cd50-4130-bb4f-856385d4c83c"), 1, "Valves", "Etag", "youtube#video", "www.slb.com" },
                    { new Guid("75d3df30-629c-4409-b25d-ca8e7d856b0d"), 1, "SubSea", "Etag", "sd#video", "www.slb.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("70d0f1dd-cd50-4130-bb4f-856385d4c83c"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("75d3df30-629c-4409-b25d-ca8e7d856b0d"));

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Videos");

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedAt",
                value: new DateTime(2023, 3, 22, 7, 22, 25, 138, DateTimeKind.Utc).AddTicks(5988));

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedAt",
                value: new DateTime(2023, 3, 22, 7, 22, 25, 138, DateTimeKind.Utc).AddTicks(6016));

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CategoryId", "ChannelTitle", "Etag", "Kind" },
                values: new object[,]
                {
                    { new Guid("25b46045-116b-4253-9908-7de403bef5c6"), 1, "Valves", "Etag", "youtube#video" },
                    { new Guid("85e692bc-cabb-4752-b256-b7a1b498ebdd"), 1, "SubSea", "Etag", "sd#video" }
                });
        }
    }
}

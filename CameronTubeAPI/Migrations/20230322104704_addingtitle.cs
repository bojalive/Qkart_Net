using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CameronTubeAPI.Migrations
{
    /// <inheritdoc />
    public partial class addingtitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("70d0f1dd-cd50-4130-bb4f-856385d4c83c"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("75d3df30-629c-4409-b25d-ca8e7d856b0d"));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedAt",
                value: new DateTime(2023, 3, 22, 10, 47, 4, 463, DateTimeKind.Utc).AddTicks(3303));

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedAt",
                value: new DateTime(2023, 3, 22, 10, 47, 4, 463, DateTimeKind.Utc).AddTicks(3334));

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CategoryId", "ChannelTitle", "Etag", "Kind", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("44fc0b14-1623-4232-959c-b05f048cb366"), 1, "SubSea", "Etag", "sd#video", null, "www.slb.com" },
                    { new Guid("65449b76-6929-4ef2-ad63-924c2fd2bb75"), 1, "Valves", "Etag", "youtube#video", null, "www.slb.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("44fc0b14-1623-4232-959c-b05f048cb366"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("65449b76-6929-4ef2-ad63-924c2fd2bb75"));

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Videos");

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
    }
}

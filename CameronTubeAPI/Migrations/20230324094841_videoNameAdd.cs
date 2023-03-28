using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CameronTubeAPI.Migrations
{
    /// <inheritdoc />
    public partial class videoNameAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("44fc0b14-1623-4232-959c-b05f048cb366"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("65449b76-6929-4ef2-ad63-924c2fd2bb75"));

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Videos",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedAt",
                value: new DateTime(2023, 3, 24, 9, 48, 41, 515, DateTimeKind.Utc).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "Snippets",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedAt",
                value: new DateTime(2023, 3, 24, 9, 48, 41, 515, DateTimeKind.Utc).AddTicks(7620));

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CategoryId", "ChannelTitle", "Etag", "Kind", "Name", "Title" },
                values: new object[,]
                {
                    { new Guid("448fc4a5-aa2c-449f-a48d-9cb6dc352e4b"), 1, "Valves", "Etag", "youtube#video", "www.slb.com", null },
                    { new Guid("7cc4d62b-5bbd-4cec-994d-e59f5a31e1f1"), 1, "SubSea", "Etag", "sd#video", "www.slb.com", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("448fc4a5-aa2c-449f-a48d-9cb6dc352e4b"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("7cc4d62b-5bbd-4cec-994d-e59f5a31e1f1"));

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Videos",
                newName: "Url");

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
    }
}

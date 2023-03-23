using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CameronTubeAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkTableVideos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SnippetId = table.Column<int>(type: "int", nullable: false),
                    StatisticsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkTableVideos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Snippets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snippets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    DislikeCount = table.Column<int>(type: "int", nullable: false),
                    FavoriteCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kind = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Snippets",
                columns: new[] { "Id", "Description", "PublishedAt", "ThumbnailUrl", "Title" },
                values: new object[,]
                {
                    { 1, "Sample 1", new DateTime(2023, 3, 22, 7, 22, 25, 138, DateTimeKind.Utc).AddTicks(5988), "www.slb.com", "Title" },
                    { 2, "Sample 2", new DateTime(2023, 3, 22, 7, 22, 25, 138, DateTimeKind.Utc).AddTicks(6016), "www.cameron.slb.com", "@@" }
                });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "Id", "CommentCount", "DislikeCount", "FavoriteCount", "LikeCount", "ViewCount" },
                values: new object[,]
                {
                    { 1, 2, 1, 5, 5, 50 },
                    { 2, 2, 1, 5, 5, 50 }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CategoryId", "ChannelTitle", "Etag", "Kind" },
                values: new object[,]
                {
                    { new Guid("25b46045-116b-4253-9908-7de403bef5c6"), 1, "Valves", "Etag", "youtube#video" },
                    { new Guid("85e692bc-cabb-4752-b256-b7a1b498ebdd"), 1, "SubSea", "Etag", "sd#video" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkTableVideos");

            migrationBuilder.DropTable(
                name: "Snippets");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}

﻿// <auto-generated />
using System;
using CameronTubeAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CameronTubeAPI.Migrations
{
    [DbContext(typeof(CamDbContext))]
    partial class CamDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CameronTubeAPI.Models.LinkTable", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"));

                    b.Property<int>("SnippetId")
                        .HasColumnType("int");

                    b.Property<int>("StatisticsID")
                        .HasColumnType("int");

                    b.Property<Guid>("VideoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("LinkTableVideos");
                });

            modelBuilder.Entity("CameronTubeAPI.Models.Snippet", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PublishedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Snippets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Sample 1",
                            PublishedAt = new DateTime(2023, 3, 22, 10, 47, 4, 463, DateTimeKind.Utc).AddTicks(3303),
                            ThumbnailUrl = "www.slb.com",
                            Title = "Title"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Sample 2",
                            PublishedAt = new DateTime(2023, 3, 22, 10, 47, 4, 463, DateTimeKind.Utc).AddTicks(3334),
                            ThumbnailUrl = "www.cameron.slb.com",
                            Title = "@@"
                        });
                });

            modelBuilder.Entity("CameronTubeAPI.Models.Statistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommentCount")
                        .HasColumnType("int");

                    b.Property<int>("DislikeCount")
                        .HasColumnType("int");

                    b.Property<int>("FavoriteCount")
                        .HasColumnType("int");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Statistics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommentCount = 2,
                            DislikeCount = 1,
                            FavoriteCount = 5,
                            LikeCount = 5,
                            ViewCount = 50
                        },
                        new
                        {
                            Id = 2,
                            CommentCount = 2,
                            DislikeCount = 1,
                            FavoriteCount = 5,
                            LikeCount = 5,
                            ViewCount = 50
                        });
                });

            modelBuilder.Entity("CameronTubeAPI.Models.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ChannelTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Etag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kind")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("65449b76-6929-4ef2-ad63-924c2fd2bb75"),
                            CategoryId = 1,
                            ChannelTitle = "Valves",
                            Etag = "Etag",
                            Kind = "youtube#video",
                            Url = "www.slb.com"
                        },
                        new
                        {
                            Id = new Guid("44fc0b14-1623-4232-959c-b05f048cb366"),
                            CategoryId = 1,
                            ChannelTitle = "SubSea",
                            Etag = "Etag",
                            Kind = "sd#video",
                            Url = "www.slb.com"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

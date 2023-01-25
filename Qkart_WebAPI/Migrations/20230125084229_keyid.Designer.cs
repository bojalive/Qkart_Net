﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Qkart_WebAPI.Data;

#nullable disable

namespace QkartWebAPI.Migrations
{
    [DbContext(typeof(QkartDbContext))]
    [Migration("20230125084229_keyid")]
    partial class keyid
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Qkart_WebAPI.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Catagory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("65c3164b-afe4-4839-b654-ae9071982656"),
                            Catagory = "Mobile",
                            Cost = 12500,
                            CreatedDate = new DateTime(2023, 1, 25, 14, 12, 29, 194, DateTimeKind.Local).AddTicks(1569),
                            Name = "Asus ZenPhone M2 Mobile Phone",
                            Rating = 4.0,
                            UpdatedDate = new DateTime(2023, 1, 25, 14, 12, 29, 194, DateTimeKind.Local).AddTicks(1582)
                        },
                        new
                        {
                            Id = new Guid("4280b6a7-1c6c-40a3-aef3-18c363b851b0"),
                            Catagory = "Mobile",
                            Cost = 8500,
                            CreatedDate = new DateTime(2023, 1, 25, 14, 12, 29, 194, DateTimeKind.Local).AddTicks(1585),
                            Name = "MI Some Mobile",
                            Rating = 4.0999999999999996,
                            UpdatedDate = new DateTime(2023, 1, 25, 14, 12, 29, 194, DateTimeKind.Local).AddTicks(1586)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using E_Commerce.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240527205208_AddSeedDataIntoProductTable")]
    partial class AddSeedDataIntoProductTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("E_Commerce.DAL.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("E_Commerce.DAL.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmationCodeToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("E_Commerce.DAL.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                            CreatedAt = new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(6053),
                            IsDeleted = false,
                            Name = "Angular"
                        },
                        new
                        {
                            Id = new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                            CreatedAt = new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(6161),
                            IsDeleted = false,
                            Name = "NetCore"
                        },
                        new
                        {
                            Id = new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"),
                            CreatedAt = new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(6184),
                            IsDeleted = false,
                            Name = "VS Code"
                        },
                        new
                        {
                            Id = new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"),
                            CreatedAt = new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(6206),
                            IsDeleted = false,
                            Name = "React"
                        },
                        new
                        {
                            Id = new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                            CreatedAt = new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(6227),
                            IsDeleted = false,
                            Name = "Typescript"
                        },
                        new
                        {
                            Id = new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"),
                            CreatedAt = new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(6255),
                            IsDeleted = false,
                            Name = "Redis"
                        });
                });

            modelBuilder.Entity("E_Commerce.DAL.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                            CreatedAt = new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(2167),
                            IsDeleted = false,
                            Name = "Boards"
                        },
                        new
                        {
                            Id = new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                            CreatedAt = new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(2241),
                            IsDeleted = false,
                            Name = "Hats"
                        },
                        new
                        {
                            Id = new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                            CreatedAt = new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(2266),
                            IsDeleted = false,
                            Name = "Boots"
                        },
                        new
                        {
                            Id = new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                            CreatedAt = new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(2287),
                            IsDeleted = false,
                            Name = "Gloves"
                        });
                });

            modelBuilder.Entity("E_Commerce.DAL.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("E_Commerce.DAL.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("OfferPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d6866a9c-9035-4a70-8371-5707b00f77f1"),
                            BrandId = new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                            CategoryId = new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            IsDeleted = false,
                            Name = "Angular Speedster Board 2000",
                            OfferPrice = 180.0m,
                            OriginalPrice = 200.0m,
                            Stock = 12
                        },
                        new
                        {
                            Id = new Guid("a1f6e281-7f30-442e-a95e-22eb82e0ccaf"),
                            BrandId = new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                            CategoryId = new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                            IsDeleted = false,
                            Name = "Green Angular Board 3000",
                            OfferPrice = 140.0m,
                            OriginalPrice = 150.0m,
                            Stock = 20
                        },
                        new
                        {
                            Id = new Guid("267475b7-e1b3-40f0-b06a-c57d8611e3da"),
                            BrandId = new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                            CategoryId = new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                            IsDeleted = false,
                            Name = "Core Board Speed Rush 3",
                            OfferPrice = 160.0m,
                            OriginalPrice = 180.0m,
                            Stock = 23
                        },
                        new
                        {
                            Id = new Guid("654e440f-8ed4-4eaf-a48b-60638f065057"),
                            BrandId = new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                            CategoryId = new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                            IsDeleted = false,
                            Name = "Net Core Super Board",
                            OfferPrice = 280.0m,
                            OriginalPrice = 300.0m,
                            Stock = 34
                        },
                        new
                        {
                            Id = new Guid("3d5d1b58-e91e-4850-9cae-f62fa4e4caef"),
                            BrandId = new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                            CategoryId = new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            IsDeleted = false,
                            Name = "React Board Super Whizzy Fast",
                            OfferPrice = 230.0m,
                            OriginalPrice = 250.0m,
                            Stock = 45
                        },
                        new
                        {
                            Id = new Guid("0ffdac50-e316-4e89-8d84-e51ac8c0733a"),
                            BrandId = new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"),
                            CategoryId = new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                            IsDeleted = false,
                            Name = "Typescript Entry Board",
                            OfferPrice = 100.0m,
                            OriginalPrice = 120.0m,
                            Stock = 21
                        },
                        new
                        {
                            Id = new Guid("3868d8c2-1f85-5a4f-b5f3-2ac4867eab18"),
                            BrandId = new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                            CategoryId = new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Joe nec lorem. Donec laoreet nonummy augue.",
                            IsDeleted = false,
                            Name = "Js Entry Board",
                            OfferPrice = 8.0m,
                            OriginalPrice = 10.0m,
                            Stock = 21
                        },
                        new
                        {
                            Id = new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"),
                            BrandId = new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                            CategoryId = new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                            IsDeleted = false,
                            Name = "Green React Woolen Hat",
                            OfferPrice = 6.0m,
                            OriginalPrice = 8.0m,
                            Stock = 21
                        },
                        new
                        {
                            Id = new Guid("ef5ab7e8-47ed-4261-80d2-f9d7b02b198e"),
                            BrandId = new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                            CategoryId = new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            IsDeleted = false,
                            Name = "Purple React Woolen Hat",
                            OfferPrice = 12.0m,
                            OriginalPrice = 15.0m,
                            Stock = 45
                        },
                        new
                        {
                            Id = new Guid("9ef559ad-ebe5-4a10-9d2c-0c0f2d4c7b6d"),
                            BrandId = new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                            CategoryId = new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                            IsDeleted = false,
                            Name = "Blue Code Gloves",
                            OfferPrice = 16.0m,
                            OriginalPrice = 18.0m,
                            Stock = 45
                        },
                        new
                        {
                            Id = new Guid("8b34ab33-f924-464a-8a77-c52ff76e3b76"),
                            BrandId = new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                            CategoryId = new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                            IsDeleted = false,
                            Name = "Green Code Gloves",
                            OfferPrice = 12.0m,
                            OriginalPrice = 15.0m,
                            Stock = 56
                        },
                        new
                        {
                            Id = new Guid("611fce20-b306-4411-8f53-e2f1e2a12077"),
                            BrandId = new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                            CategoryId = new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.",
                            IsDeleted = false,
                            Name = "Purple React Gloves",
                            OfferPrice = 14.0m,
                            OriginalPrice = 16.0m,
                            Stock = 21
                        },
                        new
                        {
                            Id = new Guid("2b3701d2-26f2-4471-8e0b-938797d46a67"),
                            BrandId = new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                            CategoryId = new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                            IsDeleted = false,
                            Name = "Green React Gloves",
                            OfferPrice = 12.0m,
                            OriginalPrice = 14.0m,
                            Stock = 45
                        },
                        new
                        {
                            Id = new Guid("fb7f8a6c-049d-4a41-b4cd-22d51189bc0a"),
                            BrandId = new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                            CategoryId = new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                            IsDeleted = false,
                            Name = "Redis Red Boots",
                            OfferPrice = 230.0m,
                            OriginalPrice = 250.0m,
                            Stock = 45
                        },
                        new
                        {
                            Id = new Guid("c3703c67-14f2-4e2d-885d-cb579780d99a"),
                            BrandId = new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                            CategoryId = new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            IsDeleted = false,
                            Name = "Core Red Boots",
                            OfferPrice = 170.0m,
                            OriginalPrice = 189.99m,
                            Stock = 11
                        },
                        new
                        {
                            Id = new Guid("09a1c2d1-3437-49d6-bb21-5d6e67a85ac4"),
                            BrandId = new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                            CategoryId = new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                            IsDeleted = false,
                            Name = "Core Purple Boots",
                            OfferPrice = 199.99m,
                            OriginalPrice = 199.99m,
                            Stock = 34
                        },
                        new
                        {
                            Id = new Guid("d6f88cea-37f4-4918-b146-e1f95ac2b7c2"),
                            BrandId = new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                            CategoryId = new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                            IsDeleted = false,
                            Name = "Angular Purple Boots",
                            OfferPrice = 140m,
                            OriginalPrice = 150m,
                            Stock = 23
                        },
                        new
                        {
                            Id = new Guid("a8222b7e-ab8f-45ab-8f37-439475700c31"),
                            BrandId = new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                            CategoryId = new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                            CreatedAt = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                            IsDeleted = false,
                            Name = "Angular Blue Boots",
                            OfferPrice = 160m,
                            OriginalPrice = 180m,
                            Stock = 12
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("E_Commerce.DAL.Models.Address", b =>
                {
                    b.HasOne("E_Commerce.DAL.Models.ApplicationUser", "AppUser")
                        .WithOne("Address")
                        .HasForeignKey("E_Commerce.DAL.Models.Address", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("E_Commerce.DAL.Models.Image", b =>
                {
                    b.HasOne("E_Commerce.DAL.Models.Product", null)
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce.DAL.Models.Product", b =>
                {
                    b.HasOne("E_Commerce.DAL.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.DAL.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("E_Commerce.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("E_Commerce.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("E_Commerce.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce.DAL.Models.ApplicationUser", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce.DAL.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("E_Commerce.DAL.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("E_Commerce.DAL.Models.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}

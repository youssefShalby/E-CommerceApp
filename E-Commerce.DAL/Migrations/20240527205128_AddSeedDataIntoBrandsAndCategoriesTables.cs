using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    public partial class AddSeedDataIntoBrandsAndCategoriesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"), new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(4518), false, "VS Code" },
                    { new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"), new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(4326), false, "Angular" },
                    { new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"), new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(4495), false, "NetCore" },
                    { new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"), new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(4539), false, "React" },
                    { new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"), new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(4561), false, "Typescript" },
                    { new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"), new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(4588), false, "Redis" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"), new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(209), false, "Hats" },
                    { new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"), new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(259), false, "Gloves" },
                    { new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"), new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(236), false, "Boots" },
                    { new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"), new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(22), false, "Boards" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"));
        }
    }
}

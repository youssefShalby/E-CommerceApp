using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    public partial class AddSeedDataIntoProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(6161));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(6206));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(2266));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 52, 7, 970, DateTimeKind.Local).AddTicks(2167));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "IsDeleted", "Name", "OfferPrice", "OriginalPrice", "Stock" },
                values: new object[,]
                {
                    { new Guid("09a1c2d1-3437-49d6-bb21-5d6e67a85ac4"), new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"), new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", false, "Core Purple Boots", 199.99m, 199.99m, 34 },
                    { new Guid("0ffdac50-e316-4e89-8d84-e51ac8c0733a"), new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"), new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", false, "Typescript Entry Board", 100.0m, 120.0m, 21 },
                    { new Guid("267475b7-e1b3-40f0-b06a-c57d8611e3da"), new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"), new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", false, "Core Board Speed Rush 3", 160.0m, 180.0m, 23 },
                    { new Guid("2b3701d2-26f2-4471-8e0b-938797d46a67"), new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"), new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", false, "Green React Gloves", 12.0m, 14.0m, 45 },
                    { new Guid("3868d8c2-1f85-5a4f-b5f3-2ac4867eab18"), new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"), new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joe nec lorem. Donec laoreet nonummy augue.", false, "Js Entry Board", 8.0m, 10.0m, 21 },
                    { new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"), new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"), new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", false, "Green React Woolen Hat", 6.0m, 8.0m, 21 },
                    { new Guid("3d5d1b58-e91e-4850-9cae-f62fa4e4caef"), new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"), new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "React Board Super Whizzy Fast", 230.0m, 250.0m, 45 },
                    { new Guid("611fce20-b306-4411-8f53-e2f1e2a12077"), new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"), new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.", false, "Purple React Gloves", 14.0m, 16.0m, 21 },
                    { new Guid("654e440f-8ed4-4eaf-a48b-60638f065057"), new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"), new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", false, "Net Core Super Board", 280.0m, 300.0m, 34 },
                    { new Guid("8b34ab33-f924-464a-8a77-c52ff76e3b76"), new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"), new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", false, "Green Code Gloves", 12.0m, 15.0m, 56 },
                    { new Guid("9ef559ad-ebe5-4a10-9d2c-0c0f2d4c7b6d"), new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"), new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", false, "Blue Code Gloves", 16.0m, 18.0m, 45 },
                    { new Guid("a1f6e281-7f30-442e-a95e-22eb82e0ccaf"), new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"), new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", false, "Green Angular Board 3000", 140.0m, 150.0m, 20 },
                    { new Guid("a8222b7e-ab8f-45ab-8f37-439475700c31"), new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"), new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", false, "Angular Blue Boots", 160m, 180m, 12 },
                    { new Guid("c3703c67-14f2-4e2d-885d-cb579780d99a"), new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"), new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Core Red Boots", 170.0m, 189.99m, 11 },
                    { new Guid("d6866a9c-9035-4a70-8371-5707b00f77f1"), new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"), new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Angular Speedster Board 2000", 180.0m, 200.0m, 12 },
                    { new Guid("d6f88cea-37f4-4918-b146-e1f95ac2b7c2"), new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"), new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", false, "Angular Purple Boots", 140m, 150m, 23 },
                    { new Guid("ef5ab7e8-47ed-4261-80d2-f9d7b02b198e"), new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"), new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Purple React Woolen Hat", 12.0m, 15.0m, 45 },
                    { new Guid("fb7f8a6c-049d-4a41-b4cd-22d51189bc0a"), new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"), new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", false, "Redis Red Boots", 230.0m, 250.0m, 45 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("09a1c2d1-3437-49d6-bb21-5d6e67a85ac4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ffdac50-e316-4e89-8d84-e51ac8c0733a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("267475b7-e1b3-40f0-b06a-c57d8611e3da"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2b3701d2-26f2-4471-8e0b-938797d46a67"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3868d8c2-1f85-5a4f-b5f3-2ac4867eab18"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3d5d1b58-e91e-4850-9cae-f62fa4e4caef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("611fce20-b306-4411-8f53-e2f1e2a12077"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("654e440f-8ed4-4eaf-a48b-60638f065057"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8b34ab33-f924-464a-8a77-c52ff76e3b76"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9ef559ad-ebe5-4a10-9d2c-0c0f2d4c7b6d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1f6e281-7f30-442e-a95e-22eb82e0ccaf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a8222b7e-ab8f-45ab-8f37-439475700c31"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c3703c67-14f2-4e2d-885d-cb579780d99a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d6866a9c-9035-4a70-8371-5707b00f77f1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d6f88cea-37f4-4918-b146-e1f95ac2b7c2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef5ab7e8-47ed-4261-80d2-f9d7b02b198e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fb7f8a6c-049d-4a41-b4cd-22d51189bc0a"));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(259));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 23, 51, 27, 897, DateTimeKind.Local).AddTicks(22));
        }
    }
}

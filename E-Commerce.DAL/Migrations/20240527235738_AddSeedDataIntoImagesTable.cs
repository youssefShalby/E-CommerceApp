using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    public partial class AddSeedDataIntoImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 2, 57, 38, 553, DateTimeKind.Local).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 2, 57, 38, 553, DateTimeKind.Local).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 2, 57, 38, 553, DateTimeKind.Local).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 2, 57, 38, 553, DateTimeKind.Local).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 2, 57, 38, 553, DateTimeKind.Local).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 2, 57, 38, 553, DateTimeKind.Local).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 2, 57, 38, 553, DateTimeKind.Local).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 2, 57, 38, 553, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 2, 57, 38, 553, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 2, 57, 38, 553, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("05f12a90-2c51-4b19-9e01-ba6d48a93f07"), new Guid("a8222b7e-ab8f-45ab-8f37-439475700c31"), "https://example.com/image21.jpg" },
                    { new Guid("1fc2383e-aa15-4498-a98c-ef053ac30c78"), new Guid("0ffdac50-e316-4e89-8d84-e51ac8c0733a"), "https://example.com/image9.jpg" },
                    { new Guid("206bc21e-2873-42e5-8a51-1d204d53f7d8"), new Guid("611fce20-b306-4411-8f53-e2f1e2a12077"), "https://example.com/image35.jpg" },
                    { new Guid("22bfcdf8-9621-4c44-b2f7-5d8d9b9e0b58"), new Guid("a1f6e281-7f30-442e-a95e-22eb82e0ccaf"), "https://example.com/image2.jpg" },
                    { new Guid("24421ed7-b72f-4f55-b671-5b1f871dd9ae"), new Guid("3d5d1b58-e91e-4850-9cae-f62fa4e4caef"), "https://example.com/image11.jpg" },
                    { new Guid("30e5a2b1-94fb-45ab-b7c1-0b6469a7a083"), new Guid("8b34ab33-f924-464a-8a77-c52ff76e3b76"), "https://example.com/image33.jpg" },
                    { new Guid("380ebe28-c526-4532-bd94-36930a7e13b8"), new Guid("8b34ab33-f924-464a-8a77-c52ff76e3b76"), "https://example.com/image34.jpg" },
                    { new Guid("418df7a2-8ba7-46b0-9e97-688fe64b6cd5"), new Guid("0ffdac50-e316-4e89-8d84-e51ac8c0733a"), "https://example.com/image10.jpg" },
                    { new Guid("49f5cd4f-c8ed-47db-a891-682f504987e9"), new Guid("9ef559ad-ebe5-4a10-9d2c-0c0f2d4c7b6d"), "https://example.com/image29.jpg" },
                    { new Guid("4e70a779-bbff-4a7c-80a9-c8484c35bbbf"), new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"), "https://example.com/image13.jpg" },
                    { new Guid("59a9c11c-e6a0-4d6e-a6fb-3c83fb80db27"), new Guid("611fce20-b306-4411-8f53-e2f1e2a12077"), "https://example.com/image36.jpg" },
                    { new Guid("62f27cb3-f567-4de5-9f69-8ef3e2f6d7ed"), new Guid("ef5ab7e8-47ed-4261-80d2-f9d7b02b198e"), "https://example.com/image18.jpg" },
                    { new Guid("71509e2c-4c33-4323-9d08-9f5b0f67b53e"), new Guid("c3703c67-14f2-4e2d-885d-cb579780d99a"), "https://example.com/image25.jpg" },
                    { new Guid("7d22d723-4412-49cd-9a42-6a8c1d3726f4"), new Guid("d6f88cea-37f4-4918-b146-e1f95ac2b7c2"), "https://example.com/image27.jpg" },
                    { new Guid("87d6f253-0d5b-4d72-a8e6-8c58af63f7d2"), new Guid("d6866a9c-9035-4a70-8371-5707b00f77f1"), "https://example.com/image4.jpg" },
                    { new Guid("946da92c-1486-4b40-9e53-6b158e14f86f"), new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"), "https://example.com/image14.jpg" },
                    { new Guid("97a0e3a3-0b46-42cc-95f5-d56e51db20e0"), new Guid("c3703c67-14f2-4e2d-885d-cb579780d99a"), "https://example.com/image26.jpg" },
                    { new Guid("98296268-6d9a-4648-8d54-01c2225ad193"), new Guid("fb7f8a6c-049d-4a41-b4cd-22d51189bc0a"), "https://example.com/image20.jpg" },
                    { new Guid("9b5d60e4-f7f3-4b18-b3df-ef51849193d4"), new Guid("654e440f-8ed4-4eaf-a48b-60638f065057"), "https://example.com/image6.jpg" },
                    { new Guid("a5f24eb9-863b-4d0b-b309-67a3d1e5a1a1"), new Guid("a1f6e281-7f30-442e-a95e-22eb82e0ccaf"), "https://example.com/image1.jpg" },
                    { new Guid("af09fdaf-778e-4428-9d92-d701a7a25fb2"), new Guid("3868d8c2-1f85-5a4f-b5f3-2ac4867eab18"), "https://example.com/image15.jpg" },
                    { new Guid("b52dfc4b-86d4-4f46-8041-5a71a8ffdbbb"), new Guid("9ef559ad-ebe5-4a10-9d2c-0c0f2d4c7b6d"), "https://example.com/image30.jpg" },
                    { new Guid("b59ae2b3-65d7-4e71-9fa8-643606e65a76"), new Guid("d6f88cea-37f4-4918-b146-e1f95ac2b7c2"), "https://example.com/image28.jpg" },
                    { new Guid("cc7a04e4-769d-4c69-83b0-90107080f3f7"), new Guid("a8222b7e-ab8f-45ab-8f37-439475700c31"), "https://example.com/image22.jpg" },
                    { new Guid("ce401b9e-548a-4585-ae4f-c4b12c2e88d8"), new Guid("267475b7-e1b3-40f0-b06a-c57d8611e3da"), "https://example.com/image8.jpg" },
                    { new Guid("dcd127a2-460e-4645-8d32-0c510b3bdf82"), new Guid("09a1c2d1-3437-49d6-bb21-5d6e67a85ac4"), "https://example.com/image24.jpg" },
                    { new Guid("e7b4b6ef-d937-4c32-bb24-68e1d150e05b"), new Guid("d6866a9c-9035-4a70-8371-5707b00f77f1"), "https://example.com/image3.jpg" },
                    { new Guid("e8889b50-31ed-4795-8991-d63b8f62df6a"), new Guid("2b3701d2-26f2-4471-8e0b-938797d46a67"), "https://example.com/image32.jpg" },
                    { new Guid("ec39cfa7-f122-40db-92b2-f1993f4a89d0"), new Guid("3d5d1b58-e91e-4850-9cae-f62fa4e4caef"), "https://example.com/image12.jpg" },
                    { new Guid("f84f2464-bb4c-4d33-b176-8cb94c72264b"), new Guid("267475b7-e1b3-40f0-b06a-c57d8611e3da"), "https://example.com/image7.jpg" },
                    { new Guid("f8990f52-3fa4-4f9a-b4d4-9b51a9ffbc8b"), new Guid("3868d8c2-1f85-5a4f-b5f3-2ac4867eab18"), "https://example.com/image16.jpg" },
                    { new Guid("f9cb1b95-1e78-4b27-b320-63c0d4f6cbf2"), new Guid("ef5ab7e8-47ed-4261-80d2-f9d7b02b198e"), "https://example.com/image17.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("fa13908b-01e4-4aa7-a363-5db54e8d3cb2"), new Guid("2b3701d2-26f2-4471-8e0b-938797d46a67"), "https://example.com/image31.jpg" },
                    { new Guid("fd5cf950-8479-4c7d-bf1e-c82af6d1ecab"), new Guid("654e440f-8ed4-4eaf-a48b-60638f065057"), "https://example.com/image5.jpg" },
                    { new Guid("fdd9f9c3-6d9a-4648-9d34-03c4425ad193"), new Guid("fb7f8a6c-049d-4a41-b4cd-22d51189bc0a"), "https://example.com/image19.jpg" },
                    { new Guid("fe444fac-67a7-4841-a670-d9e1d83b63dc"), new Guid("09a1c2d1-3437-49d6-bb21-5d6e67a85ac4"), "https://example.com/image23.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("05f12a90-2c51-4b19-9e01-ba6d48a93f07"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("1fc2383e-aa15-4498-a98c-ef053ac30c78"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("206bc21e-2873-42e5-8a51-1d204d53f7d8"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("22bfcdf8-9621-4c44-b2f7-5d8d9b9e0b58"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("24421ed7-b72f-4f55-b671-5b1f871dd9ae"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("30e5a2b1-94fb-45ab-b7c1-0b6469a7a083"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("380ebe28-c526-4532-bd94-36930a7e13b8"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("418df7a2-8ba7-46b0-9e97-688fe64b6cd5"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("49f5cd4f-c8ed-47db-a891-682f504987e9"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("4e70a779-bbff-4a7c-80a9-c8484c35bbbf"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("59a9c11c-e6a0-4d6e-a6fb-3c83fb80db27"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("62f27cb3-f567-4de5-9f69-8ef3e2f6d7ed"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("71509e2c-4c33-4323-9d08-9f5b0f67b53e"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("7d22d723-4412-49cd-9a42-6a8c1d3726f4"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("87d6f253-0d5b-4d72-a8e6-8c58af63f7d2"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("946da92c-1486-4b40-9e53-6b158e14f86f"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("97a0e3a3-0b46-42cc-95f5-d56e51db20e0"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("98296268-6d9a-4648-8d54-01c2225ad193"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("9b5d60e4-f7f3-4b18-b3df-ef51849193d4"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("a5f24eb9-863b-4d0b-b309-67a3d1e5a1a1"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("af09fdaf-778e-4428-9d92-d701a7a25fb2"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("b52dfc4b-86d4-4f46-8041-5a71a8ffdbbb"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("b59ae2b3-65d7-4e71-9fa8-643606e65a76"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("cc7a04e4-769d-4c69-83b0-90107080f3f7"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("ce401b9e-548a-4585-ae4f-c4b12c2e88d8"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("dcd127a2-460e-4645-8d32-0c510b3bdf82"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("e7b4b6ef-d937-4c32-bb24-68e1d150e05b"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("e8889b50-31ed-4795-8991-d63b8f62df6a"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("ec39cfa7-f122-40db-92b2-f1993f4a89d0"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("f84f2464-bb4c-4d33-b176-8cb94c72264b"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("f8990f52-3fa4-4f9a-b4d4-9b51a9ffbc8b"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("f9cb1b95-1e78-4b27-b320-63c0d4f6cbf2"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("fa13908b-01e4-4aa7-a363-5db54e8d3cb2"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("fd5cf950-8479-4c7d-bf1e-c82af6d1ecab"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("fdd9f9c3-6d9a-4648-9d34-03c4425ad193"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("fe444fac-67a7-4841-a670-d9e1d83b63dc"));

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
        }
    }
}

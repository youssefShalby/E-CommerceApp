using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    public partial class AddSeedDataIntoDelivaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 38, 34, 82, DateTimeKind.Local).AddTicks(2320));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 38, 34, 82, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 38, 34, 82, DateTimeKind.Local).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 38, 34, 82, DateTimeKind.Local).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 38, 34, 82, DateTimeKind.Local).AddTicks(2345));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 38, 34, 82, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 38, 34, 82, DateTimeKind.Local).AddTicks(361));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 38, 34, 82, DateTimeKind.Local).AddTicks(387));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 38, 34, 82, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 38, 34, 82, DateTimeKind.Local).AddTicks(315));

            migrationBuilder.InsertData(
                table: "DeliveryMethods",
                columns: new[] { "Id", "DeliveryTime", "Description", "Price", "ShortName" },
                values: new object[,]
                {
                    { new Guid("9c7f4d0b-6f8e-467b-b3e5-24f1a6b7d799"), "1-2 Weeks", "Free! You get what you pay for", 0m, "FREE" },
                    { new Guid("aa89df48-3c8f-431e-b88b-fefc0e6bb8c0"), "5-10 Days", "Slower but cheap", 2m, "UPS3" },
                    { new Guid("e56ff70b-8f12-4b59-a5b4-32a7d9d8a1a1"), "2-5 Days", "Get it within 5 days", 5m, "UPS2" },
                    { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "1-2 Days", "Fastest delivery time", 10m, "UPS1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("9c7f4d0b-6f8e-467b-b3e5-24f1a6b7d799"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("aa89df48-3c8f-431e-b88b-fefc0e6bb8c0"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("e56ff70b-8f12-4b59-a5b4-32a7d9d8a1a1"));

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 36, 52, 994, DateTimeKind.Local).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 36, 52, 994, DateTimeKind.Local).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 36, 52, 994, DateTimeKind.Local).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 36, 52, 994, DateTimeKind.Local).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 36, 52, 994, DateTimeKind.Local).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 36, 52, 994, DateTimeKind.Local).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 36, 52, 994, DateTimeKind.Local).AddTicks(2140));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 36, 52, 994, DateTimeKind.Local).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 36, 52, 994, DateTimeKind.Local).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 36, 52, 994, DateTimeKind.Local).AddTicks(2086));
        }
    }
}

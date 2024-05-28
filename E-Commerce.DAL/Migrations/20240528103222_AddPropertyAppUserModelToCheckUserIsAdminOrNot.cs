using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    public partial class AddPropertyAppUserModelToCheckUserIsAdminOrNot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 13, 32, 21, 697, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 13, 32, 21, 697, DateTimeKind.Local).AddTicks(3274));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 13, 32, 21, 697, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 13, 32, 21, 697, DateTimeKind.Local).AddTicks(3356));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 13, 32, 21, 697, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 13, 32, 21, 697, DateTimeKind.Local).AddTicks(3383));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 13, 32, 21, 697, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 13, 32, 21, 697, DateTimeKind.Local).AddTicks(1242));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 13, 32, 21, 697, DateTimeKind.Local).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 13, 32, 21, 697, DateTimeKind.Local).AddTicks(1169));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");

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
        }
    }
}

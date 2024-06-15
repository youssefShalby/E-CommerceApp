using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    public partial class removeRelationBetweenUserAndOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 13, 1, 14, 611, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 13, 1, 14, 610, DateTimeKind.Local).AddTicks(9971));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 13, 1, 14, 611, DateTimeKind.Local).AddTicks(61));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 13, 1, 14, 611, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 13, 1, 14, 611, DateTimeKind.Local).AddTicks(124));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 13, 1, 14, 611, DateTimeKind.Local).AddTicks(148));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 13, 1, 14, 610, DateTimeKind.Local).AddTicks(6478));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 13, 1, 14, 610, DateTimeKind.Local).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 13, 1, 14, 610, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 13, 1, 14, 610, DateTimeKind.Local).AddTicks(6378));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 11, 50, 23, 852, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 11, 50, 23, 852, DateTimeKind.Local).AddTicks(9523));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 11, 50, 23, 852, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 11, 50, 23, 852, DateTimeKind.Local).AddTicks(9654));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 11, 50, 23, 852, DateTimeKind.Local).AddTicks(9676));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 11, 50, 23, 852, DateTimeKind.Local).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 11, 50, 23, 852, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 11, 50, 23, 852, DateTimeKind.Local).AddTicks(6546));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 11, 50, 23, 852, DateTimeKind.Local).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 11, 50, 23, 852, DateTimeKind.Local).AddTicks(6420));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

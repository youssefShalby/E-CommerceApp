using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    public partial class DropShipmentAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShipmentAddresses_ShipToAddressId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ShipmentAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipToAddressId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 31, 36, 574, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 31, 36, 574, DateTimeKind.Local).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 31, 36, 574, DateTimeKind.Local).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 31, 36, 574, DateTimeKind.Local).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 31, 36, 574, DateTimeKind.Local).AddTicks(6525));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 31, 36, 574, DateTimeKind.Local).AddTicks(6543));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 31, 36, 573, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 31, 36, 573, DateTimeKind.Local).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 31, 36, 573, DateTimeKind.Local).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 31, 36, 573, DateTimeKind.Local).AddTicks(7221));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShipmentAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentAddresses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 42, 21, 335, DateTimeKind.Local).AddTicks(1));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 42, 21, 334, DateTimeKind.Local).AddTicks(9929));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 42, 21, 334, DateTimeKind.Local).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 42, 21, 335, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 42, 21, 335, DateTimeKind.Local).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 42, 21, 335, DateTimeKind.Local).AddTicks(42));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 42, 21, 334, DateTimeKind.Local).AddTicks(7862));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 42, 21, 334, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 42, 21, 334, DateTimeKind.Local).AddTicks(7877));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 29, 23, 42, 21, 334, DateTimeKind.Local).AddTicks(7807));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipToAddressId",
                table: "Orders",
                column: "ShipToAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShipmentAddresses_ShipToAddressId",
                table: "Orders",
                column: "ShipToAddressId",
                principalTable: "ShipmentAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

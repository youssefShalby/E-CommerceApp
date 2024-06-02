using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    public partial class MakeShipmentAddressModelBelongsToOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipToAddressId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "ShipToAddress_City",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipToAddress_FirstName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipToAddress_Id",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipToAddress_LastName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipToAddress_State",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipToAddress_Street",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipToAddress_Zipcode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3b1683e2-05dc-4d2e-a30b-26c5e0d95667"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 33, 45, 948, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("63b02c28-3053-47c6-8d60-f5a78dd8b03d"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 33, 45, 948, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("78f5b4d1-44c5-471f-ae13-6d17c2d1f4d8"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 33, 45, 948, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c7a7996a-5f59-4a58-aad0-96bca0b37028"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 33, 45, 948, DateTimeKind.Local).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("da02908b-fcdb-4d0f-ba5f-2d0590377800"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 33, 45, 948, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("fb73255d-8682-4f63-90c0-6deff6a85840"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 33, 45, 948, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d6b90a1-e79d-4d3b-88fd-d204daed7fbf"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 33, 45, 948, DateTimeKind.Local).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7878d7c2-1f85-4a4f-b5f1-1ac4877eab19"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 33, 45, 948, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94934e39-4008-4b57-8144-03f2a24b22eb"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 33, 45, 948, DateTimeKind.Local).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c13e06ae-2f07-45a7-99dc-38a5f93d2fd6"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 20, 33, 45, 948, DateTimeKind.Local).AddTicks(2205));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipToAddress_City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipToAddress_FirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipToAddress_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipToAddress_LastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipToAddress_State",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipToAddress_Street",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipToAddress_Zipcode",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "ShipToAddressId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}

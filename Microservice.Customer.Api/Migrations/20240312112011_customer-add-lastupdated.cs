using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservice.Customer.Migrations
{
    /// <inheritdoc />
    public partial class customeraddlastupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("2385de72-2302-4ced-866a-fa199116ca6e"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1354), new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1356) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("47417642-87d9-4047-ae13-4c721d99ab48"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1358), new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1359) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("55b431ff-693e-4664-8f65-cfd8d0b14b1b"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1350), new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1352) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("5ff79dfe-c1fa-4dd9-996f-bc96649d6dfc"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1368), new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("aa1dc96f-3be5-41cd-8a1b-207284af3fdd"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1290), new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1335) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("ae55b0d1-ba02-41e1-9efa-9b4d4ac15eec"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1372), new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1373) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("af95fb7e-8d97-4892-8da3-5e6e51c54044"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1345), new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1346) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1376), new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1377) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("f07e88ac-53b2-4def-af07-957cbb18523c"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1381), new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1382) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("ff4d5a80-81e3-42e3-8052-92cf5c51e797"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1364), new DateTime(2024, 3, 12, 11, 20, 11, 729, DateTimeKind.Local).AddTicks(1365) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Customer");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("2385de72-2302-4ced-866a-fa199116ca6e"),
                column: "Created",
                value: new DateTime(2024, 3, 12, 11, 4, 35, 275, DateTimeKind.Local).AddTicks(5739));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("47417642-87d9-4047-ae13-4c721d99ab48"),
                column: "Created",
                value: new DateTime(2024, 3, 12, 11, 4, 35, 275, DateTimeKind.Local).AddTicks(5741));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("55b431ff-693e-4664-8f65-cfd8d0b14b1b"),
                column: "Created",
                value: new DateTime(2024, 3, 12, 11, 4, 35, 275, DateTimeKind.Local).AddTicks(5736));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("5ff79dfe-c1fa-4dd9-996f-bc96649d6dfc"),
                column: "Created",
                value: new DateTime(2024, 3, 12, 11, 4, 35, 275, DateTimeKind.Local).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("aa1dc96f-3be5-41cd-8a1b-207284af3fdd"),
                column: "Created",
                value: new DateTime(2024, 3, 12, 11, 4, 35, 275, DateTimeKind.Local).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("ae55b0d1-ba02-41e1-9efa-9b4d4ac15eec"),
                column: "Created",
                value: new DateTime(2024, 3, 12, 11, 4, 35, 275, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("af95fb7e-8d97-4892-8da3-5e6e51c54044"),
                column: "Created",
                value: new DateTime(2024, 3, 12, 11, 4, 35, 275, DateTimeKind.Local).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"),
                column: "Created",
                value: new DateTime(2024, 3, 12, 11, 4, 35, 275, DateTimeKind.Local).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("f07e88ac-53b2-4def-af07-957cbb18523c"),
                column: "Created",
                value: new DateTime(2024, 3, 12, 11, 4, 35, 275, DateTimeKind.Local).AddTicks(5755));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("ff4d5a80-81e3-42e3-8052-92cf5c51e797"),
                column: "Created",
                value: new DateTime(2024, 3, 12, 11, 4, 35, 275, DateTimeKind.Local).AddTicks(5745));
        }
    }
}

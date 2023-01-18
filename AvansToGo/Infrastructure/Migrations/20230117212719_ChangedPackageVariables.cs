using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ChangedPackageVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 27, 22, 27, 19, 31, DateTimeKind.Local).AddTicks(8907), new DateTime(2023, 1, 14, 22, 27, 19, 31, DateTimeKind.Local).AddTicks(8878) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart", "Type" },
                values: new object[] { new DateTime(2023, 1, 21, 22, 27, 19, 31, DateTimeKind.Local).AddTicks(8916), new DateTime(2023, 1, 15, 22, 27, 19, 31, DateTimeKind.Local).AddTicks(8914), 1 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 19, 22, 27, 19, 31, DateTimeKind.Local).AddTicks(8922), new DateTime(2023, 1, 10, 22, 27, 19, 31, DateTimeKind.Local).AddTicks(8920) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Packages");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 23, 17, 10, 58, 615, DateTimeKind.Local).AddTicks(2183), new DateTime(2023, 1, 10, 17, 10, 58, 615, DateTimeKind.Local).AddTicks(2153) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 17, 17, 10, 58, 615, DateTimeKind.Local).AddTicks(2194), new DateTime(2023, 1, 11, 17, 10, 58, 615, DateTimeKind.Local).AddTicks(2191) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 15, 17, 10, 58, 615, DateTimeKind.Local).AddTicks(2200), new DateTime(2023, 1, 6, 17, 10, 58, 615, DateTimeKind.Local).AddTicks(2198) });
        }
    }
}

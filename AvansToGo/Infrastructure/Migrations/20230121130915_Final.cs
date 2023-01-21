using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 31, 14, 9, 14, 886, DateTimeKind.Local).AddTicks(8637), new DateTime(2023, 1, 18, 14, 9, 14, 886, DateTimeKind.Local).AddTicks(8603) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 25, 14, 9, 14, 886, DateTimeKind.Local).AddTicks(8647), new DateTime(2023, 1, 19, 14, 9, 14, 886, DateTimeKind.Local).AddTicks(8645) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 23, 14, 9, 14, 886, DateTimeKind.Local).AddTicks(8653), new DateTime(2023, 1, 14, 14, 9, 14, 886, DateTimeKind.Local).AddTicks(8651) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 28, 15, 35, 35, 634, DateTimeKind.Local).AddTicks(5257), new DateTime(2023, 1, 15, 15, 35, 35, 634, DateTimeKind.Local).AddTicks(5219) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 22, 15, 35, 35, 634, DateTimeKind.Local).AddTicks(5270), new DateTime(2023, 1, 16, 15, 35, 35, 634, DateTimeKind.Local).AddTicks(5267) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 20, 15, 35, 35, 634, DateTimeKind.Local).AddTicks(5278), new DateTime(2023, 1, 11, 15, 35, 35, 634, DateTimeKind.Local).AddTicks(5276) });
        }
    }
}

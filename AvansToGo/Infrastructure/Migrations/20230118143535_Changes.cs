using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 21, 22, 27, 19, 31, DateTimeKind.Local).AddTicks(8916), new DateTime(2023, 1, 15, 22, 27, 19, 31, DateTimeKind.Local).AddTicks(8914) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 19, 22, 27, 19, 31, DateTimeKind.Local).AddTicks(8922), new DateTime(2023, 1, 10, 22, 27, 19, 31, DateTimeKind.Local).AddTicks(8920) });
        }
    }
}

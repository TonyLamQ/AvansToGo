using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ChangedPackageData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 23, 8, 43, 11, 820, DateTimeKind.Local).AddTicks(6364), new DateTime(2023, 1, 10, 8, 43, 11, 820, DateTimeKind.Local).AddTicks(6329) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 17, 8, 43, 11, 820, DateTimeKind.Local).AddTicks(6380), new DateTime(2023, 1, 11, 8, 43, 11, 820, DateTimeKind.Local).AddTicks(6377) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 15, 8, 43, 11, 820, DateTimeKind.Local).AddTicks(6388), new DateTime(2023, 1, 6, 8, 43, 11, 820, DateTimeKind.Local).AddTicks(6385) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 19, 17, 54, 15, 571, DateTimeKind.Local).AddTicks(5770), new DateTime(2023, 1, 6, 17, 54, 15, 571, DateTimeKind.Local).AddTicks(5736) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 13, 17, 54, 15, 571, DateTimeKind.Local).AddTicks(5777), new DateTime(2023, 1, 7, 17, 54, 15, 571, DateTimeKind.Local).AddTicks(5776) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 11, 17, 54, 15, 571, DateTimeKind.Local).AddTicks(5783), new DateTime(2023, 1, 2, 17, 54, 15, 571, DateTimeKind.Local).AddTicks(5781) });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ChangePackageData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 16, 14, 42, 20, 756, DateTimeKind.Local).AddTicks(5906), new DateTime(2023, 1, 3, 14, 42, 20, 756, DateTimeKind.Local).AddTicks(5874) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test2",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 10, 14, 42, 20, 756, DateTimeKind.Local).AddTicks(5914), new DateTime(2023, 1, 4, 14, 42, 20, 756, DateTimeKind.Local).AddTicks(5912) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test3",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 8, 14, 42, 20, 756, DateTimeKind.Local).AddTicks(5919), new DateTime(2022, 12, 30, 14, 42, 20, 756, DateTimeKind.Local).AddTicks(5918) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test2",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test3",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { null, null });
        }
    }
}

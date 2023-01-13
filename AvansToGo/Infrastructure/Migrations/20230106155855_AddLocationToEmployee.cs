using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddLocationToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CanteenLocation",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "CanteenLocation",
                value: "La");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 16, 16, 58, 54, 980, DateTimeKind.Local).AddTicks(7513), new DateTime(2023, 1, 3, 16, 58, 54, 980, DateTimeKind.Local).AddTicks(7463) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test2",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 10, 16, 58, 54, 980, DateTimeKind.Local).AddTicks(7521), new DateTime(2023, 1, 4, 16, 58, 54, 980, DateTimeKind.Local).AddTicks(7519) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test3",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 8, 16, 58, 54, 980, DateTimeKind.Local).AddTicks(7528), new DateTime(2022, 12, 30, 16, 58, 54, 980, DateTimeKind.Local).AddTicks(7526) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanteenLocation",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 16, 15, 27, 7, 851, DateTimeKind.Local).AddTicks(8492), new DateTime(2023, 1, 3, 15, 27, 7, 851, DateTimeKind.Local).AddTicks(8462) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test2",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 10, 15, 27, 7, 851, DateTimeKind.Local).AddTicks(8502), new DateTime(2023, 1, 4, 15, 27, 7, 851, DateTimeKind.Local).AddTicks(8500) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test3",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 8, 15, 27, 7, 851, DateTimeKind.Local).AddTicks(8507), new DateTime(2022, 12, 30, 15, 27, 7, 851, DateTimeKind.Local).AddTicks(8505) });
        }
    }
}

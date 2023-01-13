using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddEmailToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "Email",
                value: "Employee@gmail.com");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 16, 17, 41, 27, 317, DateTimeKind.Local).AddTicks(6919), new DateTime(2023, 1, 3, 17, 41, 27, 317, DateTimeKind.Local).AddTicks(6881) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test2",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 10, 17, 41, 27, 317, DateTimeKind.Local).AddTicks(6928), new DateTime(2023, 1, 4, 17, 41, 27, 317, DateTimeKind.Local).AddTicks(6927) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test3",
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 8, 17, 41, 27, 317, DateTimeKind.Local).AddTicks(6934), new DateTime(2022, 12, 30, 17, 41, 27, 317, DateTimeKind.Local).AddTicks(6932) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class DeletePackageData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test");

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test2");

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId" },
                values: new object[] { "Test", "LA200", 0, true, new DateTime(2023, 1, 16, 14, 42, 20, 756, DateTimeKind.Local).AddTicks(5906), new DateTime(2023, 1, 3, 14, 42, 20, 756, DateTimeKind.Local).AddTicks(5874), 10.0, 1 });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId" },
                values: new object[] { "Test2", "LA300", 2, false, new DateTime(2023, 1, 10, 14, 42, 20, 756, DateTimeKind.Local).AddTicks(5914), new DateTime(2023, 1, 4, 14, 42, 20, 756, DateTimeKind.Local).AddTicks(5912), 13.0, null });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId" },
                values: new object[] { "Test3", "LA400", 1, true, new DateTime(2023, 1, 8, 14, 42, 20, 756, DateTimeKind.Local).AddTicks(5919), new DateTime(2022, 12, 30, 14, 42, 20, 756, DateTimeKind.Local).AddTicks(5918), 14.0, null });
        }
    }
}

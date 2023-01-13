using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ChangePackageData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Location",
                keyValue: "LA200");

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Location",
                keyValue: "LA300");

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Location",
                keyValue: "LA400");

            migrationBuilder.InsertData(
                table: "Canteens",
                columns: new[] { "Location", "City", "ServesHotMeals" },
                values: new object[] { "La", 0, true });

            migrationBuilder.InsertData(
                table: "Canteens",
                columns: new[] { "Location", "City", "ServesHotMeals" },
                values: new object[] { "Lc", 1, true });

            migrationBuilder.InsertData(
                table: "Canteens",
                columns: new[] { "Location", "City", "ServesHotMeals" },
                values: new object[] { "Ld", 2, false });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId" },
                values: new object[] { "Test", "La", 0, true, new DateTime(2023, 1, 16, 15, 27, 7, 851, DateTimeKind.Local).AddTicks(8492), new DateTime(2023, 1, 3, 15, 27, 7, 851, DateTimeKind.Local).AddTicks(8462), 10.0, 1 });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId" },
                values: new object[] { "Test2", "Ld", 2, false, new DateTime(2023, 1, 10, 15, 27, 7, 851, DateTimeKind.Local).AddTicks(8502), new DateTime(2023, 1, 4, 15, 27, 7, 851, DateTimeKind.Local).AddTicks(8500), 13.0, null });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId" },
                values: new object[] { "Test3", "Lc", 1, true, new DateTime(2023, 1, 8, 15, 27, 7, 851, DateTimeKind.Local).AddTicks(8507), new DateTime(2022, 12, 30, 15, 27, 7, 851, DateTimeKind.Local).AddTicks(8505), 14.0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Location",
                keyValue: "La");

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Location",
                keyValue: "Lc");

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Location",
                keyValue: "Ld");

            migrationBuilder.InsertData(
                table: "Canteens",
                columns: new[] { "Location", "City", "ServesHotMeals" },
                values: new object[] { "LA200", 0, true });

            migrationBuilder.InsertData(
                table: "Canteens",
                columns: new[] { "Location", "City", "ServesHotMeals" },
                values: new object[] { "LA300", 2, false });

            migrationBuilder.InsertData(
                table: "Canteens",
                columns: new[] { "Location", "City", "ServesHotMeals" },
                values: new object[] { "LA400", 1, true });
        }
    }
}

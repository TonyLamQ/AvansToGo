using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RenameVariables : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "ReservedByStudentId" },
                values: new object[] { "Test", "LA200", 0, true, null, null, 10.0, null });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "ReservedByStudentId" },
                values: new object[] { "Test2", "LA300", 2, false, null, null, 13.0, null });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "ReservedByStudentId" },
                values: new object[] { "Test3", "LA400", 1, true, null, null, 14.0, null });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class TestSeedingPackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "ReservedByStudentId" },
                values: new object[] { "Test", "LA200", 0, true, null, null, 10.0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test");
        }
    }
}

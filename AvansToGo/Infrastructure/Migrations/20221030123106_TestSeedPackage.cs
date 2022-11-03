using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class TestSeedPackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Canteens_CanteenLocation",
                table: "Packages");

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Name",
                keyValue: "Test");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "CanteenLocation",
                table: "Packages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "Canteens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Canteens",
                columns: new[] { "Location", "City", "ServesHotMeals" },
                values: new object[] { "LA200", 0, true });

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Canteens_CanteenLocation",
                table: "Packages",
                column: "CanteenLocation",
                principalTable: "Canteens",
                principalColumn: "Location",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Canteens_CanteenLocation",
                table: "Packages");

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Location",
                keyValue: "LA200");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CanteenLocation",
                table: "Packages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "Canteens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "ReservedByStudentId" },
                values: new object[] { "Test", null, 0, false, null, null, 10.0, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Canteens_CanteenLocation",
                table: "Packages",
                column: "CanteenLocation",
                principalTable: "Canteens",
                principalColumn: "Location");
        }
    }
}

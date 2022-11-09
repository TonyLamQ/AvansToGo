using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FillDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Students_StudentId",
                table: "Packages");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Packages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Canteens",
                columns: new[] { "Location", "City", "ServesHotMeals" },
                values: new object[,]
                {
                    { "LA200", 0, true },
                    { "LA300", 2, false },
                    { "LA400", 1, true }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "UserName" },
                values: new object[] { 1, "Tim" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "BirthDate", "City", "Email", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Student@gmail.com", "0612344321", "Peter" },
                    { 2, new DateTime(2003, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jan@gmail.com", "0622344321", "Jan" },
                    { 3, new DateTime(2002, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Esrid@gmail.com", "0632344321", "Esrid" }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId" },
                values: new object[] { "Test", "LA200", 0, true, null, null, 10.0, 1 });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId" },
                values: new object[] { "Test2", "LA300", 2, false, null, null, 13.0, null });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Name", "CanteenLocation", "City", "ContainsAlcohol", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId" },
                values: new object[] { "Test3", "LA400", 1, true, null, null, 14.0, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Students_StudentId",
                table: "Packages",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Students_StudentId",
                table: "Packages");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

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
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3);

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

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Students_StudentId",
                table: "Packages",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

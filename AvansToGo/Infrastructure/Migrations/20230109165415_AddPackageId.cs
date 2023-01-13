using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddPackageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Packages_PackageName",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PackageName",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packages",
                table: "Packages");

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

            migrationBuilder.DropColumn(
                name: "PackageName",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packages",
                table: "Packages",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CanteenLocation", "City", "ContainsAlcohol", "Name", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId" },
                values: new object[] { 1, "La", 0, true, "Test", new DateTime(2023, 1, 19, 17, 54, 15, 571, DateTimeKind.Local).AddTicks(5770), new DateTime(2023, 1, 6, 17, 54, 15, 571, DateTimeKind.Local).AddTicks(5736), 10.0, 1 });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CanteenLocation", "City", "ContainsAlcohol", "Name", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId" },
                values: new object[] { 2, "Ld", 2, false, "Test2", new DateTime(2023, 1, 13, 17, 54, 15, 571, DateTimeKind.Local).AddTicks(5777), new DateTime(2023, 1, 7, 17, 54, 15, 571, DateTimeKind.Local).AddTicks(5776), 13.0, null });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CanteenLocation", "City", "ContainsAlcohol", "Name", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId" },
                values: new object[] { 3, "Lc", 1, true, "Test3", new DateTime(2023, 1, 11, 17, 54, 15, 571, DateTimeKind.Local).AddTicks(5783), new DateTime(2023, 1, 2, 17, 54, 15, 571, DateTimeKind.Local).AddTicks(5781), 14.0, null });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PackageId",
                table: "Products",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Packages_PackageId",
                table: "Products",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Packages_PackageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PackageId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packages",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Packages");

            migrationBuilder.AddColumn<string>(
                name: "PackageName",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Packages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packages",
                table: "Packages",
                column: "Name");

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_PackageName",
                table: "Products",
                column: "PackageName");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Packages_PackageName",
                table: "Products",
                column: "PackageName",
                principalTable: "Packages",
                principalColumn: "Name");
        }
    }
}

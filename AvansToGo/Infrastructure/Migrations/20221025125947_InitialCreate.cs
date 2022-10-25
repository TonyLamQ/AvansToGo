using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canteens",
                columns: table => new
                {
                    Location = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<int>(type: "int", nullable: true),
                    ServesHotMeals = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canteens", x => x.Location);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
                    ContainsAlcohol = table.Column<bool>(type: "bit", nullable: false),
                    price = table.Column<double>(type: "float", nullable: true),
                    CanteenLocation = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReservedByStudentId = table.Column<int>(type: "int", nullable: true),
                    PickUpTimeStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PickUpTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Packages_Canteens_CanteenLocation",
                        column: x => x.CanteenLocation,
                        principalTable: "Canteens",
                        principalColumn: "Location");
                    table.ForeignKey(
                        name: "FK_Packages_Students_ReservedByStudentId",
                        column: x => x.ReservedByStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContainsAlcohol = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PackageName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Products_Packages_PackageName",
                        column: x => x.PackageName,
                        principalTable: "Packages",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CanteenLocation",
                table: "Packages",
                column: "CanteenLocation");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ReservedByStudentId",
                table: "Packages",
                column: "ReservedByStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PackageName",
                table: "Products",
                column: "PackageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Canteens");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canteens",
                columns: table => new
                {
                    Location = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
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
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanteenLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContainsAlcohol = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
                    ContainsAlcohol = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    CanteenLocation = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PickUpTimeStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PickUpTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Canteens_CanteenLocation",
                        column: x => x.CanteenLocation,
                        principalTable: "Canteens",
                        principalColumn: "Location",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "PackageProduct",
                columns: table => new
                {
                    PackagesId = table.Column<int>(type: "int", nullable: false),
                    ProductsName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageProduct", x => new { x.PackagesId, x.ProductsName });
                    table.ForeignKey(
                        name: "FK_PackageProduct_Packages_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageProduct_Products_ProductsName",
                        column: x => x.ProductsName,
                        principalTable: "Products",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Canteens",
                columns: new[] { "Location", "City", "ServesHotMeals" },
                values: new object[,]
                {
                    { "La", 0, true },
                    { "Lc", 1, true },
                    { "Ld", 2, false }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "CanteenLocation", "Email", "UserName" },
                values: new object[] { 1, "La", "Employee@gmail.com", "Tim" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "ContainsAlcohol", "ImageUrl" },
                values: new object[,]
                {
                    { "Orange juice", false, "https://www.smart-meals.nl/wp-content/uploads/2021/09/Versse-sinaasappelsap.jpg" },
                    { "Red wine", true, "https://cdn-prod.medicalnewstoday.com/content/images/articles/300/300854/red-wine.jpg" },
                    { "Sauzijnenbroodje", false, "https://images0.persgroep.net/rcs/iicE-7D10ut18K6FnZtMYA2_z8k/diocontent/159715277/_focus/0.62/0.3/_fill/1200/630/?appId=21791a8992982cd8da851550a453bd7f&quality=0.7" },
                    { "Worstenbroodje", false, "https://cdn.heelhollandbakt.nl/2022/05/vegan-worstenbroodjes-robert-enzo.jpg" }
                });

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
                columns: new[] { "Id", "CanteenLocation", "City", "ContainsAlcohol", "Name", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId", "Type" },
                values: new object[] { 1, "La", 0, true, "Test", new DateTime(2023, 1, 31, 15, 50, 5, 134, DateTimeKind.Local).AddTicks(2393), new DateTime(2023, 1, 18, 15, 50, 5, 134, DateTimeKind.Local).AddTicks(2366), 10.0, 1, 0 });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CanteenLocation", "City", "ContainsAlcohol", "Name", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId", "Type" },
                values: new object[] { 2, "Ld", 2, false, "Test2", new DateTime(2023, 1, 25, 15, 50, 5, 134, DateTimeKind.Local).AddTicks(2402), new DateTime(2023, 1, 19, 15, 50, 5, 134, DateTimeKind.Local).AddTicks(2400), 13.0, null, 1 });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CanteenLocation", "City", "ContainsAlcohol", "Name", "PickUpTimeEnd", "PickUpTimeStart", "Price", "StudentId", "Type" },
                values: new object[] { 3, "Lc", 1, true, "Test3", new DateTime(2023, 1, 23, 15, 50, 5, 134, DateTimeKind.Local).AddTicks(2407), new DateTime(2023, 1, 14, 15, 50, 5, 134, DateTimeKind.Local).AddTicks(2406), 14.0, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_PackageProduct_ProductsName",
                table: "PackageProduct",
                column: "ProductsName");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CanteenLocation",
                table: "Packages",
                column: "CanteenLocation");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_StudentId",
                table: "Packages",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PackageProduct");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Canteens");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}

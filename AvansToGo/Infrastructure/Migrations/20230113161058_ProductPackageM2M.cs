using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ProductPackageM2M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Packages_PackageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PackageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Products");

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

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 23, 17, 10, 58, 615, DateTimeKind.Local).AddTicks(2183), new DateTime(2023, 1, 10, 17, 10, 58, 615, DateTimeKind.Local).AddTicks(2153) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 17, 17, 10, 58, 615, DateTimeKind.Local).AddTicks(2194), new DateTime(2023, 1, 11, 17, 10, 58, 615, DateTimeKind.Local).AddTicks(2191) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 15, 17, 10, 58, 615, DateTimeKind.Local).AddTicks(2200), new DateTime(2023, 1, 6, 17, 10, 58, 615, DateTimeKind.Local).AddTicks(2198) });

            migrationBuilder.CreateIndex(
                name: "IX_PackageProduct_ProductsName",
                table: "PackageProduct",
                column: "ProductsName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageProduct");

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 23, 8, 43, 11, 820, DateTimeKind.Local).AddTicks(6364), new DateTime(2023, 1, 10, 8, 43, 11, 820, DateTimeKind.Local).AddTicks(6329) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 17, 8, 43, 11, 820, DateTimeKind.Local).AddTicks(6380), new DateTime(2023, 1, 11, 8, 43, 11, 820, DateTimeKind.Local).AddTicks(6377) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PickUpTimeEnd", "PickUpTimeStart" },
                values: new object[] { new DateTime(2023, 1, 15, 8, 43, 11, 820, DateTimeKind.Local).AddTicks(6388), new DateTime(2023, 1, 6, 8, 43, 11, 820, DateTimeKind.Local).AddTicks(6385) });

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
    }
}

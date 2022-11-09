using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FKStudentPackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Students_ReservedByStudentId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_ReservedByStudentId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ReservedByStudentId",
                table: "Packages");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_StudentId",
                table: "Packages",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Students_StudentId",
                table: "Packages",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Students_StudentId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_StudentId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Packages");

            migrationBuilder.AddColumn<int>(
                name: "ReservedByStudentId",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ReservedByStudentId",
                table: "Packages",
                column: "ReservedByStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Students_ReservedByStudentId",
                table: "Packages",
                column: "ReservedByStudentId",
                principalTable: "Students",
                principalColumn: "StudentId");
        }
    }
}

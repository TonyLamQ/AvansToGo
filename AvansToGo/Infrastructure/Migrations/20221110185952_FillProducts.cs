using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FillProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "ContainsAlcohol", "ImageUrl", "PackageName" },
                values: new object[,]
                {
                    { "Orange juice", false, "https://www.smart-meals.nl/wp-content/uploads/2021/09/Versse-sinaasappelsap.jpg", null },
                    { "Red wine", true, "https://cdn-prod.medicalnewstoday.com/content/images/articles/300/300854/red-wine.jpg", null },
                    { "Sauzijnenbroodje", false, "https://images0.persgroep.net/rcs/iicE-7D10ut18K6FnZtMYA2_z8k/diocontent/159715277/_focus/0.62/0.3/_fill/1200/630/?appId=21791a8992982cd8da851550a453bd7f&quality=0.7", null },
                    { "Worstenbroodje", false, "https://cdn.heelhollandbakt.nl/2022/05/vegan-worstenbroodjes-robert-enzo.jpg", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Name",
                keyValue: "Orange juice");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Name",
                keyValue: "Red wine");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Name",
                keyValue: "Sauzijnenbroodje");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Name",
                keyValue: "Worstenbroodje");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickNEat.API.Migrations
{
    /// <inheritdoc />
    public partial class FixAWImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 109,
                column: "ImageUrl",
                value: "https://web.aw.ca/static/media/onions_hero.e0bd333a.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 110,
                column: "ImageUrl",
                value: "https://web.aw.ca/static/media/W18-0610_AW_SpicyGuac_LTO_Fries_desktop_hero_2396x1473_EN.f1f58d9a.jpg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CoverImageUrl",
                value: "https://web.aw.ca/static/media/desktop-hero.7d0c8be4.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 109,
                column: "ImageUrl",
                value: "https://web.aw.ca/static/media/carousel_onions_1.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 110,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1573080496219-bb080dd4f877?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CoverImageUrl",
                value: "https://images.unsplash.com/photo-1550547660-d9450f859349?w=800&h=400&fit=crop&auto=format");
        }
    }
}

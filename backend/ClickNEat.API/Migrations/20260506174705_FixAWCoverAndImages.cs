using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickNEat.API.Migrations
{
    /// <inheritdoc />
    public partial class FixAWCoverAndImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-poutine?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 110,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1576107232684-1279f390859f?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 111,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-poutine?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverImageUrl", "LogoUrl" },
                values: new object[] { "https://web.aw.ca/static/media/bg-onions.39d27fc7.jpg", "https://web.aw.ca/static/media/icon-en.c28f6fec.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1563245372-f21724e3856d?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 110,
                column: "ImageUrl",
                value: "https://web.aw.ca/static/media/W18-0610_AW_SpicyGuac_LTO_Fries_desktop_hero_2396x1473_EN.f1f58d9a.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 111,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1563245372-f21724e3856d?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverImageUrl", "LogoUrl" },
                values: new object[] { "https://web.aw.ca/static/media/desktop-hero.7d0c8be4.jpg", "https://web.aw.ca/logo512.png" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickNEat.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMcDonaldsImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 50,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-big-mac-1?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 51,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-double-cheeseburger?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 52,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-mcchicken?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 53,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-filet-o-fish-1?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 54,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-fries-medium?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 55,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-10-chicken-mcnuggets-1?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 56,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-6-chicken-mcnuggets?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 57,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-mcflurry-oreo-regular-size?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 58,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-hot-caramel-sundae?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 59,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-baked-apple-pie?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 60,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-coca-cola?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 61,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-premium-roast-coffee-medium-product?wid=500&hei=350&fmt=jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 62,
                column: "ImageUrl",
                value: "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-chocolate-milk-1?wid=500&hei=350&fmt=jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 50,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 51,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1594212699903-ec8a3eca50f5?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 52,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1606755962773-d324e0a13086?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 53,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1553979459-d2229ba7433b?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 54,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1573080496219-bb080dd4f877?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 55,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1562802378-063ec186a863?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 56,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1562802378-063ec186a863?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 57,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1563805042-7684c019e1cb?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 58,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1570197788417-0e82375c9371?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 59,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1568702846914-96b305d2aaeb?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 60,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1554866585-cd94860890b7?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 61,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1509042239860-f550ce710b93?w=500&h=350&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 62,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1572490122747-3968b75cc699?w=500&h=350&fit=crop&auto=format");
        }
    }
}

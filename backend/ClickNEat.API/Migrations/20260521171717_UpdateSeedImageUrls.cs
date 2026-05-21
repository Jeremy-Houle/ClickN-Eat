using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickNEat.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedImageUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionDe",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "DescriptionEs",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "NameDe",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "NameEs",
                table: "MenuItems");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/item-1.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/item-2.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/item-3.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/item-4.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/item-5.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/images/item-6.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/images/item-7.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/images/item-8.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "/images/item-9.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/images/item-10.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "/images/item-11.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "/images/item-12.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "/images/item-13.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "/images/item-14.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "/images/item-15.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "/images/item-16.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "/images/item-17.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "/images/item-18.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "/images/item-19.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "/images/item-20.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "/images/item-21.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImageUrl",
                value: "/images/item-22.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImageUrl",
                value: "/images/item-23.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 50,
                column: "ImageUrl",
                value: "/images/item-50.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 51,
                column: "ImageUrl",
                value: "/images/item-51.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 52,
                column: "ImageUrl",
                value: "/images/item-52.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 53,
                column: "ImageUrl",
                value: "/images/item-53.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 54,
                column: "ImageUrl",
                value: "/images/item-54.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 55,
                column: "ImageUrl",
                value: "/images/item-55.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 56,
                column: "ImageUrl",
                value: "/images/item-56.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 57,
                column: "ImageUrl",
                value: "/images/item-57.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 58,
                column: "ImageUrl",
                value: "/images/item-58.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 59,
                column: "ImageUrl",
                value: "/images/item-59.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 60,
                column: "ImageUrl",
                value: "/images/item-60.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 61,
                column: "ImageUrl",
                value: "/images/item-61.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 62,
                column: "ImageUrl",
                value: "/images/item-62.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 63,
                column: "ImageUrl",
                value: "/images/item-63.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 64,
                column: "ImageUrl",
                value: "/images/item-64.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 65,
                column: "ImageUrl",
                value: "/images/item-13.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 66,
                column: "ImageUrl",
                value: "/images/item-66.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 67,
                column: "ImageUrl",
                value: "/images/item-67.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 68,
                column: "ImageUrl",
                value: "/images/item-68.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 69,
                column: "ImageUrl",
                value: "/images/item-69.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 70,
                column: "ImageUrl",
                value: "/images/item-70.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 71,
                column: "ImageUrl",
                value: "/images/item-71.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 72,
                column: "ImageUrl",
                value: "/images/item-72.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 100,
                column: "ImageUrl",
                value: "/images/item-100.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 101,
                column: "ImageUrl",
                value: "/images/item-101.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 102,
                column: "ImageUrl",
                value: "/images/item-102.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 103,
                column: "ImageUrl",
                value: "/images/item-103.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 104,
                column: "ImageUrl",
                value: "/images/item-104.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 105,
                column: "ImageUrl",
                value: "/images/item-105.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 106,
                column: "ImageUrl",
                value: "/images/item-106.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 107,
                column: "ImageUrl",
                value: "/images/item-106.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 108,
                column: "ImageUrl",
                value: "/images/item-108.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 109,
                column: "ImageUrl",
                value: "/images/item-109.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 110,
                column: "ImageUrl",
                value: "/images/item-110.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 111,
                column: "ImageUrl",
                value: "/images/item-13.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 112,
                column: "ImageUrl",
                value: "/images/item-112.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 113,
                column: "ImageUrl",
                value: "/images/item-112.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 114,
                column: "ImageUrl",
                value: "/images/item-114.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 115,
                column: "ImageUrl",
                value: "/images/item-115.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 116,
                column: "ImageUrl",
                value: "/images/item-116.jpg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoverImageUrl",
                value: "/images/restaurant-1-cover.jpg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverImageUrl", "LogoUrl" },
                values: new object[] { "/images/restaurant-2-cover.jpg", "/images/restaurant-2-logo.png" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverImageUrl", "LogoUrl" },
                values: new object[] { "/images/restaurant-3-cover.jpg", "/images/restaurant-3-logo.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionDe",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEs",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameDe",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEs",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1553979459-d2229ba7433b?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1525059696034-4967a8e1dca2?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1594212699903-ec8a3eca50f5?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1574071318508-1cdbab80d002?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1628840042765-356cda07504e?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1513104890138-7c749659a591?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1565299624946-b28f40a0ae38?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1546793665-c74683f339c1?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1540189549336-e6e99c3679fe?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1573080496219-bb080dd4f877?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-poutine?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1603360946369-dc9bb6258143?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1547592166-23ac45744acd?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1606313564200-e75d5e30476c?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1470124182917-cc6e71b22ecc?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1571877227200-a0d98ea607e9?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1554866585-cd94860890b7?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1548839140-29a749e1cf4d?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1621506289937-a8e4df240d0b?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1523677011781-c91d1bbe2f9e?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1509042239860-f550ce710b93?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-big-mac-1?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-double-cheeseburger?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-mcchicken?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-filet-o-fish-1?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-fries-medium?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-10-chicken-mcnuggets-1?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-6-chicken-mcnuggets?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-mcflurry-oreo-regular-size?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-hot-caramel-sundae?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-baked-apple-pie?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-coca-cola?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-premium-roast-coffee-medium-product?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-chocolate-milk-1?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-quarter-pounder-cheese?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-mccrispy-1?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-poutine?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-side-salad?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-apple-slices?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-egg-mcmuffin?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-vanilla-cone?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-hot-fudge-sundae?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-sprite?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-dasani-water?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/teen-burger-desktop-399_en.0b60336c.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/mama-burger-2023-dt-en.7b905ded.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/mozza-dt-2023-en.ae0e4fea.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/6_buddy_burger-dt-en.0d1643c1.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/best-burger-ever-burger-desktop-en.c615859d.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/mushroom_mozza_desktop_hero_en.ec099922.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/nashville-hot-chicken-sandwich-desktop-en.9d1627e1.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/nashville-hot-chicken-sandwich-desktop-en.9d1627e1.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/chicken-nuggets-en.ffbf1cd1.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/onions_hero.e0bd333a.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://images.unsplash.com/photo-1576107232684-1279f390859f?w=500&h=350&fit=crop&auto=format", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-poutine?wid=500&hei=350&fmt=jpeg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/carousel_rootbeer_1.235d06f8.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/carousel_rootbeer_1.235d06f8.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/AW_HP_EN_1757x1080_Lemonade.c4c8349f.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/coffee-latte-dt-en.ffc07a9d.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "ImageUrl", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, "https://web.aw.ca/static/media/all-day-breakfast-hero-desktop.a109de6d.jpg", null, null, null });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoverImageUrl",
                value: "https://images.unsplash.com/photo-1414235077428-338989a2e8c0?w=800&h=400&fit=crop&auto=format");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverImageUrl", "LogoUrl" },
                values: new object[] { "https://images.unsplash.com/photo-1586816001966-79b736744398?w=800&h=400&fit=crop&auto=format", "https://www.mcdonalds.com/content/dam/sites/ca/nfl/icons/McD-squareLogo.png" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverImageUrl", "LogoUrl" },
                values: new object[] { "https://web.aw.ca/static/media/bg-onions.39d27fc7.jpg", "https://web.aw.ca/static/media/icon-en.c28f6fec.png" });
        }
    }
}

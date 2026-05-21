using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClickNEat.API.Migrations
{
    /// <inheritdoc />
    public partial class AddLogoAndAW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 100, "Burgers", "Double galette de boeuf grillé, laitue, tomate, fromage cheddar, sauce mayo", "https://web.aw.ca/static/media/teen-burger-desktop-399_en.0b60336c.jpg", true, "Teen Burger", 9.99m, 3 },
                    { 101, "Burgers", "Galette de boeuf grillé, laitue, tomate, mayonnaise — l'originale A&W", "https://web.aw.ca/static/media/mama-burger-2023-dt-en.7b905ded.jpg", true, "Mama Burger", 7.49m, 3 },
                    { 102, "Burgers", "Galette de boeuf, fromage mozzarella fondu, sauce tomate, laitue croustillante", "https://web.aw.ca/static/media/mozza-dt-2023-en.ae0e4fea.jpg", true, "Mozza Burger", 8.99m, 3 },
                    { 103, "Burgers", "Mini burger parfait — galette de boeuf, ketchup, moutarde", "https://web.aw.ca/static/media/6_buddy_burger-dt-en.0d1643c1.jpg", true, "Buddy Burger", 4.99m, 3 },
                    { 104, "Burgers", "Triple galette de boeuf, triple fromage, bacon — le plus costaud de la famille", "https://web.aw.ca/static/media/best-burger-ever-burger-desktop-en.c615859d.jpg", true, "Uncle Burger", 13.49m, 3 },
                    { 105, "Burgers", "Champignons sautés, fromage mozzarella fondu, galette de boeuf grillé", "https://web.aw.ca/static/media/mushroom_mozza_desktop_hero_en.ec099922.jpg", true, "Champignon Mozza Burger", 10.49m, 3 },
                    { 106, "Poulet", "Poulet croustillant épicé Nashville, salade de chou, mayo piquante", "https://web.aw.ca/static/media/nashville-hot-chicken-sandwich-desktop-en.9d1627e1.jpg", true, "Nashville Hot Chicken Burger", 10.49m, 3 },
                    { 107, "Poulet", "Filet de poulet entier croustillant, salade de chou crémeuse, pain brioché", "https://web.aw.ca/static/media/nashville-hot-chicken-sandwich-desktop-en.9d1627e1.jpg", true, "Chubby Chicken", 8.99m, 3 },
                    { 108, "Poulet", "6 morceaux de poulet pané croustillant, sauce trempette au choix", "https://web.aw.ca/static/media/chicken-nuggets-en.ffbf1cd1.jpg", true, "Chicken Nuggets", 6.99m, 3 },
                    { 109, "Accompagnements", "Rondelles d'oignon croustillantes — la signature A&W depuis 1956", "https://web.aw.ca/static/media/carousel_onions_1.jpg", true, "Rondelles d'oignon", 4.49m, 3 },
                    { 110, "Accompagnements", "Frites croustillantes au sel de mer — portion medium", "https://images.unsplash.com/photo-1573080496219-bb080dd4f877?w=500&h=350&fit=crop&auto=format", true, "Frites", 3.49m, 3 },
                    { 111, "Accompagnements", "Frites croustillantes, sauce brune maison, fromage en grains", "https://images.unsplash.com/photo-1563245372-f21724e3856d?w=500&h=350&fit=crop&auto=format", true, "Poutine", 5.99m, 3 },
                    { 112, "Boissons", "Bière de racines A&W, recette originale depuis 1919 — 473 ml", "https://web.aw.ca/static/media/carousel_rootbeer_1.235d06f8.jpg", true, "Root Beer A&W", 3.29m, 3 },
                    { 113, "Boissons", "Root Beer A&W avec une boule généreuse de crème glacée à la vanille", "https://web.aw.ca/static/media/carousel_rootbeer_1.235d06f8.jpg", true, "Root Beer Float", 4.49m, 3 },
                    { 114, "Boissons", "Limonade fraîche pressée — 473 ml", "https://web.aw.ca/static/media/AW_HP_EN_1757x1080_Lemonade.c4c8349f.jpg", true, "Limonade", 3.49m, 3 },
                    { 115, "Boissons", "Café fraîchement torréfié, taille medium", "https://web.aw.ca/static/media/coffee-latte-dt-en.ffc07a9d.jpg", true, "Café", 2.99m, 3 },
                    { 116, "Déjeuner", "Oeufs, bacon de boeuf, toast grillé beurré — servi toute la journée", "https://web.aw.ca/static/media/all-day-breakfast-hero-desktop.a109de6d.jpg", true, "Déjeuner Complet", 8.99m, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "LogoUrl",
                value: "https://www.mcdonalds.com/content/dam/sites/ca/nfl/icons/McD-squareLogo.png");

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "AccentColor", "CoverImageUrl", "Description", "LogoUrl", "Name" },
                values: new object[] { 3, "#F5821F", "https://images.unsplash.com/photo-1550547660-d9450f859349?w=800&h=400&fit=crop&auto=format", "Teen Burger · Onion Rings · Root Beer", "https://web.aw.ca/logo512.png", "A&W" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Restaurants");
        }
    }
}

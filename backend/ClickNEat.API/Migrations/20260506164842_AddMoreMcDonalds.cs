using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClickNEat.API.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreMcDonalds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 63, "Burgers", "Galette de boeuf 1/4 lb, fromage fondu, oignons, cornichons, moutarde, ketchup", "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-quarter-pounder-cheese?wid=500&hei=350&fmt=jpeg", true, "Quarter Pounder", 8.49m, 2 },
                    { 64, "Burgers", "Filet de poulet croustillant, laitue croquante, mayo — sandwich signature", "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-mccrispy-1?wid=500&hei=350&fmt=jpeg", true, "McCrispy", 7.99m, 2 },
                    { 65, "Accompagnements", "Frites croustillantes, sauce brune, fromage en grains — classique québécois", "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-poutine?wid=500&hei=350&fmt=jpeg", true, "Poutine", 5.49m, 2 },
                    { 66, "Accompagnements", "Mélange de laitues fraîches, tomates cerises, vinaigrette au choix", "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-side-salad?wid=500&hei=350&fmt=jpeg", true, "Salade latérale", 3.29m, 2 },
                    { 67, "Accompagnements", "Tranches de pommes fraîches — accompagnement santé", "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-apple-slices?wid=500&hei=350&fmt=jpeg", true, "Tranches de pommes", 1.49m, 2 },
                    { 68, "Déjeuner", "Oeuf, fromage, jambon canadien sur muffin anglais grillé", "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-egg-mcmuffin?wid=500&hei=350&fmt=jpeg", true, "Egg McMuffin", 5.99m, 2 },
                    { 69, "Desserts", "Crème glacée à la vanille onctueuse — cornet gaufrette", "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-vanilla-cone?wid=500&hei=350&fmt=jpeg", true, "Cornet de crème glacée", 1.29m, 2 },
                    { 70, "Desserts", "Crème glacée vanille, sauce au chocolat chaud", "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-hot-fudge-sundae?wid=500&hei=350&fmt=jpeg", true, "Sundae sauce chaude", 2.49m, 2 },
                    { 71, "Boissons", "Boisson gazeuse citron-lime — grand format 591 ml", "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-sprite?wid=500&hei=350&fmt=jpeg", true, "Sprite", 2.49m, 2 },
                    { 72, "Boissons", "Eau purifiée en bouteille — 591 ml", "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds-dasani-water?wid=500&hei=350&fmt=jpeg", true, "Eau Dasani", 1.99m, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 72);
        }
    }
}

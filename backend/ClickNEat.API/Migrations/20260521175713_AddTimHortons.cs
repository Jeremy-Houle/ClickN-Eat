using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClickNEat.API.Migrations
{
    /// <inheritdoc />
    public partial class AddTimHortons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "RestaurantId", "Tags" },
                values: new object[,]
                {
                    { 200, "Boissons", "Café brassé à la canadienne, léger et équilibré", "/images/item-200.png", true, "Café Original", 2.19m, 4, "" },
                    { 201, "Boissons", "Café original avec double crème et double sucre — l'emblème canadien", "/images/item-201.png", true, "Double Double", 2.49m, 4, "" },
                    { 202, "Boissons", "Cappuccino glacé crémeux, la recette originale Tim Hortons", "/images/item-202.png", true, "Ice Capp", 4.29m, 4, "" },
                    { 203, "Boissons", "Café doux à la vanille française, chaud et velouté", "/images/item-203.png", true, "French Vanilla", 3.29m, 4, "" },
                    { 204, "Déjeuner", "Wrap grillé garni de bacon croustillant, oeuf et fromage cheddar", "/images/item-204.png", true, "Wrap Bacon Oeuf Fromage", 5.99m, 4, "" },
                    { 205, "Déjeuner", "Saucisse, oeuf brouillé, fromage et sauce maison dans un wrap chaud", "/images/item-205.png", true, "Farmers Wrap", 6.49m, 4, "" },
                    { 206, "Déjeuner", "Galette de pommes de terre dorée et croustillante", "/images/item-206.png", true, "Hashbrown", 1.99m, 4, "" },
                    { 207, "Boulangerie", "Boules de pâte glacées, les originaux Tim Hortons (10 pcs)", "/images/item-207.png", true, "Timbits Glacés", 3.49m, 4, "" },
                    { 208, "Boulangerie", "Boules de pâte au chocolat glacé (10 pcs)", "/images/item-208.png", true, "Timbits Chocolat", 3.49m, 4, "" },
                    { 209, "Boulangerie", "Beigne fourré à la crème pâtissière, glacé au chocolat", "/images/item-209.png", true, "Beigne Boston Cream", 1.89m, 4, "" },
                    { 210, "Boulangerie", "Beigne glacé au sirop d'érable — classique québécois", "/images/item-210.png", true, "Beigne à l'érable", 1.89m, 4, "" },
                    { 211, "Boulangerie", "Muffin moelleux aux bleuets sauvages, cuit le matin", "/images/item-211.png", true, "Muffin aux bleuets", 2.29m, 4, "" },
                    { 212, "Boulangerie", "Croissant feuilleté au beurre, légèrement doré", "/images/item-212.png", true, "Croissant au beurre", 2.49m, 4, "" },
                    { 213, "Boulangerie", "Carré au chocolat fondant, riche et décadent", "/images/item-213.png", true, "Brownie au chocolat", 2.49m, 4, "" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "AccentColor", "CoverImageUrl", "Description", "LogoUrl", "Name" },
                values: new object[] { 4, "#C8102E", "/images/restaurant-4-cover.jpg", "Double Double · Timbits · Beignes · Muffins", "/images/restaurant-4-logo.png", "Tim Hortons" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

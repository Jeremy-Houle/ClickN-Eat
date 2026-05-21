using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClickNEat.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Burgers", "Galette de pois chiches, avocat, tomate, mayo citron", "Burger Végé", 13.49m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Burgers", "Double boeuf, double cheddar, bacon, sauce maison", "Burger Double", 17.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Pizzas", "Sauce tomate, mozzarella, basilic frais", "Pizza Margherita", 13.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Pizzas", "Sauce tomate, mozzarella, pepperoni", "Pizza Pepperoni", 15.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Pizzas", "Mozzarella, gorgonzola, parmesan, chèvre", "Pizza 4 Fromages", 16.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Pizzas", "Sauce BBQ, poulet grillé, oignon rouge, mozzarella", "Pizza BBQ Poulet", 16.49m });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 9, "Salades", "Romaine, croûtons, parmesan, sauce césar", "", true, "Salade César", 9.99m },
                    { 10, "Salades", "Tomate, concombre, feta, olives, oignon rouge", "", true, "Salade Grecque", 10.49m },
                    { 11, "Salades", "Poulet grillé, mesclun, avocat, vinaigrette miel-moutarde", "", true, "Salade Poulet Grillé", 12.99m },
                    { 12, "Accompagnements", "Frites maison croustillantes", "", true, "Frites", 4.99m },
                    { 13, "Accompagnements", "Frites, fromage en grains, sauce brune", "", true, "Poutine", 8.99m },
                    { 14, "Accompagnements", "Rondelles d'oignon panées, sauce ranch", "", true, "Rondelles d'oignon", 6.49m },
                    { 15, "Accompagnements", "Soupe maison avec pain grillé", "", true, "Soupe du jour", 5.99m },
                    { 16, "Desserts", "Moelleux au chocolat, coulis de caramel", "", true, "Gâteau au chocolat", 6.99m },
                    { 17, "Desserts", "Crème brûlée à la vanille", "", true, "Crème brûlée", 5.99m },
                    { 18, "Desserts", "Tiramisu classique au café et mascarpone", "", true, "Tiramisu", 6.49m },
                    { 19, "Boissons", "355 ml", "", true, "Coca-Cola", 2.99m },
                    { 20, "Boissons", "500 ml", "", true, "Eau", 1.99m },
                    { 21, "Boissons", "Jus d'orange pressé, 300 ml", "", true, "Jus d'orange", 3.49m },
                    { 22, "Boissons", "Citron frais, menthe, eau gazeuse", "", true, "Limonade maison", 3.99m },
                    { 23, "Boissons", "Espresso, allongé ou cappuccino", "", true, "Café", 2.49m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Pizzas", "Sauce tomate, mozzarella, basilic frais", "Pizza Margherita", 13.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Pizzas", "Sauce tomate, mozzarella, pepperoni", "Pizza Pepperoni", 15.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Salades", "Romaine, croûtons, parmesan, sauce césar", "Salade César", 9.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Accompagnements", "Frites maison croustillantes", "Frites", 4.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Boissons", "355 ml", "Coca-Cola", 2.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Boissons", "500 ml", "Eau", 1.99m });
        }
    }
}

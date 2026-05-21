using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClickNEat.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRestaurants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "MenuItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccentColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "RestaurantId",
                value: 1);

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 50, "Burgers", "Deux galettes de boeuf, sauce spéciale, laitue, fromage, cornichons, oignon", "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=500&h=350&fit=crop&auto=format", true, "Big Mac", 7.49m, 2 },
                    { 51, "Burgers", "Double galette de boeuf, cornichons, oignons, moutarde, ketchup, fromage", "https://images.unsplash.com/photo-1594212699903-ec8a3eca50f5?w=500&h=350&fit=crop&auto=format", true, "McDouble", 4.49m, 2 },
                    { 52, "Burgers", "Poulet croustillant, mayo, laitue", "https://images.unsplash.com/photo-1606755962773-d324e0a13086?w=500&h=350&fit=crop&auto=format", true, "McChicken", 5.49m, 2 },
                    { 53, "Burgers", "Filet de poisson pané, sauce tartare, fromage", "https://images.unsplash.com/photo-1553979459-d2229ba7433b?w=500&h=350&fit=crop&auto=format", true, "Filet-O-Fish", 6.29m, 2 },
                    { 54, "Accompagnements", "Frites croustillantes — portion medium", "https://images.unsplash.com/photo-1573080496219-bb080dd4f877?w=500&h=350&fit=crop&auto=format", true, "Frites Medium", 3.49m, 2 },
                    { 55, "Accompagnements", "Morceaux de poulet croustillants avec sauce au choix", "https://images.unsplash.com/photo-1562802378-063ec186a863?w=500&h=350&fit=crop&auto=format", true, "McNuggets 10 pcs", 8.99m, 2 },
                    { 56, "Accompagnements", "Morceaux de poulet croustillants avec sauce au choix", "https://images.unsplash.com/photo-1562802378-063ec186a863?w=500&h=350&fit=crop&auto=format", true, "McNuggets 6 pcs", 5.99m, 2 },
                    { 57, "Desserts", "Crème glacée vanille avec biscuits Oreo écrasés", "https://images.unsplash.com/photo-1563805042-7684c019e1cb?w=500&h=350&fit=crop&auto=format", true, "McFlurry Oreo", 4.49m, 2 },
                    { 58, "Desserts", "Crème glacée vanille nappée de caramel chaud", "https://images.unsplash.com/photo-1570197788417-0e82375c9371?w=500&h=350&fit=crop&auto=format", true, "Sundae Caramel", 2.99m, 2 },
                    { 59, "Desserts", "Chausson aux pommes dorées et croustillantes", "https://images.unsplash.com/photo-1568702846914-96b305d2aaeb?w=500&h=350&fit=crop&auto=format", true, "Tarte aux pommes", 1.99m, 2 },
                    { 60, "Boissons", "Grand format — 591 ml", "https://images.unsplash.com/photo-1554866585-cd94860890b7?w=500&h=350&fit=crop&auto=format", true, "Coca-Cola", 2.49m, 2 },
                    { 61, "Boissons", "Café fraîchement torréfié, taille medium", "https://images.unsplash.com/photo-1509042239860-f550ce710b93?w=500&h=350&fit=crop&auto=format", true, "Café McCafé", 1.99m, 2 },
                    { 62, "Boissons", "Lait au chocolat froid, 1% — 500 ml", "https://images.unsplash.com/photo-1572490122747-3968b75cc699?w=500&h=350&fit=crop&auto=format", true, "Lait au chocolat", 1.49m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "AccentColor", "CoverImageUrl", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "#FF416C", "https://images.unsplash.com/photo-1414235077428-338989a2e8c0?w=800&h=400&fit=crop&auto=format", "Burgers · Pizzas · Salades · Poutine", "Le Comptoir" },
                    { 2, "#DA291C", "https://images.unsplash.com/photo-1586816001966-79b736744398?w=800&h=400&fit=crop&auto=format", "Big Mac · McNuggets · McFlurry", "McDonald's" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "MenuItems");
        }
    }
}

using ClickNEat.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ClickNEat.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { Id = 1, Name = "Burger Classic", Description = "Boeuf grillé, laitue, tomate, cheddar", Price = 12.99m, Category = "Burgers", ImageUrl = "", IsAvailable = true },
            new MenuItem { Id = 2, Name = "Burger BBQ", Description = "Boeuf grillé, bacon, oignon caramélisé, sauce BBQ", Price = 14.99m, Category = "Burgers", ImageUrl = "", IsAvailable = true },
            new MenuItem { Id = 3, Name = "Pizza Margherita", Description = "Sauce tomate, mozzarella, basilic frais", Price = 13.99m, Category = "Pizzas", ImageUrl = "", IsAvailable = true },
            new MenuItem { Id = 4, Name = "Pizza Pepperoni", Description = "Sauce tomate, mozzarella, pepperoni", Price = 15.99m, Category = "Pizzas", ImageUrl = "", IsAvailable = true },
            new MenuItem { Id = 5, Name = "Salade César", Description = "Romaine, croûtons, parmesan, sauce césar", Price = 9.99m, Category = "Salades", ImageUrl = "", IsAvailable = true },
            new MenuItem { Id = 6, Name = "Frites", Description = "Frites maison croustillantes", Price = 4.99m, Category = "Accompagnements", ImageUrl = "", IsAvailable = true },
            new MenuItem { Id = 7, Name = "Coca-Cola", Description = "355 ml", Price = 2.99m, Category = "Boissons", ImageUrl = "", IsAvailable = true },
            new MenuItem { Id = 8, Name = "Eau", Description = "500 ml", Price = 1.99m, Category = "Boissons", ImageUrl = "", IsAvailable = true }
        );
    }
}

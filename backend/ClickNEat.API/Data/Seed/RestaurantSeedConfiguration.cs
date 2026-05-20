using ClickNEat.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClickNEat.API.Data.Seed;

public class RestaurantSeedConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.HasData(
            new Restaurant { Id = 1, Name = "Le Comptoir", Description = "Burgers · Pizzas · Salades · Poutine", CoverImageUrl = "https://images.unsplash.com/photo-1414235077428-338989a2e8c0?w=800&h=400&fit=crop&auto=format", AccentColor = "#FF416C", LogoUrl = "" },
            new Restaurant { Id = 2, Name = "McDonald's", Description = "Big Mac · McNuggets · McFlurry", CoverImageUrl = "https://images.unsplash.com/photo-1586816001966-79b736744398?w=800&h=400&fit=crop&auto=format", AccentColor = "#DA291C", LogoUrl = "https://www.mcdonalds.com/content/dam/sites/ca/nfl/icons/McD-squareLogo.png" },
            new Restaurant { Id = 3, Name = "A&W", Description = "Teen Burger · Onion Rings · Root Beer", CoverImageUrl = "https://web.aw.ca/static/media/bg-onions.39d27fc7.jpg", AccentColor = "#F5821F", LogoUrl = "https://web.aw.ca/static/media/icon-en.c28f6fec.png" }
        );
    }
}

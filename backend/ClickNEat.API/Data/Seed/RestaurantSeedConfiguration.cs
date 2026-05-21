using ClickNEat.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClickNEat.API.Data.Seed;

public class RestaurantSeedConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.HasData(
            new Restaurant { Id = 1, Name = "Le Comptoir", Description = "Burgers · Pizzas · Salades · Poutine", CoverImageUrl = "/images/restaurant-1-cover.jpg", AccentColor = "#FF416C", LogoUrl = "" },
            new Restaurant { Id = 2, Name = "McDonald's", Description = "Big Mac · McNuggets · McFlurry", CoverImageUrl = "/images/restaurant-2-cover.jpg", AccentColor = "#DA291C", LogoUrl = "/images/restaurant-2-logo.png" },
            new Restaurant { Id = 3, Name = "A&W", Description = "Teen Burger · Onion Rings · Root Beer", CoverImageUrl = "/images/restaurant-3-cover.jpg", AccentColor = "#F5821F", LogoUrl = "/images/restaurant-3-logo.png" },
            new Restaurant { Id = 4, Name = "Tim Hortons", Description = "Double Double · Timbits · Beignes · Muffins", CoverImageUrl = "/images/restaurant-4-cover.jpg", AccentColor = "#C8102E", LogoUrl = "/images/restaurant-4-logo.png" }
        );
    }
}

using ClickNEat.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClickNEat.API.Data.Seed;

public class UserSeedConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.Email).IsUnique();

        builder.HasData(
            new User { Id = 1, Name = "Admin", Email = "admin@clickneat.com", PasswordHash = "$2a$11$X8aEcMTN7Ag/5iqJgyr1N.lrQ4D8X67/kevqA6B5qUxo3BDQpbHKy", Role = "Admin", CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 2, Name = "Client Test", Email = "client@clickneat.com", PasswordHash = "$2a$11$uumzhUwh0rpbuNR/XzSrC.i6rWaHiyhSNEgVAcgTMlGpnfF1hiuMK", Role = "Customer", CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}

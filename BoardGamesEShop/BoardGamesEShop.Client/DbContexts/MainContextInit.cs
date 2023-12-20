using BoardGamesEShop.Client.DbContexts;
using BoardGamesEShop.Client.Models.Accounts;
using BoardGamesEShop.Client.Models.Products;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BoardGamesEShop.Client.DbContexts;

public sealed partial class MainDbContext
{
    public MainDbContext() { }

    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.Entity<User>()
                    .OwnsManyDefault(p => p.Addresses);

        _ = modelBuilder.Entity<Product>()
            .OwnsManyDefault(p => p.ImagePaths);

        _ = modelBuilder.Entity<Game>()
                    .OwnsManyDefault(p => p.ImagePaths);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = optionsBuilder.UseNpgsql("host=localhost; database=board_games_e_shop; username=postgres; password=password");
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
    }
}
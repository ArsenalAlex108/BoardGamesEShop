using BoardGamesEShop.Client.DbContexts;
using BoardGamesEShop.Client.Models.Accounts;
using BoardGamesEShop.Client.Models.Products;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Npgsql;

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
        string string1 = "host=localhost; database=board_games_e_shop; username=postgres; password=password";

        var connectionString = new NpgsqlConnectionStringBuilder()
        {
            // The Cloud SQL proxy provides encryption between the proxy and instance.
            SslMode = SslMode.Disable,

            // Note: Saving credentials in environment variables is convenient, but not
            // secure - consider a more secure solution such as
            // Cloud Secret Manager (https://cloud.google.com/secret-manager) to help
            // keep secrets safe.
            Host = "/cloudsql/boardgameeshop:asia-east1:board-games-e-shop",
            Username = "postgres",
            Password = "N_rrPR9y~cdiAR"
        };
        connectionString.Pooling = true;

        string string2 = "host=34.80.57.16; username=postgres; password=N_rrPR9y~cdiAR))";
        string string3 = connectionString.ToString();

        _ = optionsBuilder.UseNpgsql(string3);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
    }
}
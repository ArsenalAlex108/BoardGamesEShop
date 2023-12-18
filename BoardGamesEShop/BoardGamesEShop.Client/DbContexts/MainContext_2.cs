using BoardGamesEShop.Client.Models.Accounts;
using BoardGamesEShop.Client.DbContexts.Abstractions;
using BoardGamesEShop.Client.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.DbContexts;

public partial class MainDbContext : IProductContext
{
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<BillProducts> BillProducts { get; set; }
}

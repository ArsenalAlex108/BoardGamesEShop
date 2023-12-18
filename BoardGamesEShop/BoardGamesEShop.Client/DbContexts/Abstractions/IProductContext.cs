using BoardGamesEShop.Client.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.DbContexts.Abstractions;

public interface IProductContext : IDbContextSaver
{
    DbSet<Bill> Bills { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Game> Games { get; set; }
    DbSet<Stock> Stocks { get; set; }
    DbSet<Review> Reviews { get; set; }
    DbSet<Warehouse> Warehouses { get; set; }
    DbSet<BillProducts> BillProducts { get; set; }


}

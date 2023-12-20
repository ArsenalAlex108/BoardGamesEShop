using BoardGamesEShop.Client.DbContexts;
using BoardGamesEShop.Client.DbContexts.Abstractions;
using BoardGamesEShop.Client.Models.Miscellaneous;
using BoardGamesEShop.Client.Models.Products;

using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.Services;

public class Cart
{
    public IDictionary<Product, Singleton<int>> Products { get; } = new Dictionary<Product, Singleton<int>>();

    public Money TotalPrice
    {
        get
        {
            Money sum = new() { Currency = Currency.USD };

            foreach (var (product, count) in Products)
            {
                sum = sum is not null ? sum + product.Price * count.Value : product.Price;
            }

            return sum;
        }
    }

    public string Validate(DbContextManager<IProductContext> dbContextManager)
    {
        string validationErrors = "";

        foreach (var (product, count) in Products)
        {
            var actualCount = dbContextManager.Select(db => db.Stocks.Include(s => s.Product).Include(s => s.Warehouse)).Where(s => s.Product == product).Sum(s => s.Count);

            if (actualCount < count.Value)
            {
                validationErrors += $"{((validationErrors == "") ? "" : "\n")} Product count of \"{product.Name}\" is {count.Value}, which is more than {actualCount} in stock.";
            }
        }

        return validationErrors;
    }
}

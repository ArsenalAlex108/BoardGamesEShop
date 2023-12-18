using BoardGamesEShop.Client.Models.Miscellaneous;
using BoardGamesEShop.Client.Models.Products;

namespace BoardGamesEShop.Client.Services;

public class Cart
{
    public IDictionary<Product, uint> Products { get; } = new Dictionary<Product, uint>();

    public Money? TotalPrice
    {
        get
        {
            Money? sum = null;

            foreach (var (product, count) in Products) 
            {
                sum = sum is not null ? sum + product.Price : product.Price;
            }

            return sum;
        }
    }
}

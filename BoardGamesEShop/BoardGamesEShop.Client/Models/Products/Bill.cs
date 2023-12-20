using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BoardGamesEShop.Client.Models.Accounts;
using BoardGamesEShop.Client.Models.Miscellaneous;

namespace BoardGamesEShop.Client.Models.Products;

public class Bill
{
    internal Bill() { }

    [Key]
    public Guid Id { get; set; }

    public required DateTimeOffset Time { get; set; }
    public virtual required User Buyer { get; set; }
    public virtual required Address Destination { get; set; }
    public required Money TotalProductsPrice { get; set; }
    public Money DeliveryPrice { get; set; } = new() { Currency = Currency.USD };

    public Money TotalPrice => TotalProductsPrice + DeliveryPrice;
}

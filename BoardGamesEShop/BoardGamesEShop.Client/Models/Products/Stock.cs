using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.Models.Products;

[PrimaryKey(nameof(WarehouseId), nameof(ProductId))]
public class Stock
{
    internal Stock() { }

    public Guid WarehouseId
    {
        get => Warehouse.Id; set => Warehouse.Id = value;
    }
    public virtual required Warehouse Warehouse { get; set; }

    public Guid ProductId
    {
        get => Product.Id; set => Product.Id = value;
    }
    public virtual required Product Product { get; set; }

    [Range(0, int.MaxValue)]
    public required int Count { get; set; }
}

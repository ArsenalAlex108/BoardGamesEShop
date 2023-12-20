using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.Models.Products;

[PrimaryKey(nameof(WarehouseId), nameof(ProductId))]
public class Stock
{
    private Warehouse _warehouse;
    private Product _product;

    internal Stock() { }

    private Guid WarehouseId { get; set; }
    public virtual required Warehouse Warehouse
    {
        get => _warehouse; set
        {
            WarehouseId = value.Id;
            _warehouse = value;
        }
    }

    private Guid ProductId { get; set; }
    public virtual required Product Product
    {
        get => _product; set
        {
            ProductId = value.Id;
            _product = value;
        }
    }

    [Range(0, int.MaxValue)]
    public required int Count { get; set; }
}

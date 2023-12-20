using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.Models.Products;

[PrimaryKey(nameof(BillId), nameof(WarehouseId), nameof(ProductId))]
public class BillProducts
{
    private Warehouse _warehouse;
    private Product _product;
    private Bill _bill;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    internal BillProducts() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private Guid BillId { get; set; }

    public virtual required Bill Bill
    {
        get => _bill;
        set
        {
            BillId = value.Id;
            _bill = value;
        }
    }

    private Guid WarehouseId { get; set; }
    public virtual required Warehouse Warehouse
    {
        get => _warehouse;
        set
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
            _product = value;
            ProductId = value.Id;
        }
    }

    [Range(0, int.MaxValue)]
    public required int Count { get; set; }

    public void Expunge()
    {
        _product = null!;
        _warehouse = null!;
        _bill = null!;
    }
}

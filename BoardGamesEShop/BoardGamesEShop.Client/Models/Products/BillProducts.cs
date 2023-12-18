﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.Models.Products;

[PrimaryKey(nameof(BillId), nameof(WarehouseId), nameof(ProductId))]
public class BillProducts
{
    internal BillProducts() { }

    private Guid BillId { get => Bill.Id; set => Bill.Id = value; }

    public virtual required Bill Bill { get; set; }

    public Guid WarehouseId { get => Warehouse.Id; set => Warehouse.Id = value; }
    public virtual required Warehouse Warehouse { get; set; }

    public Guid ProductId { get => Product.Id; set => Product.Id = value; }
    public virtual required Product Product { get; set; }

    [Range(0, int.MaxValue)]
    public required int Count { get; set; }
}

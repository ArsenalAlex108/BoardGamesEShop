using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoardGamesEShop.Client.Models.Miscellaneous;

namespace BoardGamesEShop.Client.Models.Products;

public class Warehouse
{
    internal Warehouse() { }

    [Key]
    [Column]
    public Guid Id { get; set; }
    public virtual required Address Address { get; set; }
    public bool IsClosed { get; set; }
}

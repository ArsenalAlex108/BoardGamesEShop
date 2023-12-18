using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using BoardGamesEShop.Client.Models.Miscellaneous;

namespace BoardGamesEShop.Client.Models.Products;

public class Product
{
    internal Product() { }

    [Key]
    [Column]
    public Guid Id { get; set; }
    [Length(1, 20)]
    public required string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public required Money Price { get; set; }
    public virtual IList<ImagePath> ImagePaths { get; set; } = [];
    public virtual IList<Game> Games { get; set; } = [];
    public bool IsDiscontinued { get; set; }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using BoardGamesEShop.Client.Models.Miscellaneous;

namespace BoardGamesEShop.Client.Models.Products;

public class Product : IEquatable<Product>
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
    [MinLength(1)]
    public virtual IList<Game> Games { get; set; } = [];
    public bool IsDiscontinued { get; set; }

    public virtual bool Equals(Product? other) => ReferenceEquals(this, other) || Id == other?.Id;

    public override bool Equals(object? obj)
    {
        return Equals(obj as Product);
    }

    public static bool operator ==(Product a, Product b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(Product a, Product b)
    {
        return !a.Equals(b);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

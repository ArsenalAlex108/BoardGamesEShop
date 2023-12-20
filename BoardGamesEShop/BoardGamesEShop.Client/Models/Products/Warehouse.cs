using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BoardGamesEShop.Client.Models.Miscellaneous;

namespace BoardGamesEShop.Client.Models.Products;

public class Warehouse : IEquatable<Warehouse?>
{
    internal Warehouse() { }

    [Key]
    [Column]
    public Guid Id { get; set; }
    public virtual required Address Address { get; set; }
    public bool IsClosed { get; set; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Warehouse);
    }

    public bool Equals(Warehouse? other)
    {
        return other is not null &&
               Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Warehouse? left, Warehouse? right)
    {
        return EqualityComparer<Warehouse>.Default.Equals(left, right);
    }

    public static bool operator !=(Warehouse? left, Warehouse? right)
    {
        return !(left == right);
    }
}

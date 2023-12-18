using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using BoardGamesEShop.Client.Models.Accounts;

namespace BoardGamesEShop.Client.Models.Products;

[PrimaryKey(nameof(ReviewerName), nameof(ProductId))]
public class Review
{
    internal Review() { }

    public string ReviewerName { get => Reviewer.Name; set => Reviewer.Name = value; }
    public virtual required User Reviewer { get; set; }
    public Guid ProductId { get => Product.Id; set => Product.Id = value; }
    public virtual required Product Product { get; set; }
    [Range(1, 5)]
    public required byte Stars { get; set; }
    public string Comment { get; set; } = "";
    public required DateTimeOffset Time { get; set; }
}

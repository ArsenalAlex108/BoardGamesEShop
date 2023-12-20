using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using BoardGamesEShop.Client.Models.Accounts;

namespace BoardGamesEShop.Client.Models.Products;

[PrimaryKey(nameof(ReviewerName), nameof(ProductId))]
public class Review
{
    private User _reviewer;
    private Product _product;

    internal Review() { }

    private string ReviewerName { get; set; }
    public virtual required User Reviewer
    {
        get => _reviewer;
        set
        {
            ReviewerName = value.Name;
            _reviewer = value;
        }
    }
    private Guid ProductId { get; set; }
    public virtual required Product Product
    {
        get => _product;
        set
        {
            ProductId = value.Id;
            _product = value;
        }
    }
    [Range(1, 5)]
    public required byte Stars { get; set; }
    public string Comment { get; set; } = "";
    public required DateTimeOffset Time { get; set; }
}

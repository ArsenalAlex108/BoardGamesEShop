using BoardGamesEShop.Client.Models.Accounts;
using BoardGamesEShop.Client.Models.Products;

using System.ComponentModel.DataAnnotations;

namespace BoardGamesEShop.Client.Dtos;

public sealed class ReviewDto
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public User Reviewer { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Product Product { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [Range(1, 5)]
    public short Stars { get; set; } = 5;
    public string Comment { get; set; } = "";
    public Review ToReview()
    {
        return new()
        {
            Reviewer = Reviewer,
            Product = Product,
            Stars = (byte)Stars,
            Comment = Comment,
            Time = DateTimeOffset.UtcNow
        };
    }
}

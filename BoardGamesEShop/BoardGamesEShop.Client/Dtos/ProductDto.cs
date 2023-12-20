using BoardGamesEShop.Client.Models.Miscellaneous;
using BoardGamesEShop.Client.Models.Products;
using BoardGamesEShop.Client.Services;

using System.ComponentModel.DataAnnotations;

namespace BoardGamesEShop.Client.Dtos;

public sealed class ProductDto
{
    [Length(1, 20)]
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public Money Price { get; set; } = null!;
    public IList<Singleton<string>> ImagePaths { get; set; } = [];
    [MinLength(1)]
    public IList<Game> Games { get; set; } = [];

    public Product ToProduct()
    {

        return new()
        {
            Name = Name,
            Description = Description,
            Price = Price,
            ImagePaths = ImagePaths.Select(s => new ImagePath() { Path = s.Value })
                                   .ToList(),
            Games = Games.Where(g => g is not null).ToHashSet().ToList(),
        };
    }
}

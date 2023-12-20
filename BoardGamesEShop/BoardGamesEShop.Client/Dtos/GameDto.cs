using BoardGamesEShop.Client.Models.Miscellaneous;
using BoardGamesEShop.Client.Models.Products;
using BoardGamesEShop.Client.Services;

using System.ComponentModel.DataAnnotations;

namespace BoardGamesEShop.Client.Dtos;

public sealed class GameDto
{
    [Length(1, 20)]
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public IList<Singleton<string>> ImagePaths { get; set; } = [];

    public Game ToGame()
    {
        return new() { Name = Name, Description = Description, ImagePaths = ImagePaths.Select(s => new ImagePath() { Path = s.Value }).ToList() };
    }
}

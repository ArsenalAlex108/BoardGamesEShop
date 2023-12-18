using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoardGamesEShop.Client.Models.Miscellaneous;

namespace BoardGamesEShop.Client.Models.Products;

public class Game
{
    internal Game() { }

    [Key, Length(1, 20)]
    public required string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public virtual IList<ImagePath> ImagePaths { get; set; } = [];
}

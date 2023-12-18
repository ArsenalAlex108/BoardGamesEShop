using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.Models.Miscellaneous;

[Owned]
public class ImagePath
{
    [MinLength(1)]
    public required string Path { get; set; }
}

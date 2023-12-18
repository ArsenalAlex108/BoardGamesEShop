using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.Models.Miscellaneous;

[Owned]
public sealed class Address
{
    public string HouseNumber { get; set; } = "";
    [Length(2, 50)]
    public required string Ward { get; set; } = "";
    [Length(2, 50)]
    public required string District { get; set; } = "";
    [Length(2, 50)]
    public required string City { get; set; } = "";
    [Length(6, 6)]
    public required string PostalCode { get; set; } = "";

    public override string? ToString()
    {
        return (HouseNumber, Ward, District, City, PostalCode).ToString();
    }
}

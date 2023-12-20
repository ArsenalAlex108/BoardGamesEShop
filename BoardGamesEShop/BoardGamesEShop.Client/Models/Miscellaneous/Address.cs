using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.Models.Miscellaneous;

[Owned]
public sealed class Address
{
    public string HouseNumber { get; set; } = "";
    [Length(2, 50)]
    public string Ward { get; set; } = "";
    [Length(2, 50)]
    public string District { get; set; } = "";
    [Length(2, 50)]
    public string City { get; set; } = "";
    [Length(5, 5)]
    public string PostalCode { get; set; } = "";

    public override string? ToString()
    {
        return "Address: " + ((String.IsNullOrWhiteSpace(HouseNumber)) ? "No House Number" : HouseNumber, Ward, District, City).ToString() + ", Postal Code: " + PostalCode;
    }

    public string String => ToString() ?? "";
}

public record struct AddressDto(string HouseNumber, string Ward, string District, string City, string PostalCode)
{
    public static implicit operator (string HouseNumber, string Ward, string District, string City, string PostalCode)(AddressDto value)
    {
        return (value.HouseNumber, value.Ward, value.District, value.City, value.PostalCode);
    }

    public static implicit operator AddressDto((string HouseNumber, string Ward, string District, string City, string PostalCode) value)
    {
        return new AddressDto(value.HouseNumber, value.Ward, value.District, value.City, value.PostalCode);
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Update;

namespace BoardGamesEShop.Client.Models.Miscellaneous;


public sealed class Currency
{
    [Key, MinLength(1)]
    public required string Name { get; set; } = "";

    /// <summary>
    /// The formatted string used as: string.Format(FormatString, amount, Name).
    /// </summary>
    public string FormatString { get; set; } = "{0} {1}";
    public string GetFormattedValue(decimal amount)
    {
        return string.Format(FormatString, amount, Name);
    }

    public static Currency USD { get; } = new() { Name = "USD", FormatString = "$ {0}" };
}

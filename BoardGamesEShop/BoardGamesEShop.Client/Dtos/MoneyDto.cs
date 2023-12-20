using System.ComponentModel.DataAnnotations;

namespace BoardGamesEShop.Client.Dtos;

public sealed class MoneyDto
{
    [Range(0, double.MaxValue, MinimumIsExclusive = true)]
    public decimal Amount { get; set; }

    [MinLength(1)]
    public string CurrencyName { get; set; } = "";
}

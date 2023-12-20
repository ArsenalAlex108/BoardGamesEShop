using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.Models.Miscellaneous;

[Owned]
public class Money
{
    internal Money() { }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    public virtual required Currency Currency { get; set; }

    public override string? ToString()
    {
        return Currency.GetFormattedValue(Amount);
    }

    public static Money operator +(Money a, Money b)
    {
        if (a.Currency.Name != b.Currency.Name) throw new NotSupportedException("Cannot add money of different currencies.");

        return new Money() { Amount = a.Amount + b.Amount, Currency = a.Currency };
    }

    public static Money operator *(Money a, int amount)
    {

        return new Money() { Amount = a.Amount * amount, Currency = a.Currency };
    }
}

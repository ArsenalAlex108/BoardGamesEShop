using System.Diagnostics.CodeAnalysis;
using BoardGamesEShop.Client.Models.Miscellaneous;

namespace BoardGamesEShop.Client.Models.Accounts;

public class User : Account
{
    internal User() { }

    public virtual IList<Address> Addresses { get; set; } = [];
}

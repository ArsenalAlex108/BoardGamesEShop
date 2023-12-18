using BoardGamesEShop.Client.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BoardGamesEShop.Client.Dtos;

public sealed class AccountLogin
{
    [Required, Length(2, 20)]
    public string Name { get; set; } = "";

    [Required, Length(2, 20)]
    public string Password { get; set; } = "";

    public User ToAccount() => new () { Name = Name, Password = Password };
}

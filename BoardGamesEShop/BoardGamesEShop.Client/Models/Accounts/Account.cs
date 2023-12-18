using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace BoardGamesEShop.Client.Models.Accounts;

public abstract class Account
{
    private protected Account() { }

    [Length(2, 20)]
    [Key]
    public required string Name { get; set; }

    [Column]
    [MinLength(10)]
    public string PasswordHash { get; private set; } = "";
    [StringLength(10, MinimumLength = 10)]
    public string? PhoneNumber { get; set; }
    public bool IsClosed { get; set; }
    public required string Password
    {
        set
        {
            PasswordHash = new PasswordHasher<Account>().HashPassword(this,
                                                                      value);
        }
    }
    public bool CheckPassword(string password)
    {
        return new PasswordHasher<Account>().VerifyHashedPassword(this, PasswordHash, password) != PasswordVerificationResult.Failed;
    }
}

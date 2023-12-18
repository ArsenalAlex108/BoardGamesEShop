using BoardGamesEShop.Client.Models.Miscellaneous;
using BoardGamesEShop.Client.Models.Accounts;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.DbContexts.Abstractions;

public interface IAccountContext : IDbContextSaver
{
    DbSet<Account> Accounts { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Admin> Admins { get; set; }
}

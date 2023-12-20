using BoardGamesEShop.Client.DbContexts.Abstractions;
using BoardGamesEShop.Client.Models.Accounts;
using BoardGamesEShop.Client.Models.Miscellaneous;

using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.DbContexts;

public partial class MainDbContext : DbContext, IDbContextSaver, IAccountContext, IMiscellaneousContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Currency> Currencies { get; set; }
}

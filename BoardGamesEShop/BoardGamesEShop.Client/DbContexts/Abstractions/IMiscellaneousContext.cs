using BoardGamesEShop.Client.Models.Miscellaneous;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.DbContexts.Abstractions;

public interface IMiscellaneousContext : IDbContextSaver
{
    DbSet<Currency> Currencies { get; set; }
}

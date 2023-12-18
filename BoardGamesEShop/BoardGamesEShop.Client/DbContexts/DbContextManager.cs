using BoardGamesEShop.Client.DbContexts.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesEShop.Client.DbContexts;

public sealed class DbContextManager<TContext>(Func<TContext> factory) where TContext : IDbContextSaver
{
    public TContext CreateContext() => factory();

    public async Task<int> Transaction(Func<TContext, Task> action, CancellationToken cancellationToken = default)
    {
        using var dbcontext = factory();
        await action(dbcontext);
        return await dbcontext.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task<int> Transaction(Action<TContext> action, CancellationToken cancellationToken = default)
    {
        using var dbcontext = factory();
        action(dbcontext);
        return await dbcontext.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public List<TResult> Select<TResult>(Func<TContext, DbSet<TResult>> query) where TResult : class
    {
        using var dbcontext = factory();
        return [.. query(dbcontext)];
    }
}

using System.Threading;
using System;

using BoardGamesEShop.Client.DbContexts.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

    public async Task<int> Transaction(Action<TContext>? action = null, CancellationToken cancellationToken = default)
    {
        using var dbcontext = factory();

        action ??= i => { };
        
        action(dbcontext);
        return await dbcontext.SaveChangesAsync(cancellationToken: cancellationToken);
    }
    
    public async Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        return await Transaction(db => db.Update<TEntity>(entity));
    }

    public async Task<int> UpdateRange(params object[] entities) => await UpdateRange(entities as IEnumerable<object>);

    public async Task<int> UpdateRange(IEnumerable<object> entities)
    {
        return await Transaction(db => db.UpdateRange(entities));
    }

    public List<TResult> Select<TResult>(Func<TContext, DbSet<TResult>> query) where TResult : class
    {
        using var dbcontext = factory();
        return [.. query(dbcontext)];
    }
}

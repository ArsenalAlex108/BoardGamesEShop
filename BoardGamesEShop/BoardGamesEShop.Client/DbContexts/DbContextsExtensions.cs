using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using BoardGamesEShop.Client.DbContexts.Abstractions;
using Microsoft.EntityFrameworkCore;
using BoardGamesEShop.Client.Models.Products;

namespace BoardGamesEShop.Client.DbContexts;

public static class DbContextsExtensions
{
    public static EntityTypeBuilder<TEntity> OwnsManyDefault
        <TEntity, TRelatedEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder,
            Expression<Func<TEntity, IEnumerable<TRelatedEntity>?>> navigationExpression)
        where TEntity : class
        where TRelatedEntity : class
    {
        return entityTypeBuilder.OwnsMany(navigationExpression, a =>
        {
            _ = a.WithOwner().HasForeignKey("OwnerId");
            _ = a.Property<int>("Id");
            _ = a.HasKey("Id");
        });
    }

    public static IServiceCollection AddManagedDbContext<TContext>(this IServiceCollection services, Func<TContext> factory) where TContext : IDbContextSaver
    {
        return services.AddScoped<DbContextManager<TContext>>(_ => new(factory));
    }

    public static bool TryAdd<T>(this DbSet<T> set, T entity) where T : class
    {
        if (!set.Contains(entity))
        {
            set.Add(entity);
            return false;
        }

        return true;
    }

    public static bool AddOrUpdate<T>(this DbSet<T> set, T entity) where T : class
    {
        if (!set.Contains(entity))
        {
            set.Add(entity);
            return true;
        }

        set.Update(entity);

        return false;
    }

    public static int ProductInStock(this IEnumerable<Stock> entities, Product product)
    {
        return entities.Where(s => s.Product == product)
                       .Sum(s => s.Count);
    }
}

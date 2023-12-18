using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using BoardGamesEShop.Client.DbContexts.Abstractions;

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
}

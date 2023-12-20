namespace BoardGamesEShop.Client.DbContexts.Abstractions;

public interface ITrackedEntity
{
    IEnumerable<object> GetEntities();
}

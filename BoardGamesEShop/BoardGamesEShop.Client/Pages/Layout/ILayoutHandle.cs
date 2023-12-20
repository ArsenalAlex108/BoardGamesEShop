using BoardGamesEShop.Client.Models.Accounts;

namespace BoardGamesEShop.Client.Pages.Layout;

public interface ILayoutHandle
{
    Account? Account { set; }
    bool IsAdmin { set; }
    bool IsUser { set; }
}

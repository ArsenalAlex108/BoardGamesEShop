namespace BoardGamesEShop.Client.Navigations;

public static partial class Paths
{
    public const string Admin = "admin";

    public const string ManageAccounts = Admin + "/accounts";

    public const string ManageGames = Admin + "/games";

    public const string ManageProducts = Admin + "/products";

    public const string ManageWarehouses = Admin + "/warehouses";

    public const string Add = "add";

    public const string AddGames = ManageGames + Backlash + Add;

    public const string AddProducts = ManageProducts + Backlash + Add;

    public const string AddWarehouses = ManageWarehouses + Backlash + Add;
}

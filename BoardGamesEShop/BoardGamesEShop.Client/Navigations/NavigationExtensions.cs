using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace BoardGamesEShop.Client.Navigations;

public static class NavigationExtensions
{
    public static bool TryGetValue(this NavigationManager navigationManager,
                                   string key,
                                   out StringValues value)
    {
        ArgumentNullException.ThrowIfNull(navigationManager);

        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException($"'{nameof(key)}' cannot be null or empty.", nameof(key));
        }

        var uri = navigationManager.ToAbsoluteUri(navigationManager.Uri);
        return QueryHelpers.ParseQuery(uri.Query).TryGetValue(key, out value);
    }
}
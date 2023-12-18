using BoardGamesEShop.Client.DbContexts;
using BoardGamesEShop.Client.DbContexts.Abstractions;
using BoardGamesEShop.Client.Services;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

await builder.Build().RunAsync();

using BoardGamesEShop.Client.DbContexts.Abstractions;
using BoardGamesEShop.Client.DbContexts;
using BoardGamesEShop.Client.Pages;
using BoardGamesEShop.Client.Services;
using BoardGamesEShop.Components;
using Microsoft.EntityFrameworkCore;
using BoardGamesEShop.Client.Models.Accounts;
using Syncfusion.Blazor;
using BoardGamesEShop.Client.Models.Miscellaneous;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

builder.Services.AddSyncfusionBlazor();

Func<MainDbContext> factory = () => new();

builder.Services.AddScoped<Cart>();
builder.Services.AddManagedDbContext<IAccountContext>(factory);
builder.Services.AddManagedDbContext<IProductContext>(factory);
builder.Services.AddManagedDbContext<IMiscellaneousContext>(factory);

builder.Services.AddScoped<Singleton<Account?>>(_ => new(null));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    _ = app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

using (var db = new MainDbContext())
{
    _ = db.Database.EnsureCreated();

    _ = db.Admins.TryAdd(new() { Name = "admin", Password = "4d8f5e2c" });

    _ = db.Currencies.TryAdd(Currency.USD);

    _ = db.SaveChanges();
}

app.Run();

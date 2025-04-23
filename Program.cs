using BlazorWebAppMovies.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlazorWebAppMovies.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<BlazorWebAppMoviesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlazorWebAppMoviesContext") ?? throw new InvalidOperationException("Connection string 'BlazorWebAppMoviesContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

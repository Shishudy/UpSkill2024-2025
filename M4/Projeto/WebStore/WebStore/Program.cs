using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Radzen;
using WebStore;
using System.Reflection;
using WebStore.Services;

using WebStore.Components;

var builder = WebApplication.CreateBuilder(args);

// Blazor
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

// Radzen Services
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

// HTTP Client para API
builder.Services.AddHttpClient("API", client =>
{
	client.BaseAddress = new Uri("http://localhost:5125/"); 
});

// Custom Auth Provider
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthStateProvider>());
builder.Services.AddScoped<ProtectedLocalStorage>();

// Services
builder.Services.AddScoped<TokenProvider>();
builder.Services.AddScoped<CampaignService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<FavouriteService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ImageService>();
builder.Services.AddScoped<AddProductService>();
builder.Services.AddScoped<SearchService>();



// Dynamically register all services in the Services folder

builder.Services.AddScoped<AddressInvoiceService>();
builder.Services.AddScoped<AddressShipmentService>();
builder.Services.AddScoped<CardService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<PurchaseService>();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();

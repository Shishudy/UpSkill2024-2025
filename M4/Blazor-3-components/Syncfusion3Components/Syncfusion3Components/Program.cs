using Syncfusion.Blazor;
using Syncfusion3Components;
using Syncfusion3Components.Components;
using Syncfusion3Components.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:4613/") });
builder.Services.AddScoped<TarefaService>();

var app = builder.Build();
//Register Syncfusion license https://help.syncfusion.com/common/essential-studio/licensing/how-to-generate
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXxcdXVURWdZWUd3WEtWYUA=");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

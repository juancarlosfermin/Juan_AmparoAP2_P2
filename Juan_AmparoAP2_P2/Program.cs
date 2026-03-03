using Blazored.Toast;
using Juan_AmparoAP2_P2.Components;
using Juan_AmparoAP2_P2.DAL;
using Juan_AmparoAP2_P2.Services;
using Microsoft.EntityFrameworkCore;
using Juan_AmparoAP2_P2 .Components;
using Juan_AmparoAP2_P2.DAL;
using Juan_AmparoAP2_P2.Services;





var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(ConStr));

builder.Services.AddScoped<ViajesEspacialesService>();


builder.Services.AddBlazoredToast();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

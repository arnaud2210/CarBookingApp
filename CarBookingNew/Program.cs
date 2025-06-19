using CarBookingNew.Api;
using CarBookingNew.Components;
using CarBookingNew.Data;
using Microsoft.EntityFrameworkCore;
//using SQLitePCL;

//Batteries.Init();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarDbContext>(options =>
    options.UseSqlite("Data Source=carbooking.db"));

builder.Services.AddScoped<CarService>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CarDbContext>();
    db.Database.EnsureCreated();
    SeedData.Initialize(scope.ServiceProvider);
}

app.Run();

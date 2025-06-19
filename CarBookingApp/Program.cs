using CarBookingApp.Components;
using CarBookingApp.Data;
using CarBookingApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(static options =>
    options.UseSqlite("Data Source=carbooking.db"));

builder.Services.AddScoped<CarService>();
builder.Services.AddControllers();

/*builder.Services.AddHttpClient<CarService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/");
});*/

builder.Services.AddHttpClient<CarService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllers(); // API
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.Run();

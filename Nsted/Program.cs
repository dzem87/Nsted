using Nsted.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Nsted;
//using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Build configuration
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

// Register the DbContext as a service
builder.Services.AddDbContext<KundeContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 5, 9))));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Removing Server Header
//Sometimes, headers could provide some information that is better to hide.
//To disable the Server header from Kestrel, you need to set AddServerHeader to false.
//Use UseKestrel() if your ASP.NET Core version is lower than 2.2 and ConfigureKestrel() if not.

WebHost.CreateDefaultBuilder(args)
.ConfigureKestrel(c => c.AddServerHeader = false)
.UseStartup<Startup>()
.Build();

app.Run();

    
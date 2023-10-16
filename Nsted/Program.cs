using Nsted.Models;
using Microsoft.EntityFrameworkCore;
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

app.Run();


using Nsted.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Nsted;
using Nsted.Repositories;
using Nsted.Data;
using Microsoft.AspNetCore.Identity;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Build configuration


var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

var authConfig = builder.Configuration;
var authConnectionString = authConfig.GetConnectionString("NstedAuthDbConnectionString");

// Register the DbContext as a service
builder.Services.AddDbContext<NstedDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 5, 9))));

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseMySql(authConnectionString, new MySqlServerVersion(new Version(10, 5, 9))));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    //Default settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

//Inject the interface into the services of our application
builder.Services.AddScoped<IKundeRepository, KundeRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

//Removing Server Header
//Sometimes, headers could provide some information that is better to hide.
//To disable the Server header from Kestrel, you need to set AddServerHeader to false.
//Use UseKestrel() if your ASP.NET Core version is lower than 2.2 and ConfigureKestrel() if not.

WebHost.CreateDefaultBuilder(args)
.ConfigureKestrel(c => c.AddServerHeader = false)
.UseStartup<Startup>()
.Build();

app.Run();

    
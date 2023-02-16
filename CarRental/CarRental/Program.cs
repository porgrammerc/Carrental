using CarRental.Models;
using CarRental.Repositories;
using CarRental.Repositories.Interfaces;
using CarRental.Services;
using CarRental.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                            .AddRoles<IdentityRole<Guid>>()
                            .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

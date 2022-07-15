using Microsoft.EntityFrameworkCore;
using Exercise_4.Models;
using Microsoft.Extensions.DependencyInjection;
using Exercise_4.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Exercise_4Context>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("Exercise_4Context") ?? throw new InvalidOperationException("Connection string 'Exercise_4Context' not found.")));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

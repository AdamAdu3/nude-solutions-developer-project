using InsuranceManager.Controllers;
using InsuranceManager.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite($"Data Source={Path.Combine(Path.GetTempPath(), "InsuranceManager.db")}"));


var app = builder.Build();

// Configure the db context.
IServiceScope serviceScope = app.Services.CreateScope();
DatabaseContext dbContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
dbContext.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

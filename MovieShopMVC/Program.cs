using ApplicationCore.Contracts.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// .Net Core has built-in Dependency Injection, first class citizen in .NET core
// Registrations
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

// oder .NET framework, we had to rely on 3rd party libraries to do DI such as Autofac, Ninject


// Inject DbContextOptions with connection string into MovieShopDbcontext

builder.Services.AddDbContext<MovieShopDbContext>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("MovieShopDbConnection"));
});





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

using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechTest.Bll.Genres;
using TechTest.Bll.ShowGenres;
using TechTest.Entities.Models;
using TechTest.Repositories.Genres;
using TechTest.Repositories.ShowGenres;
using TechTest.Repositories.Shows;
using TechTest.Server.Controllers;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.

builder.Services.AddDbContext<LocalDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
});

builder.Services.AddHttpClient();

builder.Services.AddTransient<IGenresRepository, GenresRepository>();
builder.Services.AddTransient<IShowsRepository, ShowsRepository>();
builder.Services.AddTransient<IShowGenresRepository, ShowGenresRepository>();
builder.Services.AddTransient<IBlGenres, BlGenres>();
builder.Services.AddTransient<IBlShows, BlShows>();
builder.Services.AddTransient<IBlShowGenres, BlShowGenres>();
builder.Services.AddTransient<ITvMazeService, TvMazeService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
using DDDTest.Application.Interfaces;
using DDDTest.Application.Queries.Categories;
using DDDTest.Infrastructure.Persistence;
using DDDTest.Infrastructure.Persistence.Repositories;
using DDDTest.Presentation.Middlewares;
using Microsoft.EntityFrameworkCore;
using DDDTest.Infrastructure.DependencyInjection;
using DDDTest.Application.Queries.Products;

var builder = WebApplication.CreateBuilder(args);
// MediatR configuration
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(GetAllCategoriesQuery).Assembly));
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQuery).Assembly));




builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

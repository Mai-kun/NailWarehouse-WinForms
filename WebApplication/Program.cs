using NailWarehouse.Contracts;
using NailWarehouse.Database;
using NailWarehouse.ProductManager;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace NailWarehouse.WebApplication
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<NailWarehouseDbContext>();

            builder.Services.AddSingleton<ILogger, Logger<ProductsManager>>();
            builder.Services.AddSingleton<IProductStorage, ProductStorage>();
            builder.Services.AddScoped<IProductManager, ProductsManager>();

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
                pattern: "{controller=Products}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

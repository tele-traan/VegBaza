using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Repository;
using Shop.Data.Interfaces;
using Shop.DB;
using Microsoft.AspNetCore.Http;
using Shop.Data.Models;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using Shop.MailServices;
using Shop.Hubs;

namespace NewApplication
{
    public class Startup
    {

        private IConfigurationRoot _confstring;

        public Startup(IWebHostEnvironment hostEnv)
        {
            _confstring = new ConfigurationBuilder()
                .SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddDataProtection().
                PersistKeysToFileSystem(new DirectoryInfo("DataProtectionKeys"));
            services.AddDbContext<AppDbContent>
                (options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddTransient<MailService>();
            services.AddTransient<IVegsRepository, VegRepositoryRepository>();
            services.AddTransient<IVegsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(ShopCart.GetCart);
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseEndpoints(endpoints => {
                endpoints.MapHub<CartHub>("/cartaction");
                endpoints.MapControllerRoute(name: "default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "cart", "{controller=ShopCart}/{hubaction?}");
                endpoints.MapControllerRoute(name: "categoryFilter", "Veg/{action}/{category?}",
                    defaults: new { Controller = "Veg", action = "List" });
            });

            using var scope = app.ApplicationServices.CreateScope();
            AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
            DbObjects.Initial(content);
        }
    }
}
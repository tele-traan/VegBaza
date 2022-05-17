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

namespace Shop
{
    public class Startup
    {

        private readonly IConfigurationRoot _confRoot;

        public Startup(IWebHostEnvironment hostEnv)
        {
            _confRoot = new ConfigurationBuilder()
                .SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            
            services.AddDataProtection().
                PersistKeysToFileSystem(new DirectoryInfo("DataProtectionKeys"));
            
            var connectionString = _confRoot.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<AppDbContent>
                (options => options.UseSqlServer(connectionString));
            
            services.AddTransient<IVegsRepository, VegsRepository>();
            services.AddTransient<IVegsCategory, CategoryRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            
            services.AddScoped(ShopCart.GetCart);
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
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
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("cart", "{controller=ShopCart}/{hubaction?}");
                endpoints.MapControllerRoute("categoryFilter", "Veg/{action}/{category?}",
                    new { Controller = "Veg", action = "List" });
            });

            using var scope = app.ApplicationServices.CreateScope();
            var content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
            DbObjects.Initial(content);
        }
    }
}
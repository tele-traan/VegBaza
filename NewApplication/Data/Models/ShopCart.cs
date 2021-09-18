using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Shop.DB;
namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDbContent;

        public ShopCart(AppDBContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Veg veg)
        {
            appDbContent.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                veg = veg,
                price = veg.price

            }) ;

            appDbContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return appDbContent.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(c => c.veg).ToList();
        }
    }
}
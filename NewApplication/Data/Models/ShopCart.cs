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
        private readonly AppDbContent _appDbContent;

        public ShopCart(AppDbContent appDbContent)
        { 
            _appDbContent = appDbContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            var context = services.GetService<AppDbContent>();
            var shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        public void AddToCart(Veg veg)
        {
            _appDbContent.ShopCartItems.Add(new ShopCartItem
            {
                Amount = 1,
                ShopCartId = ShopCartId,
                Veg = veg,
                Price = veg.Price
            });
            _appDbContent.SaveChanges();
        }
        public void RemoveItem(ShopCartItem item)
        {
            _appDbContent.ShopCartItems.Remove(item);
            _appDbContent.SaveChanges();
        }
        public void PlusItem(ShopCartItem item)
        {
            _appDbContent.ShopCartItems.FirstOrDefault(i => i.Id == item.Id).Amount++;
            _appDbContent.SaveChanges();
        }
        public void MinusItem(ShopCartItem item)
        {
            var iitem = _appDbContent.ShopCartItems.FirstOrDefault(i => i.Id == item.Id);
            if (iitem.Amount > 1)
            {
                iitem.Amount--;
            }
            else
            {
                RemoveItem(iitem);
            }
            _appDbContent.SaveChanges();
        }
        public void ClearCart()
        {
            _appDbContent.ShopCartItems.RemoveRange(_appDbContent.ShopCartItems);
            _appDbContent.SaveChanges();
            ListShopItems?.Clear();
        }
        public List<ShopCartItem> GetShopItems()
        {
            return _appDbContent.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(c => c.Veg).ToList();
        }
    }
}
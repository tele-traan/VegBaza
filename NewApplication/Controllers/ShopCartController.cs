using Shop.Data.Models;
using Shop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.ViewModels;
using System.Linq;
using System;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IVegsRepository _vegRepositoryRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IVegsRepository v, ShopCart c)
        {
            _vegRepositoryRep = v;
            _shopCart = c;
            _shopCart.ListShopItems = _shopCart.GetShopItems();
        }
        public ViewResult Index()
        {
            _shopCart.ListShopItems = _shopCart.GetShopItems();
            var obj = new ShopCartViewModel { ShopCart = _shopCart };
            return View(obj);
        }
        public RedirectToActionResult AddToCart(int id)
        {
            var item = _vegRepositoryRep.GetAllVegs().FirstOrDefault(i => i.Id == id);
            if (item == null) return RedirectToAction("Index");
            
            var itemInCart = _shopCart
                .ListShopItems
                .FirstOrDefault(i => i.Veg.Id == item.Id);
                
            if (_shopCart.ListShopItems.Contains(itemInCart)) _shopCart.PlusItem(itemInCart);
            else _shopCart.AddToCart(item);
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        public string PlusItem(int id, int index)
        {
            var item = _shopCart.ListShopItems.FirstOrDefault(i => i.Veg.Id == id);
            if (item != null)
            {
                _shopCart.PlusItem(item);
            }
            return $"{index}" + "SEPARATOR" +
                $"{_shopCart.ListShopItems.FirstOrDefault(i=>i.Veg.Id==id).Amount}";
        }
        [HttpPost]
        public string MinusItem(int id, int index)
        {
            var item = _shopCart.ListShopItems.FirstOrDefault(i => i.Veg.Id == id);
            if (item != null)
            {
                _shopCart.MinusItem(item);
            }
            return $"{index}" + "SEPARATOR" +
                $"{_shopCart.ListShopItems.FirstOrDefault(i => i.Veg.Id == id).Amount}";
        }
        [HttpPost]
        public RedirectToActionResult RemoveItem(int id)
        {
            var item = _shopCart.ListShopItems.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.RemoveItem(item);
            }
            return RedirectToAction("Index");
        }
    }
}
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
        private readonly IAllVegs _vegRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllVegs v, ShopCart c)
        {
            _vegRep = v;
            _shopCart = c;
            _shopCart.listShopItems = _shopCart.getShopItems();
        }
        public ViewResult Index()
        {
            int count = 0;
            foreach (var v in _shopCart.getShopItems())
            {
                int amount = v.amount;
                while (amount != 0)
                {
                    count++; amount--;
                }
            }
            ViewData["ItemsCount"] = count;
            _shopCart.listShopItems = _shopCart.getShopItems();
            var obj = new ShopCartViewModel { shopCart = _shopCart };
            return View(obj);
        }
        public RedirectToActionResult addToCart(int id)
        {
            var item = _vegRep.Vegs.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                if (_shopCart.listShopItems.Contains(_shopCart.listShopItems.FirstOrDefault(i => i.veg.id == item.id)))
                {
                    _shopCart.PlusItem(_shopCart.listShopItems.FirstOrDefault(i => i.veg.id == item.id));
                }
                else
                {
                    _shopCart.AddToCart(item);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public string PlusItem(int id, int index)
        {
            var item = _shopCart.listShopItems.FirstOrDefault(i => i.veg.id == id);
            if (item != null)
            {
                _shopCart.PlusItem(item);
            }
            return $"{index}" + "SEPARATOR" +
                $"{_shopCart.listShopItems.FirstOrDefault(i=>i.veg.id==id).amount}";
        }
        [HttpPost]
        public string MinusItem(int id, int index)
        {
            var item = _shopCart.listShopItems.FirstOrDefault(i => i.veg.id == id);
            if (item != null)
            {
                _shopCart.MinusItem(item);
            }
            return $"{index}" + "SEPARATOR" +
                $"{_shopCart.listShopItems.FirstOrDefault(i => i.veg.id == id).amount}";
        }
        [HttpPost]
        public RedirectToActionResult RemoveItem(int id)
        {
            var item = _shopCart.listShopItems.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _shopCart.RemoveItem(item);
            }
            return RedirectToAction("Index");
        }
    }
}
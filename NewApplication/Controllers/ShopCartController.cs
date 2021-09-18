using Shop.Data.Models;
using Shop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.ViewModels;
using System.Linq;
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
        }
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;
            var obj = new ShopCartViewModel { shopCart = _shopCart };
            return View(obj);
        }
        public RedirectToActionResult addToCart(int id)
        {
            var item = _vegRep.Vegs.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
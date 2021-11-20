using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;
using System.Linq;
using Shop.Data.Models;
namespace Shop.Controllers
{
    public class OneVegController : Controller
    {
        private readonly IAllVegs _vegRep;
        private readonly ShopCart _shopCart;
        public OneVegController(IAllVegs a, ShopCart s) {
            _vegRep = a;
            _shopCart = s;
        }
      //  [Route("Veg/List/cart/{id}")]
        public ViewResult OneVeg(int id)
        {
            var obj = new OneVegViewModel();
            foreach(var v in _vegRep.Vegs)
            {
                if(v.id == id)
                {
                    obj.veg = v;
                    break;
                }
            }
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
            return View(obj);

        }
    }
}

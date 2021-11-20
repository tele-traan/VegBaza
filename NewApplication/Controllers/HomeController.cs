using Shop.Data.Interfaces;
using Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllVegs _allVegs;
        private readonly ShopCart _shopCart;
        public HomeController(IAllVegs a, ShopCart s)
        {
            _allVegs = a;
            _shopCart = s;
        }
        public ViewResult Index()
        {
            int count = 0, amount;
            foreach(var v in _shopCart.getShopItems())
            {
                amount = v.amount;
                while(amount != 0)
                {
                    count++; amount--;
                }
            }
            ViewData["ItemsCount"] = count;
            return View(new HomeViewModel()
            { favVegs = _allVegs.getFavVegs });
        }
    }
}
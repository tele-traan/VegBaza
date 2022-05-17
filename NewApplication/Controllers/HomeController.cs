using System.Linq;
using Shop.Data.Interfaces;
using Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVegsRepository _vegsRepository;
        private readonly ShopCart _shopCart;
        public HomeController(IVegsRepository a, ShopCart s)
        {
            _vegsRepository = a;
            _shopCart = s;
        }
        public ViewResult Index()
        {
            var count = 0;
            var query = _shopCart.GetShopItems().Select(item => item.Amount).ToList();
            foreach(var a in query)
            {
                var amount = a;
                while(amount != 0)
                {
                    count++; amount--;
                }
            }
            ViewData["ItemsCount"] = count;
            return View(new HomeViewModel { FavVegs = _vegsRepository.GetFavVegs() });
        }
    }
}
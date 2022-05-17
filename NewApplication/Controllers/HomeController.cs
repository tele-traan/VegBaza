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
            var favVegs = _vegsRepository.GetFavVegs();
            return View(new HomeViewModel { FavVegs = favVegs });
        }
    }
}
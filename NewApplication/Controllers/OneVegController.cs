using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;
using System.Linq;
using Shop.Data.Models;
namespace Shop.Controllers
{
    public class OneVegController : Controller
    {
        private readonly IVegsRepository _vegRepositoryRep;
        private readonly ShopCart _shopCart;
        public OneVegController(IVegsRepository a, ShopCart s) {
            _vegRepositoryRep = a;
            _shopCart = s;
        }
        [Route("Veg/List/cart/{id:int}")]
        public ViewResult OneVeg(int id)
        {
            var obj = new OneVegViewModel();
            foreach(var v in _vegRepositoryRep.GetAllVegs())
            {
                if (v.Id != id) continue;
                obj.Veg = v;
                break;
                
            }
            return View(obj);

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class OneVegController : Controller
    {
        private readonly IAllVegs _vegRep;
        public OneVegController(IAllVegs a) {
            _vegRep = a;
        }
        [Route("Veg/List/cart/{id}")]
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
            return View(obj);

        }
    }

}

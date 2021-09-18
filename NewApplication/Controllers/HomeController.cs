using Shop.Data.Interfaces;
using Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllVegs _allVegs;
        public HomeController(IAllVegs vegRep)
        {
            _allVegs = vegRep;
        }

        public ViewResult Index()
        {
            var homeVegs = new HomeViewModel
            {
                favVegs = _allVegs.getFavVegs
            };
            return View(homeVegs);
        }
    }
}
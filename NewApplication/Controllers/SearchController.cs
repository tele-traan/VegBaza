using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.DB;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.ViewModels;
using System.Linq;
using Shop.Data.Models;
namespace Shop.Controllers
{
    public class SearchController : Controller
    {
        private readonly IAllVegs _vegRep;
        private readonly AppDBContent _appDbContent;
        private readonly ShopCart _shopCart;
        public SearchController(IAllVegs i, AppDBContent a, ShopCart s)
        {
            _vegRep = i;
            _appDbContent = a;
            _shopCart = s;
        }
        [HttpGet]
        public async Task<IActionResult> Result(string key)
        {
            ViewData["GetDetails"] = key;
            var empquery = from x in _appDbContent.Veg select x;
            if (!string.IsNullOrEmpty(key))
            {
                empquery = empquery.Where(x => x.name.Contains(key) || x.Category.categoryName.Contains(key));
            }
            var homeVegs = new SearchViewModel
            {
                vegsFound = await empquery.AsNoTracking().ToListAsync(), 
            };
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
            return View(homeVegs);
        }
    }
}